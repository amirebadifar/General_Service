using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ViewModel;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IProductService
    {
        Task<List<ProductTable>> GetAllProductAsync();
        Task<List<ProductTable>> GetProductByNameAsync(string nameProduct);
        Task<List<ProductTable>> GetNewProductAsync();
        Task<ProductTable> GetProductAsync(int id);
        Task<int> AddInsertProductAsync(InsertProductPartialViewmodel product);
        Task<bool> DeleteProduct(int id);
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

        public async Task<List<ProductTable>> GetProductByNameAsync(string nameProduct)
        {
            return _context.Products.Where(p => p.Name.Contains(nameProduct)).ToList();
        }

        public async Task<List<ProductTable>> GetNewProductAsync()
        {
            return _context.Products.OrderByDescending(p => p.Id).Take(8).ToList();
        }

        public async Task<ProductTable> GetProductAsync(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id)!;
        }

        public async Task<int> AddInsertProductAsync(InsertProductPartialViewmodel product)
        {
            InsertProductTable table = new InsertProductTable()
            {
                Addres = product.Addres,
                Addres_X = product.Addres_X,
                Addres_Y = product.Addres_Y,
                FullName = product.FullName,
                IdProduct = product.IdProduct,
                NumberHome = product.NumberHome,
                numberPhone = product.NumberPhone,
                CreateTime = DateTime.Now
            };

            await _context.InsertProducts.AddAsync(table);
            int Id = await _context.SaveChangesAsync();

            return Id;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var Product =_context.Products.FirstOrDefault(p => p.Id == id);
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
