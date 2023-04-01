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
    public interface IWorkSampleService
    {
        Task<List<WorkSampleTable>> GetAllWorkSamplesAsync();
        Task<WorkSampleTable> GetWorkSamplesAsync(int Id);
        Task<bool> DeleteWorkSample(int Id);
        Task<int> AddWorkSample(WorkSampleViewModel workSampleViewModel);
        Task<bool> EditWorkSample(WorkSampleViewModel workSampleViewModel);
        Task<WorkSampleViewModel> GetWorkSamplesByID(int Id);
        Task<int> CountWorkSampleAsync();
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

        public async Task<bool> DeleteWorkSample(int Id)
        {
            try
            {
                var worksample = _context.WorkSamples.Single(w => w.Id == Id);
                _context.WorkSamples.Remove(worksample);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<int> AddWorkSample(WorkSampleViewModel workSampleViewModel)
        {
            try
            {
                var worksample = new WorkSampleTable()
                {
                    Title = workSampleViewModel.Title,
                    CreateTime = workSampleViewModel.CreateTime,
                };
                _context.WorkSamples.Add(worksample);
                await _context.SaveChangesAsync();
                return worksample.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<bool> EditWorkSample(WorkSampleViewModel workSampleViewModel)
        {
            try
            {
                var worksample = _context.WorkSamples.FirstOrDefault(w => w.Id == workSampleViewModel.Id);
                worksample.Title = workSampleViewModel.Title;
                worksample.CreateTime = workSampleViewModel.CreateTime;
                _context.WorkSamples.Update(worksample);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<WorkSampleViewModel> GetWorkSamplesByID(int Id)
        {
            var worksample = _context.WorkSamples.First(w => w.Id == Id);
            return new WorkSampleViewModel()
            {
                Title = worksample.Title,
                CreateTime = worksample.CreateTime,
                Id = Id
            };
        }

        public async Task<int> CountWorkSampleAsync()
        {
            return _context.WorkSamples.Count();
        }
    }
}
