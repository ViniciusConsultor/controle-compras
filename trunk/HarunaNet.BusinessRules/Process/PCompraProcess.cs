using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

using HarunaNet.DataLayer;
using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using HarunaNet.BusinessRules.Validation;
using HarunaNet.Framework.Utils;
namespace HarunaNet.BusinessRules.Process
{
    public class PCompraProcess
    {
        public List<ProcessoCompra> Listar(ref Resultado resultado)
        {
            List<ProcessoCompra> listaPCompras = new PCompraData().Listar();
            List<ProcessoCompra> ListaAgrupada = new List<ProcessoCompra>();
            if (listaPCompras.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "ProcessoCompra";
                mensagem.Descricoes.Add("Nenhum Processo de Compra Iniciado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                List<ProcessoCompra> ListaOrdenada = new List<ProcessoCompra>();
                int oCodProcesso = 0;
                
                foreach (ProcessoCompra item in listaPCompras)
                {
                    if (oCodProcesso != item.CodProcessoCompra)
                    {
                        oCodProcesso = item.CodProcessoCompra;

                        ListaOrdenada = listaPCompras.FindAll(delegate(ProcessoCompra itm)
                        {
                            return itm.CodProcessoCompra == item.CodProcessoCompra;
                        });

                        if (ListaOrdenada.Count > 1)
                        {
                            string CodProcesso = string.Empty;
                            foreach (ProcessoCompra pitm in ListaOrdenada)
                            {
                                CodProcesso += pitm.Pedidos + "; ";
                            }

                            item.Pedidos = CodProcesso;
                            ListaAgrupada.Add(item);

                        }
                        else
                        {
                            item.Pedidos = item.Pedidos.ToString() + ";";
                            ListaAgrupada.Add(item);
                        }
                    }
                }
                resultado.Sucesso = true;
            }

            return ListaAgrupada;
        }
    }
}
