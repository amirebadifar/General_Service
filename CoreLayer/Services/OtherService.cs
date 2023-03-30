using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IOtherService
    {
        Task<string> GetGuid();
    }
    public class OtherService : IOtherService
    {
        public async Task<string> GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
