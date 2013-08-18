using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJewels.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string AuthorEmail { get; set; }

        public Code Code { get; set; }
    }
}