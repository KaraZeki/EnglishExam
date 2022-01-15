using EnglishExam.Model.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EnglishExam.DataAccess.Context
{
    public class EnglishExamDbContext : DbContext
    {
        public EnglishExamDbContext(DbContextOptions<EnglishExamDbContext> options) : base(options)
        {
        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamList> ExamLists { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamList>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Exam>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd(); 
            
            modelBuilder.Entity<Exam>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
