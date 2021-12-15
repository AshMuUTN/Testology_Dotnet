using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ISubtestRepository _subtestRepository;
        private readonly IProtocolRepository _protocolRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionScoreFilterRepository _questionScoreFilterRepository;
        private readonly IGroupScoreFilterRepository _groupScoreFilterRepository;
        private readonly ISubtestScoreFilterRepository _subtestScoreFilterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportRepository(ISubtestRepository subtestRepository, IProtocolRepository protocolRepository, IQuestionRepository questionRepository, IQuestionScoreFilterRepository questionScoreFilterRepository, IGroupScoreFilterRepository groupScoreFilterRepository, IUnitOfWork unitOfWork, IMapper mapper, ISubtestScoreFilterRepository subtestScoreFilterRepository)
        {
            _subtestRepository = subtestRepository;
            _protocolRepository = protocolRepository;
            _questionRepository = questionRepository;
            _questionScoreFilterRepository = questionScoreFilterRepository;
            _groupScoreFilterRepository = groupScoreFilterRepository;
            _subtestScoreFilterRepository =  subtestScoreFilterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ReportResource>> ListAsync(int testId)
        {
            var subtests = await _subtestRepository.ListAsync(testId);
            var protocols = await _protocolRepository.ListAsync(testId);
            var reports = new List<ReportResource>();
            foreach (var protocol in protocols)
            {
                var answeredSubtests = new List<Subtest>();
                foreach (var subtest in subtests)
                {
                    subtest.Questions = await _questionRepository.ListAnsweredAsync(subtest.Id, protocol.Id);
                    foreach(var q in subtest.Questions){
                        q.Answer = q.Answers.Where(a => a.ProtocolId == protocol.Id).FirstOrDefault();
                    }
                    await this.CalculateScoreAndPercent(subtest);
                    await this.ApplySubtestFilters(subtest);
                    subtest.Percentage = (int)Math.Round((subtest.Score/subtest.Max) * 100);
                    answeredSubtests.Add(subtest);
                }
                var report = new Report { Subtests = answeredSubtests, Protocol = protocol };
                reports.Add(
                    _mapper.Map<Report, ReportResource>(report)
                );
            }
            
            return reports;
        }

        private async Task CalculateScoreAndPercent(Subtest subtest)
        {
            float score = 0;
            float maxScore = 100;
            if(!subtest.IsScorable)
            {
                return;
            }

            if(subtest.IsCalculable)
            {
                foreach( var question in subtest.Questions)
                {
                    Answer ans = question.Answer;
                    if(ans == null){
                        break;
                    }
                    float questionScore = 
                        ans.OptionId == null 
                        ? ans.NumberAnswer 
                        : findOptionNumberResponse(question, ans);

                    var questionScoreFilters = await _questionScoreFilterRepository.ListAsync(question.Id);
                    foreach(var filter in questionScoreFilters)
                    {
                        questionScore = filter.ScoreFilterId != (int)ApplicationScoreFilter.Range 
                        ? this.ApplyCalculableFilter(filter, questionScore)
                        : this.ApplyRangeFilter(filter, questionScore, ans.NumberAnswer);
                    }

                    score+= questionScore;
                }
                subtest.Score = score;
            } 
            else 
            {
                var groupScoreFilters = await _groupScoreFilterRepository.ListAsync(subtest.Id);
                foreach( var question in subtest.Questions)
                {
                    Answer ans = question.Answer;
                    if(ans == null) {
                        break;
                    }
                    float questionScore = 0;
                    float maxForQuestion = 0;                    
                    var optionId = ans.OptionId;
                    if(optionId != 0 && optionId != null)
                    {
                        bool isCorrect = question.Options.Where(op => op.Id == ans.OptionId).First().IsCorrect;
                        var questionScoreFilters = await _questionScoreFilterRepository.ListAsync(question.Id);
                        foreach(var filter in questionScoreFilters)
                        {
                            questionScore = this.ApplyArbitraryFilter(filter, isCorrect);
                        }
                        maxForQuestion = questionScoreFilters.Max(f => f.Value);

                        foreach(var filter in groupScoreFilters)
                        {
                            questionScore = this.ApplyGroupScoreFilter(filter, questionScore, optionId);
                        }
                        if(groupScoreFilters.FirstOrDefault() != null){
                            maxForQuestion = questionScoreFilters.Max(f => f.Value);
                        }
                    }
                    score+=questionScore;
                    maxScore+=maxForQuestion;                    
                }
            }

            subtest.Score = score;
            subtest.Max = maxScore;
        }

        private float findOptionNumberResponse(Question question, Answer ans){
            Option op = question.Options.Where(op => op.Id == ans.OptionId).FirstOrDefault();
            return op != null ? op.Number : 0;
        }

        private float ApplyRangeFilter(QuestionScoreFilter filter, float score, float answer){
            return filter.From <= answer && filter.To > answer ? filter.Value : score;
        }

        private float ApplyCalculableFilter(IAppliedScoreFilter filter, float score)
        {
            if(filter.ScoreFilterId == (int)ApplicationScoreFilter.Self)
            {
                return score;
            }

            if(filter.ScoreFilterId == (int)ApplicationScoreFilter.AddValue)
            {
                return score + filter.Value;
            }

            if(filter.ScoreFilterId == (int)ApplicationScoreFilter.MultiplyValue)
            {
                return score * filter.Value;
            }

            if(filter.ScoreFilterId == (int)ApplicationScoreFilter.DivideValue)
            {
                return score / filter.Value;
            }
            // no scoring filter specified...return score as is
            return score;
        }

        private float ApplyArbitraryFilter(QuestionScoreFilter filter, bool isCorrect)
        {
            if(
                filter.ScoreFilterId == (int)ApplicationScoreFilter.Arbitrary 
                && isCorrect == filter.isForCorrectAnswers
            )
            {
                return filter.Value;
            } 
            else
            {
                return 0;
            }
        }

        private float ApplyGroupScoreFilter(GroupScoreFilter filter, float score, int? optionId)
        {
            // TODO:: not currently using multiple types of filters, this one should be arbitrary
            // but currently set up as count. Work around is to just leave it since its the only filter
            // currently being applied to groups
            if(filter.OptionId == optionId)
            {
                score = filter.Value;
            }
            return score;
        }

        private async Task ApplySubtestFilters(Subtest subtest){
            var subtestScoreFilters = await _subtestScoreFilterRepository.ListAsync(subtest.Id);
            var forcedMaxFlag = false;
            foreach(var filter in subtestScoreFilters){
                if(filter.ScoreFilterId == (int)ApplicationScoreFilter.Max)  {
                    forcedMaxFlag = true;
                    subtest.Max = filter.Value;
                }

                subtest.Score = this.ApplyCalculableFilter(filter, subtest.Score);
                if(!forcedMaxFlag){
                    subtest.Max = this.ApplyCalculableFilter(filter, subtest.Max);
                }
            }
        }
    }
}