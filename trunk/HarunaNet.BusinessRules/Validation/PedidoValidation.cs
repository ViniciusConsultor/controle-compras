using System;
using System.Collections.Generic;
using System.Text;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;
using System.Security.Cryptography;


namespace HarunaNet.BusinessRules.Validation
{
    internal class PedidoValidation
    {
        //#region Métodos

        //#region Validação de Campos
        ///// <summary>
        ///// Verificar se já existe um algum usuário com mesmo login que está sendo pesquisado
        ///// </summary>
        internal Resultado ValidarPedido(Pedido oPedido)
        {
            //UsuarioData usuarioData = new UsuarioData();
            Mensagem mensagem = new Mensagem();
            Resultado resultado = new Resultado();

            if (oPedido.Itens != null )
            {
                resultado.Sucesso = true;
            }
            else
            {
                 mensagem.Campo = "Pedido";
                mensagem.Descricoes.Add("Adicione um ao menos um item para fechar o Pedido!");
                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
                resultado.Sucesso = false;
            }
            return resultado;
        }
    }
}
