using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ViewModel.Admin;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IAboutService
    {
        Task<AboutTable> GetAboutAsync();
        Task<bool> UpdateAbout(AboutViewModel About);
    }

    public class AboutService : IAboutService
    {
        private DB_Context _context;

        public AboutService(DB_Context context)
        {
            _context = context;
        }

        public async Task<AboutTable> GetAboutAsync()
        {
            return _context.About.SingleOrDefault()!;
        }

        public async Task<bool> UpdateAbout(AboutViewModel About)
        {
            try
            {
                var q = _context.About.SingleOrDefault();
                q.Title = About.Title;
                q.Description = About.Description;
                _context.About.Update(q);
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
