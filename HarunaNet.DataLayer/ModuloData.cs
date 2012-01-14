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
    public class ModuloData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public ModuloData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de módulos
        ///// </summary>
        ///// <returns>Lista de módulos</returns>
        public List<Modulo> Listar(int IDPERFIL)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_MODULOACESSO");
            this.m_db.AddInParameter(dbc, "@IDPERFIL", DbType.Int32, IDPERFIL);
            //
            List<Modulo> listaModulos = new List<Modulo>();

            using (IDataReader readerModulo = this.m_db.ExecuteReader(dbc))
            {
                while (readerModulo.Read())
                {
                    Modulo modulo = new Modulo();
                    modulo.ModuloId = Conversion.preencheCampoInt(readerModulo["MODULO_ID"]);
                    modulo.Descricao = Conversion.preencheCampoString(readerModulo["DESCRICAO"]);
                    modulo.PodeAcessar = Conversion.preencheCampoInt(readerModulo["PODE_ACESSAR"]);
                    modulo.PaginaWeb = Conversion.preencheCampoString(readerModulo["PAGINA_WEB"]);
                    modulo.EnderecoWeb = Conversion.preencheCampoString(readerModulo["PAGINA_WEB"] + ".aspx");
                    modulo.ItemMenu = Conversion.preencheCampoBoolean(readerModulo["ITEM_MENU"]);

                    listaModulos.Add(modulo);
                }
                readerModulo.Dispose();
            }
            return listaModulos;
            
        }

        public List<menu> ListarMenu(int IDPERFIL)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_MODULOACESSOMENU");
            this.m_db.AddInParameter(dbc, "@IDPERFIL", DbType.Int32, IDPERFIL);
            //
            List<menu> listaMenu = new List<menu>();

            using (IDataReader readerMenu = this.m_db.ExecuteReader(dbc))
            {
                while (readerMenu.Read())
                {
                    if (Conversion.preencheCampoInt(readerMenu["PODE_ACESSAR"]) == 1)
                    {
                        menu oMenu = new menu();
                        oMenu.CodMenu = Conversion.preencheCampoInt(readerMenu["MODULO_ID"]);
                        oMenu.ItemMenu = Conversion.preencheCampoString(readerMenu["DESCRICAO"]);
                        oMenu.Pagina = Conversion.preencheCampoString(readerMenu["PAGINA_WEB"]);
                        oMenu.ItemPai = Conversion.preencheCampoInt(readerMenu["ITEM_PAI"]);
                        oMenu.Visivel = Conversion.preencheCampoBoolean(readerMenu["ITEM_MENU"]);
                        oMenu.itens = ListarItensMenu(Conversion.preencheCampoInt(readerMenu["MODULO_ID"]));

                        listaMenu.Add(oMenu);
                    }
                   
                }
                readerMenu.Dispose();
            }
            return listaMenu;
                
        }

        private List<menu> ListarItensMenu(int IDModulo)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_MODULOACESSOFILHO");
            this.m_db.AddInParameter(dbc, "@MODULO_ID", DbType.Int32, IDModulo);
            //
            List<menu> listaMenu = new List<menu>();

            using (IDataReader readerMenu = this.m_db.ExecuteReader(dbc))
            {
                while (readerMenu.Read())
                {
                    if (Conversion.preencheCampoInt(readerMenu["PODE_ACESSAR"]) == 1)
                    {
                        menu oMenu = new menu();
                        oMenu.ItemMenu = Conversion.preencheCampoString(readerMenu["DESCRICAO"]);
                        oMenu.Pagina = Conversion.preencheCampoString(readerMenu["PAGINA_WEB"]);
                        oMenu.Visivel = Conversion.preencheCampoBoolean(readerMenu["ITEM_MENU"]);
                        
                        listaMenu.Add(oMenu);
                    }

                }
                readerMenu.Dispose();
            }
            return listaMenu.Count >0 ? listaMenu : null;

        }




        ///// <summary>
        ///// Selecionar a lista de funcionalidades para o módulo especificado
        ///// </summary>
        ///// <param name="modulo">Módulo para consulta</param>
        ///// <returns>Lista de funcionalidades</returns>
        //public List<Funcionalidade> ListarFuncionalidade(Modulo modulo)
        //{
        //    DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.sp_pgv_FuncionalidadeSelecionaLista");
        //    this.m_db.AddInParameter(dbCommand, "@id_modulo", DbType.Int32, modulo.Id);
            
        //    List<Funcionalidade> listaFuncionalidades = new List<Funcionalidade>();

        //    using (IDataReader readerFuncionalidade = this.m_db.ExecuteReader(dbCommand))
        //    {
        //        while (readerFuncionalidade.Read())
        //        {
        //            Funcionalidade funcionalidade = new Funcionalidade();
        //            funcionalidade.Id = Conversion.preencheCampoInt(readerFuncionalidade["id_funcionalidade"]);
        //            funcionalidade.Nome = Conversion.preencheCampoString(readerFuncionalidade["nm_funcionalidade"]);
        //            funcionalidade.Descricao = Conversion.preencheCampoString(readerFuncionalidade["ds_funcionalidade"]);
        //            funcionalidade.MenuPai = Conversion.preencheCampoString(readerFuncionalidade["nm_menuPai"]);

        //            listaFuncionalidades.Add(funcionalidade);
        //        }
        //        readerFuncionalidade.Dispose();
        //    }
        //    return listaFuncionalidades;
        //}

        //public List<TipoAcesso> ListarTipoAcesso(int idFuncionalidade)
        //{
        //    DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.sp_pgv_TipoAcessoSelecionaLista");

        //    if (idFuncionalidade > 0)
        //    {
        //        this.m_db.AddInParameter(dbCommand, "@id_funcionalidade", DbType.Int32, idFuncionalidade);
        //    }

        //    List<TipoAcesso> listaTipoAcessos = new List<TipoAcesso>();

        //    using (IDataReader readerTipoAcesso = this.m_db.ExecuteReader(dbCommand))
        //    {
        //        while (readerTipoAcesso.Read())
        //        {
        //            TipoAcesso tipoAcesso = new TipoAcesso();
        //            tipoAcesso.Id = Conversion.preencheCampoInt(readerTipoAcesso["id_tipoAcesso"]);
        //            tipoAcesso.Nome = Conversion.preencheCampoString(readerTipoAcesso["nm_tipoAcesso"]);
        //            tipoAcesso.Disponivel = Conversion.preencheCampoBoolean(readerTipoAcesso["is_disponivel"]);

        //            listaTipoAcessos.Add(tipoAcesso);
        //        }
        //        readerTipoAcesso.Dispose();
        //    }
        //    return listaTipoAcessos;
        //}
        //#endregion
    }
}
