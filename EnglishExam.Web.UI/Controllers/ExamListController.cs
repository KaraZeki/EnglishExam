using EnglishExam.Business.IServices;
using EnglishExam.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishExam.Web.UI.Controllers
{

    [Authorize]
    public class ExamListController : Controller
    {
        private readonly IExamService _examService;
        public ExamListController(IExamService examService)
        {
            _examService = examService; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index( )
        {
            var result = _examService.GetExamList();
            var examView = new ExamListModel()
            {
                Exams = result,
            };
            return View(examView);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteExam(int id)
        {
            var entity = _examService.DeleteExam(id);
            
            return RedirectToAction("Index", "ExamList");
        }
    }
}
