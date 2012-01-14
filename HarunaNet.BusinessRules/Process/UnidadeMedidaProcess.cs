using System.Collections.Generic;
using HarunaNet.DataLayer;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules.Process
{
    internal class UnidadeMedidaProcess
    {
        internal List<UnidadeMedida> Listar(ref Resultado resultado)
        {
            List<UnidadeMedida> Lista = new UnidadeMedidaData().Listar();

            if (Lista.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "UnidadeMedida";
                mensagem.Descricoes.Add("Nenhuma unidade de medida encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return Lista;
        }
    }
}
