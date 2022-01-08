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
        public IActionResult Index()
        {
            ////WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create("https://www.wired.com/");

            ////WebResponse GelenCevap = SiteyeBaglantiTalebi.GetResponse();

            ////StreamReader CevapOku = new StreamReader(GelenCevap.GetResponseStream());

            ////string KaynakKodlar = CevapOku.ReadToEnd();

            ////int IcerikBaslangicIndex = KaynakKodlar.IndexOf("<h2>") +2;

            ////int IcerikBitisIndex = KaynakKodlar.Substring(IcerikBaslangicIndex).IndexOf("SummaryItemHed");
            ////var res = KaynakKodlar.Substring(IcerikBaslangicIndex, IcerikBitisIndex);

            //Uri url = new Uri("https://www.wired.com/");

            //WebClient webClient = new WebClient();
            //string html=webClient.DownloadString(url);
            //HtmlAgilityPack.HtmlDocument document=new HtmlAgilityPack.HtmlDocument();
            //document.LoadHtml(html);
            //HtmlNodeCollection htmlNodes = document.DocumentNode.SelectNodes("//div[@class='summary-item__content']/a");//div[@class='summary-list__items']//div[@class='summary-item__content']/a[@class='summary-item-tracking__hed-link']/h2[@class='summary-item__hed']
            //List<string> titles=new List<string>();
            //List<string> links=new List<string>();

            //foreach (var  node in htmlNodes)
            //{
            //    string link = node.Attributes["href"].Value;
            //    titles.Add(node.InnerText);
            //    links.Add(link);
            //}

            //List<string> Texts=new List<string>();
            //var newLinks = links.Take(3);
            //foreach (var link in newLinks)
            //{
            //    List<string> TextsClause = new List<string>();
            //    Uri urlForText = new Uri("https://www.wired.com"+ link);

            //    WebClient webClientForText = new WebClient();
            //    string htmlFortext = webClientForText.DownloadString(urlForText);
            //    HtmlAgilityPack.HtmlDocument documentForText = new HtmlAgilityPack.HtmlDocument();
            //    documentForText.LoadHtml(htmlFortext);
            //    HtmlNodeCollection htmlNodesForText = documentForText.DocumentNode.SelectNodes("//div[@class='body__inner-container']/p");

            //    foreach (var node in htmlNodesForText)
            //    {
            //        TextsClause.Add(node.InnerText);
            //    }
            //    Texts.Add(string.Join(" ",TextsClause));
            //}




            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWebsiteData()
        {
            var resultList = _commonService.GetWebsiteData();
            return Ok(resultList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWebBlogText(string link)
        {
            var result = _commonService.GetWebBlogText(link);
            return Ok(result);
        }

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
