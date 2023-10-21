using System.Text.Json.Serialization;

namespace TableandCommandControl.Entity
{
    public class Dependents
    {
        public int id { get; set; }
        public DependentType dependentType { get; set; }
        public string name {get; set;}
        public string lastName { get; set; }

        [JsonIgnore]
        public Client client { get; set; }
        public int clientId { get; set; }
       
       
    }

    public enum DependentType
    {
        Filho,
        Filha,
        Pai,
        Mae,
        Primo,
        Cunhado,
        Cunhada,
        Avô,
        Avó,
        Amigo,
        Amiga,
        Irmão,
        Irmã,
        Esposa,
        Esposo
    }
}