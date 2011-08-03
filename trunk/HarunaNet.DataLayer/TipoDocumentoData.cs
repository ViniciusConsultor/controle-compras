using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.DataLayer
{
    public class TipoDocumentoData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public TipoDocumentoData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de módulos
        ///// </summary>
        ///// <returns>Lista de módulos</returns>
        public List<TipoDocumento> Listar()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_TPDOCUMENTO_LISTA");

            List<TipoDocumento> listaTpDocumento = new List<TipoDocumento>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    TipoDocumento oItem = new TipoDocumento();
                    oItem.Codigo = Conversion.preencheCampoInt(readerCategoria["COD_TPDOCUMENTO"]);
                    oItem.Descricao = Conversion.preencheCampoString(readerCategoria["NOM_DOCUMENTO"]);

                    listaTpDocumento.Add(oItem);
                }
                readerCategoria.Dispose();
            }
            return listaTpDocumento;

        }

       
    }
}
