using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExam.Model.Model
{
    public class CheckExamReturnModel
    {
        public int questionId { get; set; }
        public bool IsCorrect { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }


    }
}
