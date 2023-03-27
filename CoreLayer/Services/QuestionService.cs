using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Table;

namespace CoreLayer.Services
{
    public interface IQuestionService
    {
        Task<List<QuestionsTable>> GetAllQuestionAsync();
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
    }
}
