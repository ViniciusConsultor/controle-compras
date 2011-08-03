using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Compras
    {
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public int CentroDeCustoID { get; set; }
        public string CentroDeCusto { get; set; }
        public Int32 Total { get; set; }
    }
}
