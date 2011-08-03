using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class ProcessoCompraItem
    {
        public int CodProcesso { get; set; }
        public Item Item { get; set; }
        public int CodPedido { get; set; }
        public string CodPedidos { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeComprada { get; set; }
        public DateTime DataCompra{ get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime Data_PedidoRestante { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Outros { get; set; }
        public string NomeItem { get; set; }
        public string Empresa { get; set; }
        public string NomeUsuario { get; set; }
        public Projetos projeto { get; set; }
        public string NomeProjeto { get; set; }
        
        public string DescMotivoCancelamento { get; set; }

        public int TpDocumentoFiscal { get; set; }
        public int NotaFiscal { get; set; }
        public string NotaSerie { get; set; }
        public DateTime DataEmissaoNota { get; set; }

        public int CodItem { get; set; }
        public int Status { get; set; }
        public int NextStatus { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public String NomeArea { get; set; }
        public Grupo Area { get; set; }

        #region Constructors

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ProcessoCompraItem()
        {
            this.Item = new Item();
            this.projeto = new Projetos();
            DataPrevisaoEntrega  = DateTime.MinValue;
            DataEntrega = DateTime.MinValue;
        }
        #endregion
    }
}