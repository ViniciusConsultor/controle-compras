using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Ped_Item
    {
        public int PedidoItensID { get; set; }
        public int CodProcesso { get; set; }
        public Item Item { get; set; }
        public Projetos Projeto { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeComprada { get; set; }
        public int Status { get; set; }
        public DateTime Data_Pedido { get; set; }
        public DateTime Data_EntradaFornecedor { get; set; }
        public DateTime Data_PrevisaoEntrega { get; set; }
        public DateTime Data_Entrega { get; set; }
        public Decimal ValorUnitario { get; set; }
        public string Outros { get; set; }
        public string Descrição { get; set; }
        public Grupo Area { get; set; }


        #region Constructors

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Ped_Item()
        {
            this.Item = new Item();
            this.Projeto = new Projetos();
        }
        #endregion
    }
}
