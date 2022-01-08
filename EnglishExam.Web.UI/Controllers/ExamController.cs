using EnglishExam.Business.IServices;
using EnglishExam.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishExam.Web.UI.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService= examService;
        }
        public IActionResult Index(int id=0)
        {
            var  model=_examService.GetAllQuestions(id);
            if (model!=null)
            {
                return View(model);
            }
            return View(null);
        }

        [HttpGet]
        public IActionResult CheckExam(CheckExamModel model)
        {
            var checkExams = _examService.CheckExam(model);
            if (checkExams != null)
            {
                return Ok(checkExams);
            }
            return BadRequest(null);
        }
    }
}
