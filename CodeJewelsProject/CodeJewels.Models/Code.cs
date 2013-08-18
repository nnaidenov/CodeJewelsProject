using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace CodeJewels.Models
{
    public class Code
    {
        public int Id { get; set; }

        [Required]
        public string AuthorMail { get; set; }

        [Required]
        public string SourceCode { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public Code()
        {
            this.Votes = new HashSet<Vote>();
        }
    }
}
