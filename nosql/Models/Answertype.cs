using System;
using System.Collections.Generic;

#nullable disable

namespace nosql.Models
{
    public partial class Answertype
    {
        public Answertype()
        {
            Answers = new HashSet<Answer>();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
