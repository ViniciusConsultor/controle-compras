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
    public class OrcamentoData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public OrcamentoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        /// <summary>
        /// Incluir um novo grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(Orcamentos ocarmento)
        {
            Resultado resultado = new Resultado();

            try
            {

                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SPR_ORCAMENTO _INSERE");
                //this.m_db.AddInParameter(dbCommand, "@COD_ITEM", DbType.DateTime, ocarmento.Item.ItemID);
                //this.m_db.AddInParameter(dbCommand, "@COD_UNIDADEMEDIDA", DbType.DateTime, ocarmento.);
                //this.m_db.AddInParameter(dbCommand, "@COD_PROJETO", DbType.DateTime, ocarmento.DataOrcamento);
                //this.m_db.AddInParameter(dbCommand, "@NUM_QUANTIDADE", DbType.DateTime, ocarmento.DataOrcamento);
                //this.m_db.AddInParameter(dbCommand, "@DAT_NECESSIDADE", DbType.DateTime, ocarmento.DataOrcamento);
                //this.m_db.AddInParameter(dbCommand, "@USUARIOID_PEDIDO", DbType.DateTime, ocarmento.DataOrcamento);	

                //resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                //resultado.Sucesso = (resultado.Id > 0);

            }
            catch (SqlException ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Orcamento";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public List<Orcamentos> Listar()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PEDIDOS_PESQUISA");
            //this.m_db.AddInParameter(dbc, "@USUARIO_ID", DbType.String, usuarioId);

            List<Orcamentos> Lista = new List<Orcamentos>();

            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                while (readerUsuario.Read())
                {
                    //MeusPedidos oPedido = new MeusPedidos();
                    //oPedido.PedidoID = Conversion.preencheCampoInt(readerUsuario["COD_PEDIDO"]);
                    //oPedido.DataPedido = Conversion.preencheCampoDateTime(readerUsuario["DAT_PEDIDO"]);
                    //oPedido.NomeUsuario = Conversion.preencheCampoString(readerUsuario["NOME"]);
                    //oPedido.Status = Conversion.preencheCampoInt(readerUsuario["NUM_STATUS"]);
                    //listaPedido.Add(oPedido);
                }
                readerUsuario.Dispose();
            }
            return Lista;
        }

    }
}
