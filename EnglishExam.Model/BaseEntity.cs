using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishExam.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public decimal IsDeleted { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
