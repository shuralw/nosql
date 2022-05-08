using System;
using System.Collections.Generic;

#nullable disable

namespace nosql.Models
{
    public partial class Questionnaire
    {
        public Questionnaire()
        {
            Blocks = new HashSet<Block>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Block> Blocks { get; set; }
    }
}
