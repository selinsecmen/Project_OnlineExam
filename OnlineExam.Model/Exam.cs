using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Model
{
    public class Exam : IEntity
    {

        public int ExamID { get; set; }

        public string ExamName { get; set; }

        public string ExamText { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserID { get; set; }

        public bool IsActive { get; set; }


        //Navigation Properties
        public virtual User User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
