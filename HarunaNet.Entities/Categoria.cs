using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public Ramo Ramo { get; set; }
    }
}
