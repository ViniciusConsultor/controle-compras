using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.Reporting.WebForms;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using System.Web.UI.WebControls;

namespace HarunaNet.SisWeb
{
    public partial class PedidosListaItem : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaGridPersistida = GetDados();
                gvListaPed.DataSource = (List<PedListaItem>)ListaGridPersistida;
                gvListaPed.DataBind();
            }
        }

        public List<PedListaItem> GetDados()
        {

            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
            List<PedListaItem> oPedidosListaItem = new List<PedListaItem>();

            int CategoriaID = Convert.ToInt32(Request.QueryString["categoriaid"]);
            int CC_ID = Convert.ToInt32(Request.QueryString["CC"]);
            oPedidosListaItem = oPedFacade.ListaItensCompra(CategoriaID, CC_ID, ref resultado);

            return oPedidosListaItem;
        }

        protected void ExportarXLS()
        {

            ReportViewer rvExporter = new ReportViewer();

            rvExporter.ProcessingMode = ProcessingMode.Local;
            rvExporter.LocalReport.ReportPath = Server.MapPath(@"~\Reports\ListadeCompras.rdlc");
            rvExporter.LocalReport.DataSources.Add(new ReportDataSource("Lista", GetDados()));
            rvExporter.LocalReport.Refresh();

            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();

            int CategoriaID = Convert.ToInt32(Request.QueryString["categoriaid"]);
            int CC_ID = Convert.ToInt32(Request.QueryString["CC"]);
            resultado = new Ped_ItemFacade().AtualizaProcessoCompra(CategoriaID, CC_ID);

            ////Exportar para PDF
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streamids;
            byte[] exportBytes = rvExporter.LocalReport.Render("Excel", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.{1}",  DateTime.Now.ToString("yyyy-MM-dd") + "Planilha Processo de Compra Numero " + resultado.Id.ToString().PadLeft(6,'0') , fileNameExtension));
            Response.BinaryWrite(exportBytes);
            Response.Flush();
            Response.End();

            rvExporter.Dispose();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            ExportarXLS();
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PedidosLista.aspx", false);
        }

        protected void gvListaPed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaPed.PageIndex = e.NewPageIndex;
            gvListaPed.DataSource = (List<PedListaItem>)ListaGridPersistida;
            gvListaPed.DataBind();
        }

      

      
    }
}