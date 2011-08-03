using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class MeusPedidos
    {
        public int PedidoID { get; set; }
        public String Categoria { get; set; }
        public DateTime DataPedido { get; set; }
        public String NomeUsuario { get; set; }
        public int Usuario_ID { get; set; }
        public int Status { get; set; }

    }
}


