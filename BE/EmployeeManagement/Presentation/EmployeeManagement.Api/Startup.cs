using EmployeeManagement.Api.SignalRHubs;
using EmployeeManagement.Contracts.Services;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.Presistance;
using EmployeeManagement.Presistance.IOC;
using EmployeeManagement.Services;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EmployeeManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddInfrastructure(Configuration);
            services.AddHttpClient();
            services.AddHangfire(a => a.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnectionString")));
            services.AddHangfireServer();

            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book Management", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseHangfireDashboard("/hangfire");
            //"0 */5 * * * *"
            RecurringJob.AddOrUpdate<IIntegrationTradeService>("500", a => a.CreateIntegrationTrade(), "0 */5 * * * *");
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors("default");
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<EmployeeHub>("/employeeHub");
                //endpoints.MapHub<TeacherHub>("/teacherHub");
            });
        }
    }
}
