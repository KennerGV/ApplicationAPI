using ApplicationAPI.Cross_Cutting.Models.HealthCheckModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationAPI.Cross_Cutting.Config
{
    public static class HealthCheckConfig
    {
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthCheck", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    var response = new HealthCheckResponse
                    {                        
                        HealthChecks = report.Entries.Select(x => new HealthCheckEndPoint
                        {
                            Component = x.Key,
                            Status = x.Value.Status.ToString(),
                            Description = x.Value.Description
                        }),
                        HealthCheckDuration = report.TotalDuration.ToString()
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            });

            return app;

        }
    }
}
