using EnglishExam.Model.Concrete;
using System.Collections.Generic;

namespace EnglishExam.Model.Model

{
    public class ExamViewModel
    {
        public Exam Exam { get; set; }
        public List<ExamList> ExamLists { get; set; }
    }
}
