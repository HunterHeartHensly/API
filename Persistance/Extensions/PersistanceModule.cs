using Application.Contract.Auth;
using Application.Contract.StudentManagement;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using Persistance.Repository.Auth;
using Persistance.Repository.StudentManagement;
using System.Text;

namespace Persistance.Extentions
{
    public static class PersistanceModule
    {
        public static void ConfigurePersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            //----------------Connection String-------------//
            services.AddDbContext<RepositoryContext>(optionns =>
            optionns.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            //----------------For Identity-------------//
            services.AddIdentity<ApplicationUser, IdentityRole>
                (options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultTokenProviders()

            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();


           services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
           );

            //Inject AppSettings
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));


            //----------------------------Jwt Authentication----------------------------

            var key = Encoding.UTF8.GetBytes(configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });


            //services cors
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));



            //----------------Auth---Register & Login (DI)----------//
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            //--------------Student Management System-------------//
            services.AddScoped<IStudentRepository, StudentRepository>();



            //--------------Identity Roles-------------//
            services.AddScoped<IRoleRepository, RoleRepository>();

            //--------------Acadiamia Program-------------//
            services.AddScoped<IProgramRepository, ProgramRepository>();

            //--------------Student Status-------------//
            services.AddScoped<IStatusRepository, StatusRepository>();

        }
    }
}
