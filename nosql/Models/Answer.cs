using System;
using System.Collections.Generic;

#nullable disable

namespace nosql.Models
{
    public partial class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswertypeId { get; set; }

        public virtual Answertype Answertype { get; set; }
        public virtual Question Question { get; set; }
    }
}
