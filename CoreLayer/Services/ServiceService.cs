using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IServiceService
    {
        Task<List<ServiceTable>> GetAllServiceAsync();
        Task<List<ServiceTable>> GetGalleryServiceAsync();
        Task<ServiceTable> GetServiceAsync(int idService);
    }

    public class ServiceService : IServiceService
    {
        private DB_Context _context;

        public ServiceService(DB_Context context)
        {
            _context = context; 
        }  

        public async Task<List<ServiceTable>> GetAllServiceAsync()
        {
            return _context.Services.ToList();
        }

        public async Task<List<ServiceTable>> GetGalleryServiceAsync()
        {
            return _context.Services.Where(s => s.OkGallery == true).Take(3).ToList();
        }

        public async Task<ServiceTable> GetServiceAsync(int idService)
        {
            return _context.Services.SingleOrDefault(s => s.Id == idService)!;
        }
    }
}
