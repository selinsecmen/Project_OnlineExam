using OnlineExam.BLL.Abstract;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineExam.DAL.Concrete.EntityFramework.DAL;

namespace OnlineExam.BLL.Concrete
{
    public class ExamService : IExamService
    {
        readonly EFExamDAL _EFExamDAL;

        public ExamService()
        {
            _EFExamDAL = new EFExamDAL();
        }
        public void Add(Exam entity)
        {
            _EFExamDAL.Add(entity);
        }

        public void Delete(Exam entity)
        {
            _EFExamDAL.Add(entity);
        }

        public Exam GetByID(int id)
        {
            return _EFExamDAL.Get(a => a.ExamID == id);
        }

        public ICollection<Exam> GetList()
        {
            return _EFExamDAL.GetAll();
        }

        public ICollection<Exam> GetAllById(int id)
        {
            return _EFExamDAL.GetAllById(a => a.UserID == id && a.IsActive==true);
        }

        public void Update(Exam entity)
        {
            _EFExamDAL.Update(entity);
        }
    }
}
