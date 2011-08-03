using System;
using System.Collections.Generic;
using System.Text;
using HarunaNet.Entities;
using HarunaNet.DataLayer;

namespace HarunaNet.BusinessRules.Process
{
    internal class GrupoProcess
    {
        public List<Grupo> Listar(ref Resultado resultado)
        {
            List<Grupo> listaGrupo = new GrupoData().Listar();

            if (listaGrupo.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Grupo";
                mensagem.Descricoes.Add("Nenhum Grupo encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaGrupo;
        }
    }
}
