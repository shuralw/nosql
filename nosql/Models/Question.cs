using System;
using System.Collections.Generic;

#nullable disable

namespace nosql.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public string Text { get; set; }

        public virtual Block Block { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
