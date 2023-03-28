using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IContactService
    {
        Task<ContactTable> GetContactAsync();
    }

    public class ContactService: IContactService
    {
        private DB_Context _context;

        public ContactService(DB_Context context)
        {
            _context = context;
        }

        public async Task<ContactTable> GetContactAsync()
        {
            return _context.Contacts.SingleOrDefault()!;
        }
    }
}
