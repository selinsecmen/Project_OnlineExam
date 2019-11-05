using OnlineExam.Core.DataAccess.EntityFramework;
using OnlineExam.DAL.Abstract;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Concrete.EntityFramework.DAL
{
   public class EFExamDAL : EFEntityRepositoryBase<Exam, OnlineExamDbContext>, IExamDAL
    {
    }
}
