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
    public class PedOrcamentoData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public PedOrcamentoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        /// <summary>
        /// Incluir um novo grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(PedidosOrcamentos pedidoOcarmento)
        {
            Resultado resultado = new Resultado();

            try
            {

                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SPR_PEDORCAMENTO_INSERE");

                this.m_db.AddInParameter(dbCommand, "@COD_ITEM", DbType.Int32, pedidoOcarmento.Item.ItemID);
                this.m_db.AddInParameter(dbCommand, "@COD_UNIDADEMEDIDA", DbType.Int32, pedidoOcarmento.UnidadeMedida.Id);
                this.m_db.AddInParameter(dbCommand, "@COD_PROJETO", DbType.Int32, pedidoOcarmento.Projeto.ProjetoID);
                this.m_db.AddInParameter(dbCommand, "@NUM_QUANTIDADE", DbType.Int32, pedidoOcarmento.Quantidade);
                this.m_db.AddInParameter(dbCommand, "@DAT_NECESSIDADE", DbType.DateTime, pedidoOcarmento.DataNecessidade);
                this.m_db.AddInParameter(dbCommand, "@USUARIOID_PEDIDO", DbType.Int32, pedidoOcarmento.UsuarioPedido.UsuarioId);
                this.m_db.AddInParameter(dbCommand, "@FINALIDADE", DbType.String, pedidoOcarmento.Finalidade);
                this.m_db.AddInParameter(dbCommand, "@GRUPO_ID", DbType.Int32, pedidoOcarmento.Area.ID);
                this.m_db.AddInParameter(dbCommand, "@OUTROS", DbType.String, Consts.Funcoes.NullOrString(pedidoOcarmento.Outros));
                this.m_db.AddInParameter(dbCommand, "@DESCRICAO", DbType.String, Consts.Funcoes.NullOrString(pedidoOcarmento.Descricao));
                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

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

        public List<PedidosOrcamentos> Listar()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_PEDORCAMENTO_LISTSAR");
            //this.m_db.AddInParameter(dbc, "@USUARIO_ID", DbType.String, usuarioId);

            List<PedidosOrcamentos> Lista = new List<PedidosOrcamentos>();

            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                while (readerUsuario.Read())
                {
                    PedidosOrcamentos pedidosOrcamentos = new PedidosOrcamentos();
                    pedidosOrcamentos.Cod_PedidosOrcamentos = Conversion.preencheCampoInt(readerUsuario["COD_PEDIDOSORCAMENTOS"]);
                    pedidosOrcamentos.Item = new ItemData().Seleciona(Conversion.preencheCampoInt(readerUsuario["COD_ITEM"]));
                    pedidosOrcamentos.UnidadeMedida = new UnidadeMedidaData().Obter(Conversion.preencheCampoInt(readerUsuario["COD_UNIDADEMEDIDA"]));
                    pedidosOrcamentos.Projeto = new ProjetosData().Obter(Conversion.preencheCampoInt(readerUsuario["COD_PROJETO"]));
                    pedidosOrcamentos.Quantidade = Conversion.preencheCampoDecimal(readerUsuario["NUM_QUANTIDADE"]);
                    pedidosOrcamentos.DataNecessidade = Conversion.preencheCampoDateTime(readerUsuario["DAT_NECESSIDADE"]);
                    pedidosOrcamentos.UsuarioPedido = new UsuarioData().GetByID(Conversion.preencheCampoInt(readerUsuario["USUARIOID_PEDIDO"]));
                    pedidosOrcamentos.Data_PedidoOrcamento = Conversion.preencheCampoDateTime(readerUsuario["DAT_PEDIDOORCAMENTO"]);
                    pedidosOrcamentos.Status = Conversion.preencheCampoInt(readerUsuario["STATUS"]);
                    pedidosOrcamentos.Area = new GrupoData().Obter(Conversion.preencheCampoInt(readerUsuario["GRUPO_ID"]));
                    pedidosOrcamentos.Outros = Conversion.preencheCampoString(readerUsuario["DSC_OUTROS"]);
                    pedidosOrcamentos.Descricao = Conversion.preencheCampoString(readerUsuario["DSC_DESCRICAO"]);
                    Lista.Add(pedidosOrcamentos);
                }
                readerUsuario.Dispose();
            }
            return Lista;
        }


        public PedidosOrcamentos Obter(int IdPedidosOrcamento)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_ORCAMENTO_OBTER");
            this.m_db.AddInParameter(dbc, "@IdPedidosOrcamentos", DbType.Int32, IdPedidosOrcamento);
            PedidosOrcamentos pedidosOrcamentos = new PedidosOrcamentos();
            using (IDataReader Reader = this.m_db.ExecuteReader(dbc))
            {
                if (Reader.Read())
                {
                    pedidosOrcamentos.Cod_PedidosOrcamentos = Conversion.preencheCampoInt(Reader["COD_PEDIDOSORCAMENTOS"]);
                    pedidosOrcamentos.Item = new ItemData().Seleciona(Conversion.preencheCampoInt(Reader["COD_ITEM"]));
                    pedidosOrcamentos.UnidadeMedida = new UnidadeMedidaData().Obter(Conversion.preencheCampoInt(Reader["COD_UNIDADEMEDIDA"]));
                    pedidosOrcamentos.Projeto = new ProjetosData().Obter(Conversion.preencheCampoInt(Reader["COD_PROJETO"]));
                    pedidosOrcamentos.Quantidade = Conversion.preencheCampoDecimal(Reader["NUM_QUANTIDADE"]);
                    pedidosOrcamentos.DataNecessidade = Conversion.preencheCampoDateTime(Reader["DAT_NECESSIDADE"]);
                    pedidosOrcamentos.UsuarioPedido = new UsuarioData().GetByID(Conversion.preencheCampoInt(Reader["USUARIOID_PEDIDO"]));
                    pedidosOrcamentos.Data_PedidoOrcamento = Conversion.preencheCampoDateTime(Reader["DAT_PEDIDOORCAMENTO"]);
                    pedidosOrcamentos.Status = Conversion.preencheCampoInt(Reader["STATUS"]);
                    pedidosOrcamentos.Area = new GrupoData().Obter(Conversion.preencheCampoInt(Reader["GRUPO_ID"]));
                    pedidosOrcamentos.Outros = Conversion.preencheCampoString(Reader["DSC_OUTROS"]);
                    pedidosOrcamentos.Descricao = Conversion.preencheCampoString(Reader["DSC_DESCRICAO"]);

                }
                Reader.Dispose();
            }
            return pedidosOrcamentos;
        }
    }
}
