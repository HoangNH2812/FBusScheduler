using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;
using Team6._FbusSchedule_.Repository.IRepositories;
using Team6._FbusSchedule_.Repository.Repository;

namespace Team6._FbusSchedule_.Repository.Data;

public interface IUnitOfWork
{
    IBusRepository _busRepository { get; }
    ICustomerRepository _customerRepository { get; }
    IDriverRepository _driverRepository { get; }
    IRouteRepository _routeRepository { get; }
    IStationRepository _stationRepository { get; }

    Task SaveChangeAsync();
    void Dispose();
}
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private PostgresContext _postgresContext;
    public IBusRepository _busRepository { get; }
    public ICustomerRepository _customerRepository { get; }
    public IDriverRepository _driverRepository { get; }
    public IRouteRepository _routeRepository { get; }
    public IStationRepository _stationRepository { get; }

    public UnitOfWork(PostgresContext postgresContext
        , IBusRepository busRepository, ICustomerRepository customerRepository
        , IDriverRepository driverRepository, IRouteRepository routeRepository
        , IStationRepository stationRepository)
    {
        _postgresContext = postgresContext;
        _busRepository = busRepository;
        _customerRepository = customerRepository;
        _driverRepository = driverRepository;
        _routeRepository = routeRepository;
        _stationRepository = stationRepository;
    }

    //public GenericRepository<Brand, int> BrandRepository
    //{
    //    get
    //    {
    //        return (GenericRepository<Brand, int>)_brandRepository;
    //    }
    //}


    //public GenericRepository<Category, int> CategoryRepository
    //=> (GenericRepository<Category, int>)_categoryRepository;

    //public GenericRepository<Product, Guid> ProductRepository
    //=> (GenericRepository<Product, Guid>)_productRepository;

    public async Task SaveChangeAsync()
    {
        await _postgresContext.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _postgresContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

