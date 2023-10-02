using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class Table
    {
        public int id {get; set;}
        public string description {get; set;}

        public int Status {get; set;} = 0;
        public DateTime? scheduling{get; set;}
    }
}