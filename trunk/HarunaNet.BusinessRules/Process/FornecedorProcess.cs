using System.Collections.Generic;

using HarunaNet.DataLayer;
using HarunaNet.Entities;


namespace HarunaNet.BusinessRules.Process
{
    internal class FornecedorProcess
    {
        public List<Fornecedor> Listar(ref Resultado resultado, Fornecedor oFornecedor)
        {
            List<Fornecedor> listaFornecedor = new FornecedorData().Listar(oFornecedor);

            if (listaFornecedor.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Add("Nenhuma Fornecedor encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                resultado.Sucesso = true;
            }

            return listaFornecedor;
        }

        public Resultado Inserir(Fornecedor oFornecedor)
        {
            Resultado resultado = new FornecedorData().Inserir(oFornecedor);
            if (resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Add("Fornecedor cadastrado com sucesso");
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Fornecedor Obter(ref Resultado resultado, int FornecedorID)
        {
            Fornecedor oFornecedor = new FornecedorData().Obter(FornecedorID);
            
            if (resultado.Sucesso)
            {
                resultado.Sucesso = true;
            }
            else
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Add("Nenhuma Fornecedor encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }

            return oFornecedor;
        }
       

        public Resultado Atualizar(Fornecedor oFornecedor)
        {
            Resultado resultado = new FornecedorData().Atualizar(oFornecedor);
            if (resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Add("Fornecedor alterado com sucesso");
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado Excluir(int FornecedorID)
        {
            Resultado resultado = new FornecedorData().Excluir(FornecedorID);

            if (!resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Insert(0, "Erro ao excluir Fornecedor!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;
        }
    }
}
