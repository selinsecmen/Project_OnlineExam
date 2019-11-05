using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework.Mappings
{
    class ChoiceMapping : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(a => a.ChoiceID);

            builder.HasOne(a => a.Question).WithMany(a => a.Choices).HasForeignKey(a => a.QuestionID).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
