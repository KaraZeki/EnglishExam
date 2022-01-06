using EnglishExam.Business.IServices;
using EnglishExam.DataAccess.Repository;
using EnglishExam.Model.Concrete;
using EnglishExam.Model.Model;
using System.Collections.Generic;

namespace EnglishExam.Business.Services
{
    public class ExamService : IExamService
    {
        private readonly IGenericRepository<Exam> _examRepository;
        public ExamService(IGenericRepository<Exam> examRepository)
        {
            _examRepository= examRepository;
        }

        public UserReturnModel CreateMultipleExam(QuestionsModel model)
        {
            var userReturnModel= new UserReturnModel();
            userReturnModel.IsOk = false;
            try
            {
                var exam = new Exam();
                exam.Title = model.Title;
                exam.CreatedDate = System.DateTime.Now;

                List<ExamList> examLists = new List<ExamList>();
                //Question 1
                examLists.Add(new ExamList()
                {
                    Question = model.Questin1,
                    OptionA = model.OptionA1,
                    OptionB = model.OptionB1,
                    OptionC = model.OptionC1,
                    OptionD = model.OptionD1,
                    CorrectAnswer = model.Answer1
                });

                //Question 2
                examLists.Add(new ExamList()
                {
                    Question = model.Questin2,
                    OptionA = model.OptionA2,
                    OptionB = model.OptionB2,
                    OptionC = model.OptionC2,
                    OptionD = model.OptionD2,
                    CorrectAnswer = model.Answer2
                });

                //Question 3
                examLists.Add(new ExamList()
                {
                    Question = model.Questin3,
                    OptionA = model.OptionA3,
                    OptionB = model.OptionB3,
                    OptionC = model.OptionC3,
                    OptionD = model.OptionD3,
                    CorrectAnswer = model.Answer3
                });

                //Question 4
                examLists.Add(new ExamList()
                {
                    Question = model.Questin4,
                    OptionA = model.OptionA4,
                    OptionB = model.OptionB4,
                    OptionC = model.OptionC4,
                    OptionD = model.OptionD4,
                    CorrectAnswer = model.Answer4
                });

                exam.ExamLists = examLists;
                _examRepository.Add(exam);

                userReturnModel.IsOk= true;
                userReturnModel.Message= "Exam has succesfully created!";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return userReturnModel;

           
        }
    }
}
