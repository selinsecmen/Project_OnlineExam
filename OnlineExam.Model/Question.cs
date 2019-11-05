using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Model
{
    public class Question : IEntity
    {
        public int QuestionID { get; set; }

        public string QuestionText { get; set; }

        public int ExamID { get; set; }


        //Navigation Properties
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
