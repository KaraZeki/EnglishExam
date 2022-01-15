using EnglishExam.Business.IServices;
using EnglishExam.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishExam.Web.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IExamService _examService;
        private readonly ICommonService _commonService;
        public HomeController(IExamService examService, ICommonService commonService)
        {
            _examService = examService;
            _commonService = commonService;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View();
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWebsiteData() => Ok(_commonService.GetWebsiteData());
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWebBlogText(string link) => Ok(_commonService.GetWebBlogText(link));
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateExam(QuestionsModel questionsModel)
        {
            var result = _examService.CreateMultipleExam(questionsModel);
            if (result.IsOk)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
