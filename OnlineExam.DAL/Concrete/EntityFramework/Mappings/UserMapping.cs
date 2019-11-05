using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework.Mappings
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(a => a.UserID);

            //builder.HasMany(a => a.Exams).WithOne(a => a.User).HasForeignKey(a => a.UserID);

        }

    }
}
