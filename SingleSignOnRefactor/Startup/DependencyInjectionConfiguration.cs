using System;
using System.Reflection;
using MediatR;
using SingleSignOnRefactor.DataAccess;
using SingleSignOnRefactor.DataContext;
using SingleSignOnRefactor.Helpers;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.Startup
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Mapping));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton<IDapperContext>(dapper => new DapperContext(configuration));
            services.AddTransient<ISingleSignOnUserRepository, SingleSignOnUserRepository>();
            services.AddTransient<IDataAccessEngine, DataAccessEngine>();
            return services;
        }
    }
}

