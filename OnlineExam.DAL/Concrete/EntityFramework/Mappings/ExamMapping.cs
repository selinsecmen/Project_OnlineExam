using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework.Mappings
{
    class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(a => a.ExamID);

            builder.HasOne(a => a.User).WithMany(a => a.Exams).HasForeignKey(a => a.UserID);

        }

    }
}
