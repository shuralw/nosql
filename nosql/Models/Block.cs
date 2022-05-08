using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace nosql.Models
{
    public partial class Block
    {
        public Block()
        {
            Questions = new HashSet<Question>();
        }

        public Guid Id { get; set; }
        public Guid QuestionnaireId { get; set; }
        public Guid AnswerId { get; set; }
        public HierarchyId Node { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
