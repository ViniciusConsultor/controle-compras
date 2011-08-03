using System.Collections.Generic;
using HarunaNet.DataLayer;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules.Process
{
    internal class CategoriaProcess
    {
        public List<Categoria> Listar(ref Resultado resultado)
        {
            List<Categoria> listaCategoria = new CategoriaData().Listar();

            if (listaCategoria.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Categoria";
                mensagem.Descricoes.Add("Nenhuma categoria encontrada!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaCategoria;
        }
    }
}
