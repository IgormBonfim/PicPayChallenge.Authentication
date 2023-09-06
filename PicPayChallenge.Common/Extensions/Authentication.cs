using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PicPayChallenge.Common.Tokens;
using System.Text;

namespace PicPayChallenge.Common.Extensions
{
    public static class Authentication
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(nameof(TokenOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("tokenOptions:SecurityKey").Value));

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = jwtSettings[nameof(TokenOptions.Issuer)];
                options.Audience = jwtSettings[nameof(TokenOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.Expiration = int.Parse(jwtSettings[nameof(TokenOptions.Expiration)] ?? "0");
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("TokenOptions:Issuer").Value,

                ValidateAudience = true,
                ValidAudience = configuration.GetSection("TokenOptions:Audience").Value,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
