using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Repositories.Auth;
using Testology_Dotnet.Persistence.Contexts;
using Testology_Dotnet.Persistence.Repositories;
using Testology_Dotnet.Services;
using Testology_Dotnet.Domain.Security.Hashing;
using Testology_Dotnet.Domain.Security.Tokens;
using Testology_Dotnet.Security.Hashing;
using Testology_Dotnet.Security.Tokens;
using Testology_Dotnet.Extensions;
using System;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Repositories.Score;
using Testology_Dotnet.Domain.Services.Score;
using Testology_Dotnet.Services.Score;

namespace Testology_Dotnet
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(
                CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate();
                
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCustomSwagger();
            services.AddScoped<IUploadRepository, UploadRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISubtestRepository, SubtestRepository>();
            services.AddScoped<ISubtestService, SubtestService>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

            //------Score -------//
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IScoreFilterRepository, ScoreFilterRepository>();
            services.AddScoped<IScoreFilterService, ScoreFilterService>();
            services.AddScoped<IGroupScoreFilterRepository, GroupScoreFilterRepository>();
            services.AddScoped<IGroupScoreFilterService, GroupScoreFilterService>();
            services.AddScoped<ISubtestScoreFilterRepository, SubtestScoreFilterRepository>();
            services.AddScoped<ISubtestScoreFilterService, SubtestScoreFilterService>();            
            services.AddScoped<IQuestionScoreFilterRepository, QuestionScoreFilterRepository>();
            services.AddScoped<IQuestionScoreFilterService, QuestionScoreFilterService>();

            //-----Auth--------//
			services.AddSingleton<IPasswordHasher, PasswordHasher>();
			services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordRecoveryEmailService, PasswordRecoveryEmailService>();

			services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
			var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

			var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
			services.AddSingleton(signingConfigurations);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(jwtBearerOptions =>
				{
					jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						IssuerSigningKey = signingConfigurations.SecurityKey,
						ClockSkew = TimeSpan.Zero
					};
				});
            services.AddAutoMapper(this.GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            
            app.UseAuthentication();
			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
