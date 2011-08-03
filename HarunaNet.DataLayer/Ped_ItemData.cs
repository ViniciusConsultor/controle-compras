using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.DataLayer
{
    public class Ped_ItemData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public Ped_ItemData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        /// <summary>
        /// Incluir um novo grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(Ped_Item oPedItem, Int32 IDPedido)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PEDITEM_INSERE");
                this.m_db.AddInParameter(dbCommand, "@COD_PEDIDO", DbType.Int32, IDPedido);
                this.m_db.AddInParameter(dbCommand, "@COD_ITEM", DbType.Int32, oPedItem.Item.ItemID);
                this.m_db.AddInParameter(dbCommand, "@COD_PROJETO", DbType.Int32, oPedItem.Projeto.ProjetoID);
                this.m_db.AddInParameter(dbCommand, "@QUANTIDADE", DbType.Int32, oPedItem.Quantidade);
                this.m_db.AddInParameter(dbCommand, "@DT_PEDINTEM", DbType.DateTime, oPedItem.Data_Pedido);
                this.m_db.AddInParameter(dbCommand, "@GRUPO_ID", DbType.Int32, oPedItem.Area.ID);
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, oPedItem.Status);
                this.m_db.AddInParameter(dbCommand, "@OUTROS", DbType.String, Consts.Funcoes.NullOrString(oPedItem.Outros));
                this.m_db.AddInParameter(dbCommand, "@DESCRICAO", DbType.String, Consts.Funcoes.NullOrString(oPedItem.Descrição));

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<Compras> Listar()
        {
            DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_ITENSCOMPA_LISTA");
            List<Compras> listaCompras = new List<Compras>();

            using (IDataReader readerPedItens = this.m_db.ExecuteReader(dbCommand))
            {
                while (readerPedItens.Read())
                {
                    Compras oPedGrupo = new Compras();
                    oPedGrupo.CategoriaID = Conversion.preencheCampoInt(readerPedItens["COD_CATEGORIA"]);
                    oPedGrupo.Categoria = Conversion.preencheCampoString(readerPedItens["NOM_CATEGORIA"]);
                    oPedGrupo.Total = Conversion.preencheCampoInt(readerPedItens["TOTAL"]);
                    oPedGrupo.CentroDeCustoID = Conversion.preencheCampoInt(readerPedItens["COD_CENTRODECUSTO"]);
                    oPedGrupo.CentroDeCusto = Conversion.preencheCampoString(readerPedItens["NOM_CENTRODECUSTO"]);

                    listaCompras.Add(oPedGrupo);
                }
                readerPedItens.Dispose();
            }
            return listaCompras;
        }

        public List<PedListaItem> ListaItensCompra(int CategoriaID, int CC_ID)
        {
            DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PEDITEM_LISTAbyIDCATEGORIA");
            this.m_db.AddInParameter(dbCommand, "@CAT", DbType.Int32, CategoriaID);
            this.m_db.AddInParameter(dbCommand, "@CC_ID", DbType.Int32, CC_ID);

            List<PedListaItem> listaCompras = new List<PedListaItem>();

            using (IDataReader readerlistaCompras = this.m_db.ExecuteReader(dbCommand))
            {
                while (readerlistaCompras.Read())
                {
                    PedListaItem oPedListaItem = new PedListaItem();
                    Item oItem = new Item();
                    oItem.ItemID = Conversion.preencheCampoInt(readerlistaCompras["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);

                    oPedListaItem.Item = oItem;

                    oPedListaItem.CodPedido = Conversion.preencheCampoInt(readerlistaCompras["COD_PEDIDO"]);
                    oPedListaItem.Outros = Conversion.preencheCampoString(readerlistaCompras["DSC_OUTROS"]);
                    oPedListaItem.Quantidade = Conversion.preencheCampoInt(readerlistaCompras["QUANTIDADE"]);
                    oPedListaItem.NomeItem = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);
                    oPedListaItem.Empresa = Conversion.preencheCampoString(readerlistaCompras["NOM_CENTRODECUSTO"]);
                    oPedListaItem.Area = Conversion.preencheCampoString(readerlistaCompras["NOM_GRUPO"]);
                    oPedListaItem.Solicitante = Conversion.preencheCampoString(readerlistaCompras["NOME"]);
                    listaCompras.Add(oPedListaItem);
                }
                readerlistaCompras.Dispose();
            }
            return listaCompras;
        }

        public List<Ped_Item> ListarByNumPed(int CodPedido)
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDIDO_PESQUISA_COD");
            this.m_db.AddInParameter(dbc, "@COD_PED", DbType.Int32, CodPedido);

            List<Ped_Item> listaPedido = new List<Ped_Item>();

            using (IDataReader readerPedItem = this.m_db.ExecuteReader(dbc))
            {
                while (readerPedItem.Read())
                {
                    Ped_Item oPed_Item = new Ped_Item();
                    oPed_Item.PedidoItensID = Conversion.preencheCampoInt(readerPedItem["COD_PEDITENS"]);
                    oPed_Item.Quantidade = Conversion.preencheCampoInt(readerPedItem["NUM_QUANTIDADE"]);
                    oPed_Item.QuantidadeComprada = Conversion.preencheCampoInt(readerPedItem["NUM_QTDCOMPRADA"]);
                    oPed_Item.Outros = Conversion.preencheCampoString(readerPedItem["DSC_OUTROS"]);
                    oPed_Item.Data_Pedido = readerPedItem["DAT_PEDIDO_ITEM"].ToString() == "" ? DateTime.MinValue : Conversion.preencheCampoDateTime(readerPedItem["DAT_PEDIDO_ITEM"]);
                    oPed_Item.Data_EntradaFornecedor = readerPedItem["DAT_PEDIDO_FORN"].ToString() == "" ? DateTime.MinValue : Conversion.preencheCampoDateTime(readerPedItem["DAT_PEDIDO_FORN"]);
                    oPed_Item.Data_PrevisaoEntrega = readerPedItem["DAT_PEDIDO_PREVISAO"].ToString() == "" ? DateTime.MinValue : Conversion.preencheCampoDateTime(readerPedItem["DAT_PEDIDO_PREVISAO"]);
                    oPed_Item.Data_Entrega = readerPedItem["DAT_PEDIDO_ENTREGA"].ToString() == "" ? DateTime.MinValue : Conversion.preencheCampoDateTime(readerPedItem["DAT_PEDIDO_ENTREGA"]);
                    oPed_Item.Status = Conversion.preencheCampoInt(readerPedItem["NUM_STATUS_ITEM"]);

                    Item oItm = new Item();
                    oItm.Nome = Conversion.preencheCampoString(readerPedItem["NOM_ITEM"]);
                    oItm.Requer_Aprovação = Conversion.preencheCampoBoolean(readerPedItem["FLG_APROVACAO"]);

                    Categoria oCategoria = new Categoria();
                    oCategoria.Nome = Conversion.preencheCampoString(readerPedItem["NOM_CATEGORIA"]);


                    Grupo oArea = new Grupo();
                    oArea.ID = Conversion.preencheCampoInt(readerPedItem["GRUPO_ID"]);
                    oArea.Nome = Conversion.preencheCampoString(readerPedItem["NOM_GRUPO"]);


                    oItm.Categoria = oCategoria;

                    oPed_Item.Item = oItm;
                    oPed_Item.Area = oArea;

                    Projetos oProjeto = new Projetos();

                    oProjeto.Nome = Conversion.preencheCampoString(readerPedItem["NOM_PROJETO"]);
                    oPed_Item.Projeto = oProjeto;

                    listaPedido.Add(oPed_Item);
                }
                readerPedItem.Dispose();
            }
            return listaPedido;
        }

        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            Resultado resultado = new Resultado();
            try
            {

                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_ItemPedidoAtualizaStatus");
                this.m_db.AddInParameter(dbc, "@COD_PEDITENS", DbType.Int32, CodPedido);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, Status);


                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado AtualizaProcessoCompra(int CategoriaID, int CC_ID)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PROCESSOCOMPRA_INSERE");
                this.m_db.AddInParameter(dbc, "@CAT", DbType.Int32, CategoriaID);
                this.m_db.AddInParameter(dbc, "@CC_ID", DbType.Int32, CC_ID);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<ProcessoCompraItem> ListaItensPCompra(int CodPCompra)
        {
            DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PROCESSOCOMPRAITENS_LISTA");
            this.m_db.AddInParameter(dbCommand, "@CDP", DbType.Int32, CodPCompra);

            List<ProcessoCompraItem> listaCompras = new List<ProcessoCompraItem>();

            using (IDataReader readerlistaCompras = this.m_db.ExecuteReader(dbCommand))
            {
                while (readerlistaCompras.Read())
                {
                    ProcessoCompraItem oPedListaItem = new ProcessoCompraItem();
                    Item oItem = new Item();
                    oItem.Nome = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);

                    oPedListaItem.Item = oItem;
                    oPedListaItem.CodProcesso = Conversion.preencheCampoInt(readerlistaCompras["COD_PROCESSOCOMPRA"]);
                    oPedListaItem.CodPedido = Conversion.preencheCampoInt(readerlistaCompras["COD_PEDIDO"]);
                    oPedListaItem.CodItem = Conversion.preencheCampoInt(readerlistaCompras["COD_PEDITENS"]);
                    oPedListaItem.NomeProjeto = Conversion.preencheCampoString(readerlistaCompras["NOM_PROJETO"]);
                    oPedListaItem.NomeUsuario = Conversion.preencheCampoString(readerlistaCompras["NOME"]);
                    oPedListaItem.Outros = Conversion.preencheCampoString(readerlistaCompras["DSC_OUTROS"]);
                    oPedListaItem.Quantidade = Conversion.preencheCampoInt(readerlistaCompras["QUANTIDADE"]) < 0 ? 0 : Conversion.preencheCampoInt(readerlistaCompras["QUANTIDADE"]);
                    oPedListaItem.QuantidadeComprada = Conversion.preencheCampoInt(readerlistaCompras["NUM_QTDCOMPRADA"]) < 0 ? 0 : Conversion.preencheCampoInt(readerlistaCompras["NUM_QTDCOMPRADA"]);
                    oPedListaItem.NomeItem = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);
                    oPedListaItem.Empresa = Conversion.preencheCampoString(readerlistaCompras["NOM_CENTRODECUSTO"]);
                    oPedListaItem.ValorUnitario = Conversion.preencheCampoDecimal(readerlistaCompras["VAL_UNITARIO"]) < 0 ? 0 : Conversion.preencheCampoDecimal(readerlistaCompras["VAL_UNITARIO"]);
                    oPedListaItem.DataCompra = Conversion.preencheCampoDateTime(readerlistaCompras["DAT_PEDIDO_COMPRA"]);
                    oPedListaItem.DataPrevisaoEntrega = Conversion.preencheCampoDateTime(readerlistaCompras["DAT_PEDIDO_PREVISAO"]);
                    oPedListaItem.DataEntrega = Conversion.preencheCampoDateTime(readerlistaCompras["DAT_PEDIDO_ENTREGA"]);
                    oPedListaItem.Status = Conversion.preencheCampoInt(readerlistaCompras["NUM_STATUS_ITEM"]);

                    oPedListaItem.TpDocumentoFiscal = Conversion.preencheCampoInt(readerlistaCompras["TP_DOCUMENTO"]) < 0 ? 0 : Conversion.preencheCampoInt(readerlistaCompras["TP_DOCUMENTO"]);
                    oPedListaItem.NotaSerie = Conversion.preencheCampoString(readerlistaCompras["NUM_SERIE_NOTA"]);
                    oPedListaItem.NotaFiscal = Conversion.preencheCampoInt(readerlistaCompras["NUM_NOTAFISCAL"]) < 0 ? 0 : Conversion.preencheCampoInt(readerlistaCompras["NUM_NOTAFISCAL"]);
                    oPedListaItem.DataEmissaoNota = Conversion.preencheCampoDateTime(readerlistaCompras["DAT_EMISSAO_NOTA"]);

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.FornecedorID = Conversion.preencheCampoInt(readerlistaCompras["FORNECEDOR_ID"]);
                    oPedListaItem.Fornecedor = oFornecedor;

                    Grupo oGrupo = new Grupo();
                    oGrupo.ID = Conversion.preencheCampoInt(readerlistaCompras["GRUPO_ID"]);
                    oGrupo.Nome = Conversion.preencheCampoString(readerlistaCompras["NOM_GRUPO"]);
                    oPedListaItem.Area = oGrupo;

                    oPedListaItem.NomeArea = Conversion.preencheCampoString(readerlistaCompras["NOM_GRUPO"]);

                    listaCompras.Add(oPedListaItem);
                }
                readerlistaCompras.Dispose();
            }
            return listaCompras;
        }

        public List<PedListaItem> ListaItensPCompraPorCodigo(int CodPCompra)
        {
            DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PROCESSOCOMPRAITENS_LISTA");
            this.m_db.AddInParameter(dbCommand, "@CDP", DbType.Int32, CodPCompra);

            List<PedListaItem> listaCompras = new List<PedListaItem>();

            using (IDataReader readerlistaCompras = this.m_db.ExecuteReader(dbCommand))
            {
                while (readerlistaCompras.Read())
                {

                    PedListaItem oPedListaItem = new PedListaItem();
                    Item oItem = new Item();
                    oItem.ItemID = Conversion.preencheCampoInt(readerlistaCompras["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);

                    oPedListaItem.Item = oItem;

                    oPedListaItem.CodItem = Conversion.preencheCampoInt(readerlistaCompras["COD_PEDITENS"]);
                    oPedListaItem.CodPedido = Conversion.preencheCampoInt(readerlistaCompras["COD_PEDIDO"]);
                    oPedListaItem.Outros = Conversion.preencheCampoString(readerlistaCompras["DSC_OUTROS"]);
                    oPedListaItem.Quantidade = Conversion.preencheCampoInt(readerlistaCompras["QUANTIDADE"]);
                    oPedListaItem.NomeItem = Conversion.preencheCampoString(readerlistaCompras["NOM_ITEM"]);
                    oPedListaItem.Empresa = Conversion.preencheCampoString(readerlistaCompras["NOM_CENTRODECUSTO"]);
                    oPedListaItem.Area = Conversion.preencheCampoString(readerlistaCompras["NOM_GRUPO"]);
                    oPedListaItem.Solicitante = Conversion.preencheCampoString(readerlistaCompras["NOME"]);
                    oPedListaItem.Status = Conversion.preencheCampoInt(readerlistaCompras["NUM_STATUS_ITEM"]);

                    listaCompras.Add(oPedListaItem);

                }
                readerlistaCompras.Dispose();
            }
            return listaCompras;
        }

        public Resultado AtualizaValor(Ped_Item oPedItem)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDINTEM_UPDATE");
                this.m_db.AddInParameter(dbc, "@PEDITEM", DbType.Int32, oPedItem.PedidoItensID);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, oPedItem.Status);
                if (oPedItem.Data_PrevisaoEntrega >= DateTime.Now)
                {
                    this.m_db.AddInParameter(dbc, "@VAL", DbType.Decimal, oPedItem.ValorUnitario);
                    this.m_db.AddInParameter(dbc, "@DATAPREVISAO", DbType.DateTime, oPedItem.Data_PrevisaoEntrega);
                }

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItemValor";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado FecharProcesso(Ped_Item oPedItem)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDINTEM_UPDATE");
                this.m_db.AddInParameter(dbc, "@VAL", DbType.Decimal, oPedItem.ValorUnitario);
                this.m_db.AddInParameter(dbc, "@PEDITEM", DbType.Int32, oPedItem.PedidoItensID);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, oPedItem.Status);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItemValor";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado AtualizaStatusProcessoCompra(ProcessoCompra CC_ID)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.[SP_PEDIDOS_ATUALIZASTATUS_PCOMPRA]");
                this.m_db.AddInParameter(dbc, "@COD_PROCESSO", DbType.Int32, CC_ID.CodProcessoCompra);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, CC_ID.Status);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "StatusPcompra";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<Status> ListarStatus()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PED_ITENS_STATUS_LISTA");


            List<Status> listaStatus = new List<Status>();

            using (IDataReader readerStatus = this.m_db.ExecuteReader(dbc))
            {
                while (readerStatus.Read())
                {
                    Status oStatus = new Status();
                    oStatus.StatusId = Conversion.preencheCampoInt(readerStatus["COD_STATUS_PEDITEM"]);
                    oStatus.Descricao = Conversion.preencheCampoString(readerStatus["DESCRICAO"]);

                    listaStatus.Add(oStatus);
                }
                readerStatus.Dispose();
            }
            return listaStatus;


        }

        public Resultado AtualizaItemCompra(ProcessoCompraItem pPCItem)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDINTEM_UPDATE");

                this.m_db.AddInParameter(dbc, "@CODPEDITENS", DbType.Int32, pPCItem.CodItem);
                this.m_db.AddInParameter(dbc, "@QTDCOMPRADA", DbType.Int32, pPCItem.QuantidadeComprada);



                if (pPCItem.NotaFiscal > 0)
                    this.m_db.AddInParameter(dbc, "@NOTAFISCAL", DbType.Int32, pPCItem.NotaFiscal);

                if (pPCItem.DataEmissaoNota > DateTime.MinValue)
                    this.m_db.AddInParameter(dbc, "@DATAEMISSAONF", DbType.DateTime, pPCItem.DataEmissaoNota);

                if (pPCItem.NotaSerie != "")
                    this.m_db.AddInParameter(dbc, "@SERIENF", DbType.String, pPCItem.NotaSerie);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, pPCItem.NextStatus);

                if (pPCItem.DataCompra > DateTime.MinValue)
                    this.m_db.AddInParameter(dbc, "@DTCOMPRA", DbType.DateTime, pPCItem.DataCompra);
                if (pPCItem.DataPrevisaoEntrega > DateTime.MinValue)
                    this.m_db.AddInParameter(dbc, "@DTPREVISAO", DbType.DateTime, pPCItem.DataPrevisaoEntrega);
                if (pPCItem.DataEntrega > DateTime.MinValue)
                    this.m_db.AddInParameter(dbc, "@DTENTREGA", DbType.DateTime, pPCItem.DataEntrega);
                this.m_db.AddInParameter(dbc, "@VALOR", DbType.Decimal, pPCItem.ValorUnitario);
                this.m_db.AddInParameter(dbc, "@FORNECEDOR", DbType.Int32, pPCItem.Fornecedor.FornecedorID);

                if (pPCItem.TpDocumentoFiscal > 0)
                    this.m_db.AddInParameter(dbc, "@TPDOCUMENTO", DbType.Int32, pPCItem.TpDocumentoFiscal);

                this.m_db.AddInParameter(dbc, "@DESCMOTIVOCANCELADO", DbType.String, pPCItem.DescMotivoCancelamento);


                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItemValor";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado IncluirCompraRestante(ProcessoCompraItem oPedItem)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PEDITEM_INSERERESTANTE");
                this.m_db.AddInParameter(dbCommand, "@COD_PEDITENS", DbType.Int32, oPedItem.CodItem);
                this.m_db.AddInParameter(dbCommand, "@QUANTIDADE", DbType.Int32, (oPedItem.Quantidade - oPedItem.QuantidadeComprada));

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItemRestante";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

    }
}
