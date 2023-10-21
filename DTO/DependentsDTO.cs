using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableandCommandControl.Entity;

namespace TableandCommandControl.DTO
{
    public class DependentsDTO
    {
        public DependentType dependentType { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int clientId { get; set; }
    }
}