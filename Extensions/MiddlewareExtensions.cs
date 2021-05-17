using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Testology_Dotnet.Extensions
{
	public static class MiddlewareExtensions
	{
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Testology_Dotnet",
					Version = "v1",
					Description = "Testology_Dotnet for making tests with ASP.NET Core 3.1, built from scratch.",
					Contact = new OpenApiContact
					{
						Name = "Ashley Musick"
					},
					License = new OpenApiLicense
					{
						Name = "MIT",
					},
				});

				cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "JSON Web Token to access resources. Example: Bearer {token}",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
						},
						new [] { string.Empty }
					}
				});
			});

			return services;
		}

		public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger().UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Testology_Dotnet");
				options.DocumentTitle = "Testology_Dotnet";
			});

			return app;
		}
	}
}
