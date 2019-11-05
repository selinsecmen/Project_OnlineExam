using OnlineExam.BLL.Abstract;
using OnlineExam.Model;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineExam.DAL.Concrete.EntityFramework.DAL;

namespace OnlineExam.BLL.Concrete
{
    public class UserService : IUserService
    {

        EFUserDAL _EFUserDAL;

        public UserService()
        {
            _EFUserDAL = new EFUserDAL();
        }
        public void Add(User entity)
        {
            _EFUserDAL.Add(entity);
        }

        public void Delete(User entity)
        {
            _EFUserDAL.Delete(entity);
        }

        public User GetByID(int id)
        {
            return _EFUserDAL.Get(a => a.UserID == id);
        }

        public ICollection<User> GetList()
        {
            return _EFUserDAL.GetAll();
        }

        public void Update(User entity)
        {
            _EFUserDAL.Update(entity);
        }

        public Model.User GetByMailAndPassword(string mail, string password)
        {
            return _EFUserDAL.Get(a => a.Email == mail && a.Password == password);
        }
    }
}
