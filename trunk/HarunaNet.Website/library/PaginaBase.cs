using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

namespace HarunaNet.SisWeb
{
    public class PaginaBase : System.Web.UI.Page
    {
        protected IList ListaGridPersistida
        {
            get { return (IList)ViewState["listaGrid"]; }
            set { ViewState["listaGrid"] = value;}
        }

       
        public enum StatusItemPedido
        {
            Em_Aberto= 1,
            Em_Andamento = 2,
            Aguardando_Entrega = 3,
            Finalizado = 4,
            Indisponível = 5,
            Cancelado = 6
        }


        public enum StatusPedido
        {
            Em_Aberto = 1,
            Em_Andamento = 2,
            Aguardando_Entrega = 3,
            Finalizado = 4,
            Finalizado_Pendencias = 5,
            Cancelado = 6
        }

    }
}