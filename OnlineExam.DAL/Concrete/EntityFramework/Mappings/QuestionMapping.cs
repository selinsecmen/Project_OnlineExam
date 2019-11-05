using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework.Mappings
{
    class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasKey(a => a.QuestionID);

            builder.HasOne(a => a.Exam).WithMany(a => a.Questions).HasForeignKey(a => a.ExamID).OnDelete(DeleteBehavior.Cascade);

        }

       
    }
}
