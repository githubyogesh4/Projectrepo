using System.IO;
using System.Text;
using AutoMapper;
using BusinessService.Implementation;
using BusinessService.Interface;
using MallWebAPI.Extension;
using MallWebAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Repositories.dbContext;
using Repositories.Implementation;
using Repositories.Interface;

namespace MallWebAPI
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
            services.AddControllers();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            var connection = Configuration.GetConnectionString("SqlConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            ServiceConfig.AddExtensionServices(services);
            services.AddAutoMapper(typeof(Startup));

            //configure appsetting
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Registered Repositories here
           
            services.AddScoped(typeof(IContactUsRepository), typeof(ContactUsRepository));
            services.AddScoped(typeof(ICustomerMasterRepository), typeof(CustomerMasterRepository));
           
            // Registred Services here
          
            services.AddScoped(typeof(IContactUsServices), typeof(ContactUsService));
            services.AddScoped(typeof(ICustomerMasterServices), typeof(CustomerMasterService));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceConfig.AddConfigure(app);
            app.UseFileServer();
            app.UseAuthentication();

            // To Save and fetch Images
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/Images")
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Users")),
                RequestPath = new PathString("/Users")
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
