using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class Command
    {
        public int id {get; set;}
        public string description {get; set;}
        public Client? client {get; set;}
        public List<Product> products { get; set;}
        public Table? table {get; set;}
    }
}