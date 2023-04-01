using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ViewModel;
using CoreLayer.ViewModel.Admin;
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
        Task<int> CountInsertServiceAsync();

        Task<bool> DeleteService(int id);
        Task<ServiceViewModel> GetServiceByID(int id);
        Task<bool> EditService(ServiceViewModel Service);
        Task<int> AddService(ServiceViewModel Service);
        Task<int> CountServiceAsync();
    }

    public class ServiceService : IServiceService
    {
        private DB_Context _context;
        private IServiceService _serviceServiceImplementation;

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

        public async Task<int> CountInsertServiceAsync()
        {
            return _context.InsertServices.Count();
        }

        public async Task<bool> DeleteService(int id)
        {
            try
            {
                var servise = await _context.Services.SingleAsync(s=>s.Id == id);
                _context.Services.Remove(servise);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ServiceViewModel> GetServiceByID(int id)
        {
            var servise = await _context.Services.SingleOrDefaultAsync(s=>s.Id == id);
            return new ServiceViewModel()
            {
                Id = servise.Id,
                Title = servise.Title,
                Descripton = servise.Descripton,
                OkGallery = servise.OkGallery,
            };
        }

        public async Task<bool> EditService(ServiceViewModel Service)
        {
            try
            {
                var Mainservise = _context.Services.FirstOrDefault(s=>s.Id == Service.Id);
                Mainservise.OkGallery = Service.OkGallery;
                Mainservise.Descripton = Service.Descripton;
                Mainservise.Title = Service.Title;
                _context.Services.Update(Mainservise);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<int> AddService(ServiceViewModel Service)
        {
            try
            {
                var servise = new ServiceTable()
                {
                    Title = Service.Title,
                    Descripton = Service.Descripton,
                    OkGallery = Service.OkGallery
                };
                _context.Services.Add(servise);
                await _context.SaveChangesAsync();
                return servise.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<int> CountServiceAsync()
        {
            return _context.Services.Count();
        }
    }
}
