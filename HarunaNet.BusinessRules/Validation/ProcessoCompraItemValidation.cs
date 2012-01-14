using System;
using System.Collections.Generic;
using System.Text;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;


namespace HarunaNet.BusinessRules.Validation
{
    public class ProcessoCompraItemValidation
    {
        private ProcessoCompraItem m_ProcessoCompraItem;

        private Resultado m_resultado = new Resultado();
        private List<Mensagem> m_mensagem = new List<Mensagem>();

        public ProcessoCompraItemValidation()
        {
            this.m_resultado.Sucesso = true;
        }

        public ProcessoCompraItemValidation(ProcessoCompraItem pProcessoCompraItem)
        {
            this.m_ProcessoCompraItem = pProcessoCompraItem;
            this.m_resultado.Sucesso = true;
        }

        public Resultado ValidarProcessoCompraItem()
        {
            m_resultado.Sucesso = true;
            Mensagem mensagem;

            if (m_ProcessoCompraItem.NextStatus != 5 && m_ProcessoCompraItem.NextStatus != 6)
            {

                //if (m_ProcessoCompraItem.DataCompra == DateTime.MinValue || m_ProcessoCompraItem.DataCompra > DateTime.Now.Date)
                //{
                //    mensagem = new Mensagem();
                //    mensagem.Campo = "DataCompra";
                //    mensagem.Descricoes.Add("Data da compra inválida!");
                //    m_resultado.Mensagens.Add(mensagem);
                //    m_resultado.Sucesso = false;
                //}
                if (m_ProcessoCompraItem.ValorUnitario == 0)
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "Valor";
                    mensagem.Descricoes.Add("Informe o valor unitário!");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }
                if (m_ProcessoCompraItem.QuantidadeComprada < 1)
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "QuantidadeComprada";
                    mensagem.Descricoes.Add("Quantidade obrigatório!");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }

                if (m_ProcessoCompraItem.QuantidadeComprada > m_ProcessoCompraItem.Quantidade)
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "QuantidadeComprada";
                    mensagem.Descricoes.Add("Quantidade comprada inválida!");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }


                if (m_ProcessoCompraItem.Fornecedor.FornecedorID < 1)
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "Fornecedor";
                    mensagem.Descricoes.Add("Fornecedor obrigatório!");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }

                //if (m_ProcessoCompraItem.DataPrevisaoEntrega == DateTime.MinValue )
                //{
                //    mensagem = new Mensagem();
                //    mensagem.Campo = "PrevisaoEntrega";
                //    mensagem.Descricoes.Add("Data de previsão de entrega inválida!");
                //    m_resultado.Mensagens.Add(mensagem);
                //    m_resultado.Sucesso = false;
                //}


                //if (m_ProcessoCompraItem.DataEntrega > DateTime.MinValue & m_ProcessoCompraItem.DataEntrega < DateTime.Now.Date)
                //{
                //    mensagem = new Mensagem();
                //    mensagem.Campo = "DataEntrega";
                //    mensagem.Descricoes.Add("Data de entrega inválida!");
                //    m_resultado.Mensagens.Add(mensagem);
                //    m_resultado.Sucesso = false;
                //}
            }
            else if (m_ProcessoCompraItem.NextStatus == 5)
            {
                if (m_ProcessoCompraItem.DescMotivoCancelamento.Trim() == "")
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "DescMotivoIndisponivel";
                    mensagem.Descricoes.Add("Campo Descrição obrigatório.");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }


            }
            else if (m_ProcessoCompraItem.NextStatus == 6)
            {
                if (m_ProcessoCompraItem.DescMotivoCancelamento.Trim() == "")
                {
                    mensagem = new Mensagem();
                    mensagem.Campo = "DescMotivoCancelamento";
                    mensagem.Descricoes.Add("Motivo do cancelamento obrigatório.");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }


            }
            return m_resultado;
        }
    }
}
