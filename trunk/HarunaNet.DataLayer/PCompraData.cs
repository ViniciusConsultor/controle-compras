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
    public class PCompraData
    {

        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public PCompraData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion


        public List<ProcessoCompra> Listar()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PROCESSOCOMPRA_LISTA");

            List<ProcessoCompra> listaPCompra = new List<ProcessoCompra>();

            using (IDataReader readerPCompra = this.m_db.ExecuteReader(dbc))
            {
                while (readerPCompra.Read())
                {
                    ProcessoCompra oProcessoCompra = new ProcessoCompra();
                    oProcessoCompra.CodProcessoCompra = Conversion.preencheCampoInt(readerPCompra["COD_PROCESSOCOMPRA"]);
                    oProcessoCompra.DataProcesso = Conversion.preencheCampoDateTime(readerPCompra["DT_PROCESSOCOMPRA"]);
                    oProcessoCompra.NomeCategoria = Conversion.preencheCampoString(readerPCompra["NOM_CATEGORIA"]);
                    oProcessoCompra.Pedidos = Conversion.preencheCampoString(readerPCompra["COD_PEDIDO"]);
                    oProcessoCompra.Status = Conversion.preencheCampoInt(readerPCompra["ID_STATUS_PROCESSOCOMPRA"]);
                    listaPCompra.Add(oProcessoCompra);
                }
                readerPCompra.Dispose();
            }
            return listaPCompra;
        }


        public Resultado Atualizar(int CodProcessoCompra)
        {
            Resultado resultado = new Resultado();
            try
            {

                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PROCESSOCOMPRA_UPDATE");
                this.m_db.AddInParameter(dbc, "@PROCESSOCOMPRA", DbType.Int32, CodProcessoCompra);


                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (SqlException ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "ProcessoCompraAtualizar";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

    }
}
