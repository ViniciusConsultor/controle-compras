using System;
using System.Collections.Generic;
using System.Text;


namespace HarunaNet.Entities
{
    [Serializable()]
    public class ProcessoCompra
    {
        public int CodProcessoCompra { get; set; }
        public int Status { get; set; }
        public String NomeCategoria { get; set; }
        public String Pedidos { get; set; }
        public DateTime DataProcesso { get; set; }

     
    }
}
