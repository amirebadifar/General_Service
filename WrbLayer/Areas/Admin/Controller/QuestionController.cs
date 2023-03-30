using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    public class QuestionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [Route("/admin/questions")]
        public async Task<IActionResult> ViewQuestion(bool? Ok)
        {
            var Questions = await _questionService.GetAllQuestionAsync();

            ViewBag.Message = Ok!;

            return View("QuestionView",Questions);
        }

        [Route("/admin/delete/question/{Id}")]
        public IActionResult DeleteQuestion(int Id)
        {
            bool OkDelete;

            OkDelete =  _questionService.DeleteQuestionAsync(Id).Result;

            return RedirectToAction("ViewQuestion", "Question", new
            {
                Ok = OkDelete
            });
        }

        [HttpPost("/admin/add/question")]
        public async Task<IActionResult> AddQuestion(AddQuestionViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("ViewQuestion", new { Ok = false });

            bool OkAdd;

            try
            {

                await _questionService.AddQuestionAsync(model);

                OkAdd = true;
            }
            catch
            {
                OkAdd = false;
            }

            return RedirectToAction("ViewQuestion", "Question", new
            {
                Ok = OkAdd
            });
        }

    }
}
