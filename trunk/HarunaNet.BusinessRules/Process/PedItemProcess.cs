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
    internal class PedItemProcess
    {
        public Resultado Validar(Ped_Item oPedItem)
        {
            return new PedItemValidation(oPedItem).Validar();
        }

        public List<Compras> Listar(ref Resultado resultado)
        {
            List<Compras> listaPed_Item = new Ped_ItemData().Listar();

            if (listaPed_Item.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedItem";
                mensagem.Descricoes.Add("Nenhum pedido encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaPed_Item;
        }

        public List<Ped_Item> ListarByNumPed(int CodPedido, ref Resultado resultado)
        {
            List<Ped_Item> pPedListaItem = new Ped_ItemData().ListarByNumPed(CodPedido);

            if (pPedListaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedItem";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }
            return pPedListaItem;
        }

        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            return new Ped_ItemData().AtualizaStatus(CodPedido, Status);
        }

        public Resultado AtualizaProcessoCompra(int CategoriaID, int CC_ID)
        {
            return new Ped_ItemData().AtualizaProcessoCompra(CategoriaID, CC_ID);
        }

        public List<ProcessoCompraItem> ListaItensProcessoCompra(int CodPCompra, ref Resultado resultado)
        {
            List<ProcessoCompraItem> pPedListaItem = new Ped_ItemData().ListaItensPCompra(CodPCompra);
            List<ProcessoCompraItem> ListaAgrupada = new List<ProcessoCompraItem>();
            if (pPedListaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedItem";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                List<ProcessoCompraItem> ListaOrdenada = new List<ProcessoCompraItem>();
                int oCodItem = 0;
                foreach (ProcessoCompraItem item in pPedListaItem)
                {
                    if (oCodItem != item.CodItem)
                    {
                        oCodItem = item.CodItem;

                        ListaOrdenada = pPedListaItem.FindAll(delegate(ProcessoCompraItem itm)
                        {
                            return itm.CodItem == item.CodItem;
                        });

                        if (ListaOrdenada.Count > 1)
                        {
                            int itmsoma = 0;
                            string CodPedidos = string.Empty;
                            foreach (ProcessoCompraItem pitm in ListaOrdenada)
                            {
                                itmsoma += pitm.Quantidade;
                                CodPedidos += pitm.CodPedido + "; ";
                            }

                            item.CodPedidos = CodPedidos;
                            item.Quantidade = itmsoma;
                            ListaAgrupada.Add(item);

                        }
                        else
                        {
                            item.CodPedidos = item.CodPedido.ToString() + ";";
                            ListaAgrupada.Add(item);
                        }
                    }
                }
                resultado.Sucesso = true;
            }
            return pPedListaItem;
        }

        public List<PedListaItem> ListaItensPCompraPorCodigo(int CodPCompra, ref Resultado resultado)
        {
            List<PedListaItem> pPedListaItem = new Ped_ItemData().ListaItensPCompraPorCodigo(CodPCompra);
            List<PedListaItem> ListaAgrupada = new List<PedListaItem>();
            if (pPedListaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedItem";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                List<PedListaItem> ListaOrdenada = new List<PedListaItem>();
                int oCodItem = 0;
                foreach (PedListaItem item in pPedListaItem)
                {
                    if (oCodItem != item.CodItem)
                    {
                        oCodItem = item.CodItem;

                        ListaOrdenada = pPedListaItem.FindAll(delegate(PedListaItem itm)
                        {
                            return itm.CodItem == item.CodItem;
                        });

                        if (ListaOrdenada.Count > 1)
                        {
                            int itmsoma = 0;
                            string CodPedidos = string.Empty;
                            foreach (PedListaItem pitm in ListaOrdenada)
                            {
                                itmsoma += pitm.Quantidade;
                                CodPedidos += pitm.CodPedido + "; ";
                            }

                            item.CodPedidos = CodPedidos;
                            item.Quantidade = itmsoma;
                            ListaAgrupada.Add(item);

                        }
                        else
                        {
                            item.CodPedidos = item.CodPedido.ToString() + ";";
                            ListaAgrupada.Add(item);
                        }
                    }
                }
                resultado.Sucesso = true;
            }
            return pPedListaItem;
        }

        public List<PedListaItem> ListaItensCompra(int CategoriaID, int CC_ID, ref Resultado resultado)
        {
            List<PedListaItem> pPedListaItem = new Ped_ItemData().ListaItensCompra(CategoriaID, CC_ID);
            List<PedListaItem> ListaAgrupada = new List<PedListaItem>();
            if (pPedListaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedItem";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                List<PedListaItem> ListaOrdenada = new List<PedListaItem>();
                List<PedListaItem> ListaOrdenada2 = new List<PedListaItem>();
                

                int oCodItem = 0;
                string Outros = String.Empty;

                foreach (PedListaItem item in pPedListaItem)
                {

                    if (oCodItem != item.Item.ItemID || Outros != item.Outros)
                    {
                        oCodItem = item.Item.ItemID;
                        Outros = item.Outros;
                        ListaOrdenada2 = pPedListaItem.FindAll(delegate(PedListaItem itm)
                        {
                            return itm.Item.ItemID == item.Item.ItemID;
                        });

                        ListaOrdenada = ListaOrdenada2.FindAll(delegate(PedListaItem itm)
                        {
                            return itm.Outros == item.Outros;
                        });

                        if (ListaOrdenada.Count > 1)
                        {
                            int itmsoma = 0;
                            string CodPedidos = string.Empty;
                            foreach (PedListaItem pitm in ListaOrdenada)
                            {
                                itmsoma += pitm.Quantidade;
                                CodPedidos += pitm.CodPedido + "; ";
                            }

                            item.CodPedidos = CodPedidos;
                            item.Quantidade = itmsoma;
                            ListaAgrupada.Add(item);


                        }
                        else
                        {
                            item.CodPedidos = item.CodPedido.ToString() + ";";

                            ListaAgrupada.Add(item);
                        }
                    }
                }
                resultado.Sucesso = true;
            }

            return ListaAgrupada;
        }

        public Resultado AtualizaValor(List<Ped_Item> ListaPedItens)
        {
            Resultado resultado = new Resultado();
            foreach (Ped_Item item in ListaPedItens)
            {
                resultado = new Ped_ItemData().AtualizaValor(item);
            }
            return resultado;
        }

        public Resultado AtualizaStatusProcessoCompra(ProcessoCompra CC_ID)
        {
            return new Ped_ItemData().AtualizaStatusProcessoCompra(CC_ID);
        }

        public List<Status> ListaStatus(ref Resultado resultado)
        {
            List<Status> pStatusListaItem = new Ped_ItemData().ListarStatus();

            if (pStatusListaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "StatusPedidoItem";
                mensagem.Descricoes.Add("Erro ao Carregar Status do Item do Pedido!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return pStatusListaItem;
        }

        public Resultado AtualizaItemCompra(ProcessoCompraItem pPCItem)
        {
            Resultado resultado = new Resultado();
            ProcessoCompraItemValidation Validation = new ProcessoCompraItemValidation(pPCItem);

            resultado = Validation.ValidarProcessoCompraItem();

            if (resultado.Sucesso)
            {
                if (pPCItem.NextStatus != 5 && pPCItem.NextStatus != 6)
                {
                    resultado = new PedItemValidation().ValidarProcessoCompraItem(pPCItem);
                    if (resultado.Sucesso == false)
                    {
                        resultado = new Ped_ItemData().IncluirCompraRestante(pPCItem);
                    }
                }
                resultado = new Ped_ItemData().AtualizaItemCompra(pPCItem);
            }

            return resultado;
        }
    }
}
