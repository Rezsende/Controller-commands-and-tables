using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class Contact
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string? Email { get; set; }
        public string? Instagram { get; set; }
        public string? FaceBook { get; set; }
        [JsonIgnore]
        public Client client { get; set; }
        public int clientId { get; set; }
      

   

        
    }
}