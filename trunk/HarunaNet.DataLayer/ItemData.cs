using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.DataLayer
{
    public class ItemData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public ItemData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de módulos
        ///// </summary>
        ///// <returns>Lista de módulos</returns>
        public List<Item> Listar(int CategoriaID)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_ITEM_GETbyCATEGORIA");
            this.m_db.AddInParameter(dbc, "@CATEGORIA_ID", DbType.Int32, CategoriaID);

            List<Item> listaItem = new List<Item>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    Item oItem = new Item();
                    oItem.ItemID = Conversion.preencheCampoInt(readerCategoria["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerCategoria["NOM_ITEM"]);

                    oItem.Categoria = new CategoriaData().GetCategoriaByID(CategoriaID);
                    listaItem.Add(oItem);
                }
                readerCategoria.Dispose();
            }
            return listaItem;

        }

        public Item Listar(Item oItem)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_ITEM_GETbyID");
            this.m_db.AddInParameter(dbc, "@ID", DbType.Int32, oItem.ItemID);

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                if (readerCategoria.Read())
                {

                    oItem.ItemID = Conversion.preencheCampoInt(readerCategoria["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerCategoria["NOM_ITEM"]);

                    oItem.Categoria = new CategoriaData().GetCategoriaByID(Conversion.preencheCampoInt(readerCategoria["COD_CATEGORIA"]));
                }
            }
            return oItem;

        }

        public Item Seleciona(Item oItem)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_ITEM_GETbyID");
            this.m_db.AddInParameter(dbc, "@ID", DbType.Int32, oItem.ItemID);

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                if (readerCategoria.Read())
                {

                    oItem.ItemID = Conversion.preencheCampoInt(readerCategoria["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerCategoria["NOM_ITEM"]);

                    oItem.Categoria = new CategoriaData().GetCategoriaByID(Conversion.preencheCampoInt(readerCategoria["COD_CATEGORIA"]));
                }
            }
            return oItem;

        }

        /// <summary>
        /// Incluir um novo grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        /// 
        ///VERIFICAR LOCAL ....
        public Resultado Incluir(Ped_Item oPedItem, Int32 IDPedido)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PEDITEM_INSERE");
                this.m_db.AddInParameter(dbCommand, "@COD_PEDIDO", DbType.Int32, IDPedido);
                this.m_db.AddInParameter(dbCommand, "@COD_ITEM", DbType.Int32, oPedItem.Item.ItemID);
                this.m_db.AddInParameter(dbCommand, "@COD_PROJETO", DbType.Int32, oPedItem.Projeto.ProjetoID);
                this.m_db.AddInParameter(dbCommand, "@QUANTIDADE", DbType.Int32, oPedItem.Quantidade);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidoItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado Incluir_Item(Item oitem)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_INSERE_ITEM");
                this.m_db.AddInParameter(dbCommand, "@COD_CATEGORIA", DbType.Int32, oitem.Categoria.CategoriaID);
                this.m_db.AddInParameter(dbCommand, "@DESC_ITEM", DbType.String, oitem.Nome);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "CadItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado Atualiza(Item oItem)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_UPDATE_ITEM");

                this.m_db.AddInParameter(dbc, "@COD_ITEM", DbType.Int32, oItem.ItemID);
                if (oItem.Status > 0)
                    this.m_db.AddInParameter(dbc, "@STATUS", DbType.Int32, oItem.Status );
                if (oItem.Nome != "")
                    this.m_db.AddInParameter(dbc, "@DESC_ITEM", DbType.String, oItem.Nome);
               
                resultado.Id = Convert.ToInt32(this.m_db.ExecuteNonQuery(dbc));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "updateItem";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Item Seleciona(int ID)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_ITEM_GETbyID");
            this.m_db.AddInParameter(dbc, "@ID", DbType.Int32, ID);
            Item oItem = new Item();
            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                if (readerCategoria.Read())
                {

                    oItem.ItemID = Conversion.preencheCampoInt(readerCategoria["COD_ITEM"]);
                    oItem.Nome = Conversion.preencheCampoString(readerCategoria["NOM_ITEM"]);

                    oItem.Categoria = new CategoriaData().GetCategoriaByID(Conversion.preencheCampoInt(readerCategoria["COD_CATEGORIA"]));
                }
            }
            return oItem;
        }
    }
}
