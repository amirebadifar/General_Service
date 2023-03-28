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
        Task<WorkSampleTable> GetWorkSamplesAsync(int Id);
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

        public async Task<WorkSampleTable> GetWorkSamplesAsync(int Id)
        {
            return _context.WorkSamples.SingleOrDefault(w => w.Id == Id)!;
        }
    }
}
