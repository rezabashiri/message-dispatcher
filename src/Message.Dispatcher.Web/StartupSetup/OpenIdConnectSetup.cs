using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Message.Dispatcher.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;

namespace Message.Dispatcher.Web.StartupSetup;

public static class OpenIdConnectSetup
{
    public static IServiceCollection AddOpenIdConnect(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
    {

        // To not map claims name to default JWT ones
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                })

            .AddJwtBearer(options =>
            {
                var isDevelopmentOrStaging = env.IsDevelopment() || env.IsStaging();

                options.Authority = AuthencticationHelper.GetAuthority(env, config);
                options.RequireHttpsMetadata = env.IsProduction();
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = !isDevelopmentOrStaging,
                    //ValidIssuer = config["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    RoleClaimType = OpenIddictConstants.Claims.Role,
                    NameClaimType = OpenIddictConstants.Claims.Name,

                    ValidateLifetime = true,
                    ClockSkew = TokenValidationParameters.DefaultClockSkew,
                };
            });
        services.AddAuthorization(options =>
        {
            var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                JwtBearerDefaults.AuthenticationScheme);
            defaultAuthorizationPolicyBuilder =
                defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
            options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Username;
            options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
            options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
            options.ClaimsIdentity.EmailClaimType = OpenIddictConstants.Claims.Email;
            options.ClaimsIdentity.SecurityStampClaimType = "secret_value";
        });

        return services;
    }
}

