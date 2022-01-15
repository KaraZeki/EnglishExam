using EnglishExam.Business.IServices;
using EnglishExam.DataAccess.Repository;
using EnglishExam.Model.Concrete;
using EnglishExam.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace EnglishExam.Business.Services
{
    public class ExamService : IExamService
    {
        private readonly IGenericRepository<Exam> _examRepository;
        private readonly IGenericRepository<ExamList> _examListRepository;
        public ExamService(IGenericRepository<Exam> examRepository, IGenericRepository<ExamList> examListRepository)
        {
            _examRepository= examRepository;
            _examListRepository = examListRepository;
        }

        public List<CheckExamReturnModel> CheckExam(CheckExamModel model)
        {
            var list =new List<CheckExamReturnModel>();

            //1
            var question1 = _examListRepository.GetById(model.question1Id);
            if (question1.CorrectAnswer==model.answer1)
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = true,
                    CorrectAnswer = question1.CorrectAnswer,
                    UserAnswer = model.answer1,
                    questionId = question1.Id
                });
            }
            else
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = false,
                    CorrectAnswer = question1.CorrectAnswer,
                    UserAnswer = model.answer1,
                    questionId = question1.Id
                });
            }

            //2
            var question2 = _examListRepository.GetById(model.question2Id);

            if (question2.CorrectAnswer == model.answer2)
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = true,
                    CorrectAnswer = question2.CorrectAnswer,
                    UserAnswer = model.answer2,
                    questionId = question2.Id
                });
            }
            else
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = false,
                    CorrectAnswer = question2.CorrectAnswer,
                    UserAnswer = model.answer2,
                    questionId = question2.Id
                });
            }

            //3
            var question3 = _examListRepository.GetById(model.question3Id);
            if (question3.CorrectAnswer == model.answer3)
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = true,
                    CorrectAnswer = question3.CorrectAnswer,
                    UserAnswer = model.answer3,
                    questionId = question3.Id
                });
            }
            else
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = false,
                    CorrectAnswer = question3.CorrectAnswer,
                    UserAnswer = model.answer3,
                    questionId = question3.Id
                });
            }


            //4
            var question4 = _examListRepository.GetById(model.question4Id);
            if (question4.CorrectAnswer == model.answer4)
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = true,
                    CorrectAnswer = question4.CorrectAnswer,
                    UserAnswer = model.answer4,
                    questionId = question4.Id
                });
            }
            else
            {
                list.Add(new CheckExamReturnModel()
                {
                    IsCorrect = false,
                    CorrectAnswer = question4.CorrectAnswer,
                    UserAnswer = model.answer4,
                    questionId = question4.Id
                });
            }
            return list;
        }

        public UserReturnModel CreateMultipleExam(QuestionsModel model)
        {
            var userReturnModel= new UserReturnModel();
            userReturnModel.IsOk = false;
            try
            {
                var exam = new Exam();
                exam.Title = model.Title;
                exam.ExamText= model.ExamText;
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

        public UserReturnModel DeleteExam(int id)
        {
            var returnModel = new UserReturnModel();
            returnModel.IsOk = false;    
            var exam = _examRepository.GetById(id);
            if (exam != null)
            {
                exam.IsDeleted = 1;
                _examRepository.Update(exam);
                returnModel.IsOk = true;
                returnModel.Message = "Exam has deleted";
            }
            return returnModel;
        }

        public ExamViewModel GetAllQuestions(int rowNumber=0)
        {
            try
            {
                var examViewModel = new ExamViewModel();
                var result = _examRepository.Get(x=>x.IsDeleted!=1, null, "ExamLists").Skip(rowNumber).Take(1).FirstOrDefault();
                if (result is null)
                {
                    return null;
                }
                examViewModel.Exam = result;
                examViewModel.ExamLists = result.ExamLists.ToList();
                examViewModel.ExamIds=_examRepository.Get(x => x.IsDeleted != 1).Select(x=>x.Id).ToList();
                return examViewModel;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
          
        }

        public List<Exam> GetExamList() => _examRepository.Get(x => x.IsDeleted != 1).ToList();
      
    }
}
