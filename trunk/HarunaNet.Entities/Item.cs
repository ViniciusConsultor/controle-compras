using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Item
    {
        public int ItemID { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public bool Requer_Aprovação{ get; set; }
        public Categoria Categoria { get; set; }
    }
}
