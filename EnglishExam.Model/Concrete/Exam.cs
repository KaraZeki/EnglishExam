using System.Collections.Generic;

namespace EnglishExam.Model.Concrete
{
    public class Exam : BaseEntity
    {
        public string Title { get; set; }
        public string ExamText { get; set; }

        public IEnumerable<ExamList> ExamLists { get; set; }
    }
}
