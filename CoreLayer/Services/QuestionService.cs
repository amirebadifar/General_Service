using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ViewModel.Admin;
using DataLayer;
using DataLayer.Table;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.Services
{
    public interface IQuestionService
    {
        Task<List<QuestionsTable>> GetAllQuestionAsync();
        Task<bool> DeleteQuestionAsync(int questionId);
        Task<int> AddQuestionAsync(AddQuestionViewModel model);
    }

    public class QuestionService : IQuestionService
    {
        private DB_Context _context;

        public QuestionService(DB_Context context)
        {
            _context = context;
        }

        public async Task<List<QuestionsTable>> GetAllQuestionAsync()
        {
            return _context.Questions.ToList();
        }

        public async Task<bool> DeleteQuestionAsync(int questionId)
        {
            try
            {
                var Question = await _context.Questions
                    .SingleAsync(q => q.Id == questionId);

                _context.Questions.Remove(Question);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> AddQuestionAsync(AddQuestionViewModel model)
        {
            var table = new QuestionsTable()
            {
                Questions = model.Question,
                Response = model.Response
            };

            await _context.Questions.AddAsync(table);

            return await _context.SaveChangesAsync();

        }
    }
}
