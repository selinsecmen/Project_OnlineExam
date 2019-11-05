using OnlineExam.BLL.Abstract;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineExam.DAL.Concrete.EntityFramework.DAL;

namespace OnlineExam.BLL.Concrete
{

    public class QuestionService : IQuestionService
    {
        EFQuestionDAL _EFQuestionDAL;
        EFExamDAL _EFExamDAL;
        public QuestionService()
        {
            _EFQuestionDAL = new EFQuestionDAL();
            _EFExamDAL = new EFExamDAL();
        }
        public void Add(Question entity)
        {
            _EFQuestionDAL.Add(entity);
        }

        public void Delete(Question entity)
        {
            _EFQuestionDAL.Delete(entity);
        }

        public Question GetByID(int id)
        {
            return _EFQuestionDAL.Get(a => a.QuestionID == id);
        }

        public ICollection<Question> GetByExamID(int id)
        {
            return _EFQuestionDAL.GetAll(a => a.ExamID == id);
        }

        //public Question GetByExamAndQuestionID(int eid,int qid)
        //{
        //    Exam exam =_EFExamDAL.Get(a => a.ExamID == eid);

        //    Question question =_EFQuestionDAL.Get(a => a.ExamID == eid && a.QuestionID == qid);

        //    return question;

        //}


        public ICollection<Question> GetList()
        {
            return _EFQuestionDAL.GetAll();
        }

        public void Update(Question entity)
        {
            _EFQuestionDAL.Update(entity);
        }
    }
}
