using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExam.Model.Model
{
    public class CheckExamModel
    {
        public int question1Id { get; set; }
        public int question2Id { get; set; }
        public int question3Id { get; set; }
        public int question4Id { get; set; }

        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
    }
}
