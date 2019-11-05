using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Concrete.EntityFramework.Mappings;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework
{
    public class OnlineExamDbContext : DbContext
    {

        public OnlineExamDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=OnlineExam.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<User>().HasData(new User { UserID=1 ,Email = "user@onlineexam.com", Password = "user123"});

            //Mappings 
            modelBuilder.ApplyConfiguration(new ChoiceMapping());
            modelBuilder.ApplyConfiguration(new ExamMapping());
            modelBuilder.ApplyConfiguration(new QuestionMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);


        }


        //DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
