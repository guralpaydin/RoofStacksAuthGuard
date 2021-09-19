using Employee.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employee.JwtAuthRequirement
{
    public class JwtRequirement : IAuthorizationRequirement { }

    public class JwtRequirementHandler : AuthorizationHandler<JwtRequirement>
    {
        private readonly HttpClient client;
        private readonly HttpContext httpContext;
        private readonly IOptions<AppSettings> configuration;

        public JwtRequirementHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> settings)
        {
            client = httpClientFactory.CreateClient();
            httpContext = httpContextAccessor.HttpContext;
            configuration = settings;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtRequirement requirement)
        {
            if (httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var accessToken = authHeader.ToString().Split(' ')[1];
                var appSettingsSection = configuration.Value.ClientId;
                var requestData = new Dictionary<string, string>
                {
                    ["ClientId"] = appSettingsSection,
                    ["Token"] = accessToken
                };

                HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:44378/api/user/ValidateToken", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    context.Succeed(requirement);
                    return;
                }
                else
                {
                    context.Fail();
                }
                client.Dispose();
            }
            return;
        }
    }
}
