﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using CarSomeWebAPI.Services;

namespace CarSomeWebAPI.Infrastructure.Helper
{
    public static class JwtAuthenticationExtension
    {
		public static AuthenticationBuilder AddJwtAuthentication(this IServiceCollection services, string secret)
		{
			var key = Encoding.ASCII.GetBytes(secret);
			return services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.Events = new JwtBearerEvents
				{
					OnTokenValidated = context =>
					{
						/*var appointmentService = context.HttpContext.RequestServices.GetRequiredService<IAppointmentService>();
						var userId = int.Parse(context.Principal.Identity.Name);
						var user = userService.GetById(userId);
						if (user == null)
						{
							// return unauthorized if user no longer exists
							context.Fail("Unauthorized");
						}*/
						return Task.CompletedTask;
					}
				};
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
		}
	}
}
