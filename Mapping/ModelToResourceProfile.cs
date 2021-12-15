using System.Linq;
using AutoMapper;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Resources;
using Testology_Dotnet.Resources.Auth;
using Testology_Dotnet.Domain.Security.Tokens;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Resources.Score;
using System.Collections.Generic;

namespace Testology_Dotnet.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Test, TestResource>();
            CreateMap<Subtest, SubtestResource>();
            CreateMap<Question, QuestionResource>();
            CreateMap<Option, OptionResource>();
            CreateMap<Image, ImageResource>();
            CreateMap<Protocol, ProtocolResource>();
            CreateMap<Answer, AnswerResource>();
            CreateMap<Question, AnsweredQuestionResource>()
                .ForMember(qr => qr.Answer, opt => opt.MapFrom(q => q.Answers.FirstOrDefault()));
                
            CreateMap<Division, DivisionResource>();
            CreateMap<Group, GroupResource>();
            CreateMap<ScoreFilter, ScoreFilterResource>();
            CreateMap<GroupScoreFilter, GroupScoreFilterResource>();
            CreateMap<SubtestScoreFilter, SubtestScoreFilterResource>();
            CreateMap<QuestionScoreFilter, QuestionScoreFilterResource>();

            CreateMap<Question, ReportAnsweredQuestion>()
                .ForMember(ra => ra.Answer, opt => opt.MapFrom(q => convertRawAnswersToSimpleText(q)))
                .ForMember(ra => ra.Question, opt => opt.MapFrom(q => q.Text));

            CreateMap<Subtest, ReportSubtest>();
            CreateMap<Report, ReportResource>()
                .ForMember(rr => rr.Total, opt => opt.MapFrom(r => calculateTotal(r.Subtests)))
                .ForMember(rr => rr.Percentage, opt => opt.MapFrom(r => calculatePercentage(r.Subtests)));

            CreateMap<User, UserResource>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }

        private string convertRawAnswersToSimpleText(Question q){
            Answer a = q.Answer;
            return a.TextAnswer != null 
                ? a.TextAnswer
                : a.OptionId != null
                ? (a.Option.Text != "none" ? a.Option.Text : a.Option.Number.ToString())
                : a.NumberAnswer.ToString();    
        }

        private float calculateTotal(List<Subtest> subtests){
            float total = 0;
            foreach( var s in subtests ){
                total += s.Score;
            }
            return total;
        }
        private float calculatePercentage(List<Subtest> subtests){
            float sum = 0;
            int count = 0;
            float percent = 0;
            foreach( var s in subtests ){
                if(s.IsScorable) {
                    sum += s.Percentage;
                    count++;
                }
            }
            if(count > 0){
                percent = sum/count;
            }
            return percent;
        }
        
    }
}