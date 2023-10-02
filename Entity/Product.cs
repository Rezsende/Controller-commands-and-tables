using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class Product
    {
        public int id { get; set; }
        public string description { get; set; }
        public double purchaseValue { get; set; }
        public double SaleValue { get; set; }
        public int stock { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public ProductCommands ProductCommands { get; set; }
    }
}