using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class ProductCommands
    {
        public int id { get; set; }

        public string description { get; set; }

        [JsonIgnore]
        public Product product { get; set; }
        public int productId { get; set; }
         public double SaleValueCommand { get; set; }    
        public int Qtd { get; set; }

      


        
        // public string description
        // {
        //     get { return product != null ? product.description : null; }
        // }

        // public double valorVendaList
        // {
        //     get { return product != null ? product.SaleValue : 0; }
        // }

    }
}