using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableandCommandControl.DTO
{
    public class ProductDTO
    {
         
        public string description { get; set; }
        public double purchaseValue { get; set; }
        public double SaleValue { get; set; }
        public int stock { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}