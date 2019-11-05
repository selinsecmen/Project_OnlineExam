using OnlineExam.BLL.Abstract;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineExam.DAL.Concrete.EntityFramework.DAL;

namespace OnlineExam.BLL.Concrete
{
    public class ChoiceService : IChoiceService
    {
        EFChoiceDAL _EFChoiceDAL;

        public ChoiceService()
        {
            _EFChoiceDAL = new EFChoiceDAL();
        }
        public void Add(Choice entity)
        {
            _EFChoiceDAL.Add(entity);
        }

        public void Delete(Choice entity)
        {
            _EFChoiceDAL.Delete(entity);
        }

        public Choice GetByID(int id)
        {
            return _EFChoiceDAL.Get(a => a.ChoiceID == id);
        }

        public ICollection<Choice> GetByQuestionID(int id)
        {
            return _EFChoiceDAL.GetAll(a=>a.QuestionID==id);
        }
        public ICollection<Choice> GetList()
        {
            return _EFChoiceDAL.GetAll();
        }

        public void Update(Choice entity)
        {
            _EFChoiceDAL.Update(entity);
        }
    }
}
