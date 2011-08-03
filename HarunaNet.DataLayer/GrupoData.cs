
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

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_GRUPO_LISTA");
            List<Grupo> listaGrupo = new List<Grupo>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    Grupo oGrupo = new Grupo();
                    oGrupo.ID = Conversion.preencheCampoInt(readerCategoria["GRUPO_ID"]);
                    oGrupo.Nome= Conversion.preencheCampoString(readerCategoria["NOM_GRUPO"]);

                    listaGrupo.Add(oGrupo);
                }
                readerCategoria.Dispose();
            }
            return listaGrupo;

        }

        
        #endregion
    }
}