using System.Collections.Generic;

using HarunaNet.DataLayer;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules.Process
{
    internal class TipoDocumentoProcess
    {
        public List<TipoDocumento> Listar(ref Resultado resultado)
        {
            List<TipoDocumento> listaItem = new TipoDocumentoData().Listar();

            if (listaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "TipoDocumento";
                mensagem.Descricoes.Add("Nenhum Tipo de Documento Fiscal encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                resultado.Sucesso = true;
            }

            return listaItem;
        }


    }
}
