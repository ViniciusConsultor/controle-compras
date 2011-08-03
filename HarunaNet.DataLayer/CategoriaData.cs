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
    public class CategoriaData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public CategoriaData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de módulos
        ///// </summary>
        ///// <returns>Lista de módulos</returns>
        public List<Categoria> Listar()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_CATEGORIA_LISTA");
            //
            List<Categoria> listaCategoria = new List<Categoria>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.CategoriaID = Conversion.preencheCampoInt(readerCategoria["COD_CATEGORIA"]);
                    categoria.Nome = Conversion.preencheCampoString(readerCategoria["NOM_CATEGORIA"]);

                    listaCategoria.Add(categoria);
                }
                readerCategoria.Dispose();
            }
            return listaCategoria;
            
        }




        /// <summary>
        /// Selecionar um usuário especifico
        /// </summary>
        /// <param name="idPerfil">Identificador do Usuario</param>
        /// <returns>Objeto usuário preenchido</returns>
        public Categoria GetCategoriaByID(int CategoriaID)
        {
            Categoria categoriaRetorno = null;

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_CATEGORIA_GETbyID");
            this.m_db.AddInParameter(dbc, "@CATEGORIA_ID", DbType.Int32, CategoriaID);

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                if (readerCategoria.Read())
                {
                    categoriaRetorno = new Categoria();
                    categoriaRetorno.CategoriaID = Conversion.preencheCampoInt(readerCategoria["COD_CATEGORIA"]);
                    categoriaRetorno.Nome = Conversion.preencheCampoString(readerCategoria["NOM_CATEGORIA"]);


                }
                readerCategoria.Close();
            }
            return categoriaRetorno;
        }
    }
}
