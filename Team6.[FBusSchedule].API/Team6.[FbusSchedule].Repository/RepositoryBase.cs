using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly PostgresContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase()
        {
            _context = new PostgresContext();
            _dbSet = _context.Set<T>();
        }

        // Retrieve a Product
        public async Task<T> RetrieveProduct(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Create a Product
        public void CreateProduct(T product)
        {
            _dbSet.Add(product);
            _context.SaveChanges();
        }

        // Update a Product
        public void UpdateProduct(T product)
        {
            _dbSet.Update(product);
            _context.SaveChanges();
        }

        // Delete a Product
        public void DeleteProduct(long id)
        {
            var product = _dbSet.Find(id);
            if (product != null)
            {
                _dbSet.Remove(product);
                _context.SaveChanges();
            }
        }

        // List Products
        public IQueryable<T> ListProducts()
        {
            return _dbSet;
        }

        // Count Products
        public int CountProducts()
        {
            return _dbSet.Count();
        }
    }
}
