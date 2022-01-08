using EnglishExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExam.Business.IServices
{
    public interface ICommonService
    {
        public List<HomePageModel> GetWebsiteData();
        public string GetWebBlogText(string path);
    }
}
