using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.DataLayer
{
    public class UnidadeMedidaData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public UnidadeMedidaData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        public List<UnidadeMedida> Listar()
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_UNIDADEMEDIDA_LISTAR");
            List<UnidadeMedida> Lista = new List<UnidadeMedida>();

            using (IDataReader reader = this.m_db.ExecuteReader(dbc))
            {
                while (reader.Read())
                {
                    UnidadeMedida ounidadeMedida = new UnidadeMedida();

                    ounidadeMedida.Id = Consts.Funcoes.NullOrInt(reader["COD_UNIDADEMEDIDA"]);
                    ounidadeMedida.Nome = Consts.Funcoes.NullOrString(reader["NOM_COMPLETO"]);
                    ounidadeMedida.NomeAbreviado = Consts.Funcoes.NullOrString(reader["NOM_ABREVIADO"]);

                    Lista.Add(ounidadeMedida);
                }
                reader.Dispose();
            }
            return Lista;

        }

        public UnidadeMedida Obter(Int32 IdunidadeMedida)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SPR_UNIDADEMEDIDA_OBTER");
            this.m_db.AddInParameter(dbc, "@COD_UNIDADEMEDIDA", DbType.Int32, IdunidadeMedida);
            UnidadeMedida unidadeMedida = null;
            using (IDataReader readerProjetos = this.m_db.ExecuteReader(dbc))
            {
                if (readerProjetos.Read())
                {
                    unidadeMedida = new UnidadeMedida();
                    unidadeMedida.Id = Conversion.preencheCampoInt(readerProjetos["COD_UNIDADEMEDIDA"]);
                    unidadeMedida.Nome = Conversion.preencheCampoString(readerProjetos["NOM_COMPLETO"]);
                    unidadeMedida.NomeAbreviado = Conversion.preencheCampoString(readerProjetos["NOM_ABREVIADO"]);
                }
            }
            return unidadeMedida;
        }
    }
}
