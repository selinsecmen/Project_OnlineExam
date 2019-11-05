using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Model
{
    public class Choice : IEntity
    {
        public int ChoiceID { get; set; }

        public string ChoiceText { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }

        //Navigation Property
        public virtual Question Question { get; set; }
    }
}
