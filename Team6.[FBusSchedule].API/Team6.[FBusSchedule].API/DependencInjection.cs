using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Team6._FbusSchedule_.Repository.Data;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Repository.Repositories;
using Team6._FbusSchedule_.Repository.Repository;
using Team6._FbusSchedule_.Service.IServices;
using Team6._FbusSchedule_.Service.Service;
using Team6._FbusSchedule_.Service.Services;

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

            services.AddTransient<ITicketRepository, TicketRepository>(); 
            services.AddTransient<ITicketService, TicketService>();

            services.AddTransient<ITripRepository, TripRepository>();
            services.AddTransient<ITripService, TripService>();

            services.AddTransient<IDetailTripRepository, DetailTripRepository>();
            services.AddTransient<IDetailTripService, DetailTripService>();

            services.AddTransient<IRoutationRepository, RoutationRepository>();
            services.AddTransient<IRoutationService, RoutationService>();

            services.AddTransient<ITicketStationRepository, TicketStationRepository>();
            services.AddTransient<ITicketStationService, TicketStationService>();

            services.AddScoped<_FbusSchedule_.Service.IServices.IAuthenticationService, _FbusSchedule_.Service.Services.AuthenticationService>();
            #endregion
            return services;
        }
    }
}
