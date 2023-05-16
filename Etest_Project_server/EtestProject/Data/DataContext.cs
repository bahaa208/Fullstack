
using EtestProject.Models;

using Microsoft.EntityFrameworkCore;
 

namespace EtestProject.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
        /*
         * to build data base for Exam, Question ,Grade Answer Errors
         * */

        public DbSet<User_student> UserStudentTable { get; set; }
        public DbSet<User_teacher> UserTeacherTable{ get; set; }
        public DbSet<Test> TestTable { get; set; }
        public DbSet<Question> QuestionTable { get; set; }
        public DbSet<Answer> AnswerTable { get; set; }
        public DbSet<Grade> GradeTable { get; set; }
        public DbSet<Errors> ErrorsTable { get; set; }

       /*
        Exam has many question and question has many answers
       grade has many Errors
       to build the table
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_student>()
                .HasMany(t => t.grades)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User_teacher>()
                .HasMany(t => t.tests)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasMany(t => t.AllQuestionInTest)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(t => t.listAnswer)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
                .HasMany(t => t.listOfErrors)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
