using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ViewModel;
using DataLayer;
using DataLayer.Table;
using FixedTextHelper;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.Services
{
    public interface IServiceService
    {
        Task<List<ServiceTable>> GetAllServiceAsync();
        Task<List<ServiceTable>> GetGalleryServiceAsync();
        Task<ServiceTable> GetServiceAsync(int idService);
        Task<int> AddInsertServiceAsync(InsertServicePartialViewModel model);

        Task<List<InsertServiceTable>> getAllInsertServiceAsync();
        Task<bool> DeleteInsertServiceAsync(int Id);
        Task<InsertServiceTable> GetInsertServiceByIdAsync(int id);

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

        public async Task<int> AddInsertServiceAsync(InsertServicePartialViewModel model)
        {
            var table = new InsertServiceTable()
            {
                FullName = model.FullName,
                Addres = model.Addres,
                NumberHome = model.NumberHome,
                NumberPhone = model.NumberPhone,
                ServiceId = model.ServiceId,
                Addres_X = model.Addres_X,
                Addres_Y = model.Addres_Y,
                CreateTime = DateTime.Now
            };

            await _context.InsertServices.AddAsync(table);
            int Id = await _context.SaveChangesAsync();

            return Id;
        }

        public async Task<List<InsertServiceTable>> getAllInsertServiceAsync()
        {
            return _context.InsertServices.ToList();
        }

        public async Task<bool> DeleteInsertServiceAsync(int Id)
        {
            try
            {
                var InsertService = await _context.InsertServices.SingleAsync(i => i.Id == Id);

                InsertService.IsDelete = true;

                _context.Update(InsertService);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InsertServiceTable> GetInsertServiceByIdAsync(int id)
        {
            return await _context.InsertServices.SingleAsync(i => i.Id == id);
        }
    }
}
