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
    public class PedidoData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public PedidoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        /// <summary>
        /// Incluir um novo grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(Pedido oPedido)
        {
            Resultado resultado = new Resultado();

            try
            {

                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PEDIDO_INSERE");
                this.m_db.AddInParameter(dbCommand, "@DATORCAMENTO", DbType.DateTime, oPedido.DataOrcamento);
                this.m_db.AddInParameter(dbCommand, "@DATAPEDIDO", DbType.DateTime, oPedido.DataPedido);
                this.m_db.AddInParameter(dbCommand, "@USUARIO_ID", DbType.Int32, oPedido.Usuario_ID);
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, oPedido.Status);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Pedido";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<MeusPedidos> Listar(int usuarioId)
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDIDOS_PESQUISA");
            this.m_db.AddInParameter(dbc, "@USUARIO_ID", DbType.String, usuarioId);

            List<MeusPedidos> listaPedido = new List<MeusPedidos>();

            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                while (readerUsuario.Read())
                {
                    MeusPedidos oPedido = new MeusPedidos();
                    oPedido.PedidoID = Conversion.preencheCampoInt(readerUsuario["COD_PEDIDO"]);
                    oPedido.DataPedido = Conversion.preencheCampoDateTime(readerUsuario["DAT_PEDIDO"]);
                    oPedido.NomeUsuario = Conversion.preencheCampoString(readerUsuario["NOME"]);
                    oPedido.Status = Conversion.preencheCampoInt(readerUsuario["NUM_STATUS"]);
                    listaPedido.Add(oPedido);
                }
                readerUsuario.Dispose();
            }
            return listaPedido;
        }

        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            Resultado resultado = new Resultado();
            try
            {

                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PedidoAtualizaStatus");
                this.m_db.AddInParameter(dbc, "@COD_PEDIDO", DbType.Int32, CodPedido);
                this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, Status);


                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Pedido";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<Aprovacao> ListaAprovacao()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_APROVACAO_LISTA");

            List<Aprovacao> oListaAprovacao = new List<Aprovacao>();

            using (IDataReader readerAprov = this.m_db.ExecuteReader(dbc))
            {
                while (readerAprov.Read())
                {
                    Aprovacao oAprovacao = new Aprovacao();
                    oAprovacao.CodigoPedido = Conversion.preencheCampoInt(readerAprov["COD_PEDIDO"]);
                    oAprovacao.CodigoItem = Conversion.preencheCampoInt(readerAprov["COD_PEDITENS"]);
                    oAprovacao.DataPedido = Conversion.preencheCampoDateTime(readerAprov["DAT_PEDIDO"]);
                    oAprovacao.Descrição = Conversion.preencheCampoString(readerAprov["DSC_DESCRICAO"]);
                    oAprovacao.Item = Conversion.preencheCampoString(readerAprov["DSC_OUTROS"]) == "" ? Conversion.preencheCampoString(readerAprov["NOM_ITEM"]) : Conversion.preencheCampoString(readerAprov["NOM_ITEM"]) + " - " + Conversion.preencheCampoString(readerAprov["DSC_OUTROS"]);
                    oAprovacao.NomeSolicitante = Conversion.preencheCampoString(readerAprov["NOME"]);
                    oAprovacao.Status = Conversion.preencheCampoInt(readerAprov["NUM_STATUS_ITEM"]);
                    oListaAprovacao.Add(oAprovacao);
                }
                readerAprov.Dispose();
            }
            return oListaAprovacao;
        }

        public Resultado Aprovar(int CodPedItem)
        {
            Resultado resultado = new Resultado();
            try
            {

                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_APROVACAO_APROVA");
                this.m_db.AddInParameter(dbc, "@CODPEDINTES", DbType.Int32, CodPedItem);

                resultado.Id = this.m_db.ExecuteNonQuery(dbc);
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Aprovacao";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;

        }

        public Resultado Cancelar(int CodPedItem)
        {
            Resultado resultado = new Resultado();
            try
            {

                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_APROVACAO_CANCELA");
                this.m_db.AddInParameter(dbc, "@CODPEDINTES", DbType.Int32, CodPedItem);

                resultado.Id = this.m_db.ExecuteNonQuery(dbc);
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "CancelaAprovacao";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;

        }
    }
}
