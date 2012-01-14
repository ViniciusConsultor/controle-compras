using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class UnidadeMedida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
    }
}
