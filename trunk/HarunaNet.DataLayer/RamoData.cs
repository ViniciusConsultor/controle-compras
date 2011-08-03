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
    public  class RamoData
    {
         #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public RamoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        public List<Ramo> Listar()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_MODULOACESSO");
            List<Ramo> listaRamos = new List<Ramo>();

            using (IDataReader readerRamo = this.m_db.ExecuteReader(dbc))
            {
                while (readerRamo.Read())
                {
                    Ramo oRamo = new Ramo();

                    oRamo.RamoId = Consts.Funcoes.NullOrInt(readerRamo["ID_RAMO"]);
                    oRamo.Nome = Consts.Funcoes.NullOrString(readerRamo["RAMO"]);
                    oRamo.Descricao = Consts.Funcoes.NullOrString(readerRamo["DSC_RAMO"]);
                    oRamo.Status = Consts.Funcoes.NullOrInt(readerRamo["NUM_STATUS_ID"]);

                    listaRamos.Add(oRamo);
                }
                readerRamo.Dispose();
            }
            return listaRamos;

        }
    }
}
