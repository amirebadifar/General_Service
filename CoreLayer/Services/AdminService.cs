using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace CoreLayer.Services
{
    public interface IAdminService
    {
        Task<bool> IsLogin(string numberphone, string password);
    }

    public class AdminService: IAdminService
    {
        private DB_Context _context;

        public AdminService(DB_Context context)
        {
            _context = context;
        }

        public async Task<bool> IsLogin(string numberphone, string password)
        {
            return _context.Admin.Any(a => a.NumberPhone == numberphone && a.password == password);
        }
    }
}
