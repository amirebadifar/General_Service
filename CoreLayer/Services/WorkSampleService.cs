using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IWorkSampleService
    {
        Task<List<WorkSampleTable>> GetAllWorkSamplesAsync();
    }

    public class WorkSampleService : IWorkSampleService
    {
        private DB_Context _context;

        public WorkSampleService(DB_Context context)
        {
            _context = context;
        }


        public async Task<List<WorkSampleTable>> GetAllWorkSamplesAsync()
        {
            return _context.WorkSamples.ToList();
        }
    }
}
