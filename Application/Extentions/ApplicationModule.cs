
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extentions
{
    public static class ApplicationModule
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            ////---------------------------Fluent Validation For Department (DI)----------------------
            //services.AddScoped<IValidator<DepartmentForCreateDto>, CreateDepartmentValidator>();
            //services.AddScoped<IValidator<DepartmentForUpdateDto>, UpdateDepartmentValidator>();


            ////---------------------------Fluent Validation For Employee (DI)----------------------
            //services.AddScoped<IValidator<EmployeeForUpdateDto>, EmployeeForUpdateValidator>();
            //services.AddScoped<IValidator<EmployeeForCreateDto>, EmployeeForCreateValidator>();

            
            //----------------AutoMapper-------------//
            //builder.Services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        }
    }
}
