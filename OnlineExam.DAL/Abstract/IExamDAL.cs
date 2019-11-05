using OnlineExam.Core.DataAccess;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.DAL.Abstract
{
    interface IExamDAL : IEntityRepository<Exam>
    {
    }
}
