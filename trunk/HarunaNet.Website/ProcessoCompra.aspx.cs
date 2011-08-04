using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using Microsoft.Reporting.WebForms;

namespace HarunaNet.SisWeb
{
    public partial class ProcessoCompraWeb : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Resultado resultado = new Resultado();
                                
                List<ProcessoCompra> oPCompras = new List<ProcessoCompra>();
                oPCompras = new PCompra_Facade().Listar(ref resultado);

                if (resultado.Sucesso)
                {
                    ListaGridPersistida = oPCompras;
                    gvListaCompra.DataSource = (List<ProcessoCompra>)ListaGridPersistida;
                    gvListaCompra.DataBind();
                }

            }

        }
        
        protected void gvListaCompra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                (e.Row.FindControl("btnGerarPlanilha") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                if (((ProcessoCompra)(e.Row.DataItem)).Status == 2)
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromArgb(255, 94, 94);
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }
        }

        protected void gvListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
           
        }

        protected void gvListaCompra_Sorting(object sender, GridViewSortEventArgs e)
        {
            //if (sortExpression != e.SortExpression)
            //{
            //    sortDirection = 1; //ASC
            //}
            //else
            //{
            //    sortDirection *= -1; //DESC
            //}

            //sortExpression = e.SortExpression;
            //PreencheGrid();
        }

        protected void gvListaCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaCompra.PageIndex = e.NewPageIndex;
            gvListaCompra.DataSource = (List<ProcessoCompra>)ListaGridPersistida;
            gvListaCompra.DataBind();
        }

        protected void hlk_DataProcesso_Click(object sender, EventArgs e)
        {
            //grdOnda.PageIndex = 0;
            //PreencheGrid();
            //ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "pesquisaFiltro", "ExibirPesquisa();", true);
        }

        protected void ExportarXLS(int Cod)
        {

            ReportViewer rvExporter = new ReportViewer();

            rvExporter.ProcessingMode = ProcessingMode.Local;
            rvExporter.LocalReport.ReportPath = Server.MapPath(@"~\Reports\ListadeCompras.rdlc");
            rvExporter.LocalReport.DataSources.Add(new ReportDataSource("Lista", GetDados(Cod)));
            rvExporter.LocalReport.Refresh();

            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();

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
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.{1}", DateTime.Now.ToString("yyyy-MM-dd") + "Planilha Processo de Compra Numero " + resultado.Id.ToString().PadLeft(6, '0') + "R", fileNameExtension));
            Response.BinaryWrite(exportBytes);
            Response.Flush();
            Response.End();

            rvExporter.Dispose();

        }

        public List<PedListaItem> GetDados(int Cod)
        {
            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
            List<PedListaItem> oPedidosListaItem = new List<PedListaItem>();

            oPedidosListaItem = oPedFacade.ListaItensPCompraPorCodigo(Cod, ref resultado);

            return oPedidosListaItem;
        }

        //public List<PedListaItem> GetDados()
        //{

        //    Resultado resultado = new Resultado();
        //    Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
        //    List<PedListaItem> oPedidosListaItem = new List<PedListaItem>();

        //    int CategoriaID = Convert.ToInt32(Request.QueryString["categoriaid"]);
        //    int CC_ID = Convert.ToInt32(Request.QueryString["CC"]);
        //    oPedidosListaItem = oPedFacade.ListaItensCompra(CategoriaID, CC_ID, ref resultado);

        //    return oPedidosListaItem;
        //}


        protected void btnGerarPlanilha_Click(object sender, ImageClickEventArgs e)
        {

            int Cod = Convert.ToInt32(gvListaCompra.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString());

            ExportarXLS(Cod);

        }
    }
}