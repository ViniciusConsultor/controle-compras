using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Compras
    {
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public int CentroDeCustoID { get; set; }
        public string CentroDeCusto { get; set; }
        public Int32 Total { get; set; }
    }
}
