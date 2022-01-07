using EnglishExam.Business.IServices;
using EnglishExam.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishExam.Web.UI.Controllers
{
    public class ExamListController : Controller
    {
        private readonly IExamService _examService;
        public ExamListController(IExamService examService)
        {
            _examService = examService; 
        }
        public IActionResult Index( )
        {
            var result = _examService.GetExamList();
            var examView = new ExamListModel()
            {
                Exams = result,
            };
            return View(examView);
        }

        [HttpPost]
        public IActionResult DeleteExam(int id)
        {
            var entity = _examService.DeleteExam(id);

            //TempData.Add("DeleeteMessage", new ResultMessage()
            //{
            //    Title = "Silme başarılı",
            //    Message = "Silme işlemi başarılı bir şekilde gerçekleşti",
            //    Css = "warning"
            //});
            return RedirectToAction("Index", "ExamList");
        }
    }
}
