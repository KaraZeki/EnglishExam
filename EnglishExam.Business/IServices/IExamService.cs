using EnglishExam.Model.Concrete;
using EnglishExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExam.Business.IServices
{
    public interface IExamService
    {
        public UserReturnModel CreateMultipleExam(QuestionsModel questionsModel);
        public List<Exam> GetExamList();
        public UserReturnModel DeleteExam(int id);

        public ExamViewModel GetAllQuestions(int rowNumber);
        public List<CheckExamReturnModel> CheckExam(CheckExamModel model);
    }
}
