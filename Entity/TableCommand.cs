using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class TableCommand
    {
        public int id { get; set; }
        public string description { get; set; }

        public int Status { get; set; } = 0;
        public DateTime? scheduling { get; set; }
    }

    public class TableCommandDto
    {
  
        public string description { get; set; }

        public int status { get; set; }

    }
}