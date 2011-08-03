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
    public class ProjetosData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public ProjetosData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de módulos
        ///// </summary>
        ///// <returns>Lista de módulos</returns>
        public List<Projetos> Listar()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PROJETOS_LISTA");
            List<Projetos> listaProjetos = new List<Projetos>();

            using (IDataReader readerProjetos = this.m_db.ExecuteReader(dbc))
            {
                while (readerProjetos.Read())
                {
                    Projetos oProjetos = new Projetos();
                    oProjetos.ProjetoID = Conversion.preencheCampoInt(readerProjetos["COD_PROJETO"]);
                    oProjetos.Nome = Conversion.preencheCampoString(readerProjetos["NOM_PROJETO"]);
                    //oProjetos.CentrodeCusto = Conversion.preencheCampoInt(readerProjetos["PODE_ACESSAR"]);

                    listaProjetos.Add(oProjetos);
                }
                readerProjetos.Dispose();
            }
            return listaProjetos;
        }

        public Projetos Listar(Projetos oProjeto)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PROJETOS_GETbyID");
            this.m_db.AddInParameter(dbc, "@ID", DbType.Int32, oProjeto.ProjetoID);
            Projetos oProjetos = null;
            using (IDataReader readerProjetos = this.m_db.ExecuteReader(dbc))
            {
                if (readerProjetos.Read())
                {
                     oProjetos = new Projetos();
                    oProjetos.ProjetoID = Conversion.preencheCampoInt(readerProjetos["COD_PROJETO"]);
                    oProjetos.Nome = Conversion.preencheCampoString(readerProjetos["NOM_PROJETO"]);

                }
                
            }
            return oProjetos;
        }
    }
}
