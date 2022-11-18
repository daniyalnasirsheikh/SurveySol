using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SV.Business.Implementation;
using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using SV.WebApp.HTTPHelpers.Implementation;
using SV.WebApp.HTTPHelpers.Interfaces;
using SV.WebApp.Models;
using SV.WebApp.Services;

namespace SV.WebApp
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(5);
            });
            services.AddDbContextPool<SVDBContext>(
                   options => options.UseSqlServer(Configuration.GetConnectionString("SVDB"))
               );
            services.AddDNTCaptcha(options =>
                    options.UseCookieStorageProvider()
                    .ShowThousandsSeparators(false).WithEncryptionKey("123456"));
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<SVDBContext>()
            //    .AddDefaultTokenProviders();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
            .AddEntityFrameworkStores<SVDBContext>()
            .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddScoped<IRepository<Survey>, Repository<Survey>>();
            services.AddScoped<IRepository<Question>, Repository<Question>>();
            services.AddScoped<IRepository<Answer>, Repository<Answer>>();
            services.AddScoped<IRepository<SurveyResponseProfile>, Repository<SurveyResponseProfile>>();
            services.AddScoped<IRepository<EmailTemplate>, Repository<EmailTemplate>>();
            services.AddScoped<IRepository<SurveySharedWithCustomers>, Repository<SurveySharedWithCustomers>>();
            services.AddScoped<IRepository<UserLogs>, Repository<UserLogs>>();
            services.AddScoped<IRepository<Departments>, Repository<Departments>>();
            services.AddScoped<IRepository<UserDepartments>, Repository<UserDepartments>>();

            services.AddScoped<IUserShareSurveyRepository, UserShareSurveyRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ISurveyResponseProfileRepository, SurveyResponseProfileRepository>();
            services.AddScoped<iEmailRepository, EmailRepository>();
            services.AddScoped<IUsersLogRepository, UsersLogRepository>();
            services.AddScoped<iDepartmentRepository, DepartmentRepository>();
            services.AddScoped<iUserDepartmentRepository, UserDepartmentRepository>();

            services.AddScoped<FileService>();
            services.AddScoped<EmailService>();

            services.ConfigureApplicationCookie(options =>
            {

                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Account}/{action=DefaultPage}/{id?}");
                    pattern: "{controller=Account}/{action=Login}/{id?}");
        });
        }
    }
}
