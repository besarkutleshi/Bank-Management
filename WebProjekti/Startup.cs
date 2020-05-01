using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebProjekti.Security;
using DataAccessLayer;
using DataAccessLayer.Persons;
using DataAccessLayer.Departaments;
using EntityLayer.Entity;
using DataAccessLayer.Cards;

namespace WebProjekti
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
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BankManagment")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Administration/AccessDenied");
                options.LoginPath = "/Account/Login";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EditRolePolicy", policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequriment()));
                //options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
            });


            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<DepartamentRepository>();
            services.AddScoped<ClientRepository>();
            services.AddScoped<CheckingAccountRepository>();

            services.AddSingleton<DataProtectionPurposeStrings>();

            services.AddDistributedMemoryCache();
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "984531681903-8jgigq1jeiqegiej0adj3aqk85lksa4k.apps.googleusercontent.com";
                options.ClientSecret = "mmgdqA5b2G7-CKqtVoe5c-XL";
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
