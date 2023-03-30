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
    public interface IContactService
    {
        Task<ContactTable> GetContactAsync();
        Task<bool> UpdateContact(ContactViewModel contactViewModel);
    }

    public class ContactService : IContactService
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

        public async Task<bool> UpdateContact(ContactViewModel contactViewModel)
        {
            try
            {
               var contect = _context.Contacts.SingleOrDefault();
               contect.Addres = contactViewModel.Addres;
               contect.Addres_X = contactViewModel.Addres_X;
               contect.Addres_Y = contactViewModel.Addres_Y;
               contect.Numberphone = contactViewModel.Numberphone;
               _context.Contacts.Update(contect);
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
