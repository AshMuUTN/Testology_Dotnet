using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Security.Tokens;
using Testology_Dotnet.Domain.Services;

namespace Testology_Dotnet.Services
{
    public class PasswordRecoveryEmailService : IPasswordRecoveryEmailService
    {
        private readonly IUserService _userService;

        private readonly ITokenHandler _tokenHandler;

        private readonly IConfiguration _configuration;

        public PasswordRecoveryEmailService(IUserService userService, ITokenHandler tokenHandler, IConfiguration configuration)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }
        public async Task<Response> Execute(string emailAddress)
        {
            var user = await _userService.FindByEmailAsync(emailAddress);

            if (user == null)
            {
                System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.Unauthorized;
                return new Response(statusCode, null, null);
            }

            var token = _tokenHandler.CreatePasswordResetToken(user);
            var apiKey = Environment.GetEnvironmentVariable("Testology_sendgrid_key");
            var client = new SendGridClient(apiKey);
            // var from = new EmailAddress("110967@tecnicatura.frc.utn.edu.ar", "Ashley");
            var from = new EmailAddress("english.ashleymusick@gmail.com", "Ashley");
            var to = new EmailAddress(emailAddress, "usuario de Testology");
            var templateData = new MailData();
            var frontendDomain = _configuration.GetValue<string>("FrontendDomain");
            templateData.PasswordChangeUrl =  frontendDomain + "/sesion/nuevo-pass/" + token;
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-c775a23df8e24ba5b357a51973f8c145", templateData);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
        
    }
}