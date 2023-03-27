using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IProductService
    {
        Task<List<ProductTable>> GetAllProductAsync();
        Task<List<ProductTable>> GetNewProductAsync();
    }

    public class ProductService : IProductService
    {
        private DB_Context _context;

        public ProductService(DB_Context context)
        {
            _context = context;
        }

        public async Task<List<ProductTable>> GetAllProductAsync()
        {
            return _context.Products.ToList();
        }

        public async Task<List<ProductTable>> GetNewProductAsync()
        {
            return _context.Products.OrderByDescending(p => p.Id).Take(8).ToList();
        }
    }
}
