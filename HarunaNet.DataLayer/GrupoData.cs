
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
    public class GrupoData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de tipoAcesso.
        /// </summary>
        public GrupoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        #region Parte DAO

        public List<Grupo> Listar()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_GRUPO_LISTA");
            List<Grupo> listaGrupo = new List<Grupo>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    Grupo oGrupo = new Grupo();
                    oGrupo.ID = Conversion.preencheCampoInt(readerCategoria["GRUPO_ID"]);
                    oGrupo.Nome = Conversion.preencheCampoString(readerCategoria["NOM_GRUPO"]);

                    listaGrupo.Add(oGrupo);
                }
                readerCategoria.Dispose();
            }
            return listaGrupo;

        }

        public Resultado Incluir(Grupo oGrupo)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SPR_GRUPO_INSERE");
                this.m_db.AddInParameter(dbCommand, "@NOME", DbType.String, oGrupo.Nome);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "INSERIR";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado Atualiza(Grupo oGrupo)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_GRUPO_UPDATE");

                this.m_db.AddInParameter(dbc, "@COD_ITEM", DbType.Int32, oGrupo.ID);
                if (oGrupo.Nome != "")
                    this.m_db.AddInParameter(dbc, "@DESC_ITEM", DbType.String, oGrupo.Nome);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "UPDATE";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Grupo Obter(int ID)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_GRUPO_LISTA");
            this.m_db.AddInParameter(dbc, "@ID", DbType.Int32, ID);
            Grupo oGrupo = new Grupo();
            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                if (readerCategoria.Read())
                {

                    oGrupo.ID = Conversion.preencheCampoInt(readerCategoria["GRUPO_ID"]);
                    oGrupo.Nome = Conversion.preencheCampoString(readerCategoria["NOM_GRUPO"]);

                }
            }
            return oGrupo;
        }

        #endregion
    }
}