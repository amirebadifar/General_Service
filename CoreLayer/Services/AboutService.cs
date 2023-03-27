using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IAboutService
    {
        Task<AboutTable> GetAboutAsync();
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
    }
}
