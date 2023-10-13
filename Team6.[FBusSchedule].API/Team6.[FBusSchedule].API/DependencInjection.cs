using Microsoft.EntityFrameworkCore;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;

namespace Team6._FBusSchedule_.API
{
    public static class DependencInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgresContext>(option =>
            option.UseNpgsql("Username=postgres;Password=mwJvgQqPzjhXwWrb;Server=db.lnyxdixalclqvtxigwnl.supabase.co;Port=5432;Database=postgres"));

            #region entity
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IBusRepository, BusRepository>();
            services.AddTransient<IBusService, BusService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IDriverService, DriverService>();

            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IRouteService, RouteService>();

            services.AddTransient<IStationRepository, StationRepository>();
            services.AddTransient<IStationService, StationService>();

            #endregion
            return services;
        }
    }
}
