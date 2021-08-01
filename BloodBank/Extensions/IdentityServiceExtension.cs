using BloodBank.DataAccess.Data;
using BloodBank.Models.Model.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Extensions
{
    public static class IdentityServiceExtension
    {
      
        public static IServiceCollection AddIdentityService(this IServiceCollection services ,IConfiguration config)
        {
            var builder = services.AddIdentityCore<ApplicationUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddRoles<IdentityRole>();
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidIssuer = config["Toekn:Issuer"],
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;


        }
    }
}
