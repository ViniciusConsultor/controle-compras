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
    internal class ProjetosProcess
    {

        public List<Projetos> Listar(ref Resultado resultado)
        {
            List<Projetos> listaProjetos = new ProjetosData().Listar();

            if (listaProjetos.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Projetos";
                mensagem.Descricoes.Add("Nenhuma projeto encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaProjetos;
        }
    }
}
