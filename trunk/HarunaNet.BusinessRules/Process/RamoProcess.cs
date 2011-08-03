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
    internal class RamoProcess
    {
        public List<Ramo> Listar(ref Resultado resultado)
        {
            List<Ramo> listaRamo = new RamoData().Listar();

            if (listaRamo.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Ramo";
                mensagem.Descricoes.Add("Nenhum ramo encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaRamo;
        }
    }
}
