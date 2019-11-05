using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Model
{
    public class User : IEntity
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //Navigation Property

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
