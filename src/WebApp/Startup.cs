using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("myscope", new AuthorizationPolicy(new IAuthorizationRequirement[]
                {
                    new ClaimsAuthorizationRequirement("Scope", new[] {"myscope"}),
                    new DenyAnonymousAuthorizationRequirement(),
                }, new[] {"Bearer"}));
            });

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Trace);

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Authority = "http://localhost:5000/api",
                Audience = "http://localhost:5000/api/resources",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false
            });

            app.UseMvc();
        }

    }
}
