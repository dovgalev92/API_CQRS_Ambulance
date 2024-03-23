using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ambulance_API_CQRS.ServieseAuth
{
    public static class ServiceConfigJwt
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSetting = configuration.GetSection("JwtSettings");
           
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSetting["validIssuer"],
                    ValidAudience = jwtSetting["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:key").Value))
                };
            });
        }
    }
}
