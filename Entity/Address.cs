using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TableandCommandControl.Entity
{
    public class Address
    {
        public int id {get; set;}
        public string city {get; set;}
        public string neighborhood {get; set;}
        public string road {get; set;}
        public string number {get; set;}
        public string complement {get; set;}
        [JsonIgnore]
        public Client client { get; set; }
        public int clientId { get; set; }
    }
}