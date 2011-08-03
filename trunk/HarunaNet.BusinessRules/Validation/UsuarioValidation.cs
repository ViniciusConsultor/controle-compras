using System;
using System.Collections.Generic;
using System.Text;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;
using System.Security.Cryptography;

namespace HarunaNet.BusinessRules.Validation
{
    internal class UsuarioValidation
    {
        #region Atributos

        private Usuario m_usuario;
        private Resultado m_resultado = new Resultado();
        private List<Mensagem> m_mensagem = new List<Mensagem>();

        #endregion

        #region Construtor

        public UsuarioValidation(Usuario usuario)
        {
            this.m_usuario = usuario;
            m_resultado.Sucesso = true;
        }

        /// <summary>        
        /// Construtor Vazio
        /// </summary>
        public UsuarioValidation() { }

        #endregion

        //#region Métodos

        //#region Validação de Campos
        ///// <summary>
        ///// Verificar se já existe um algum usuário com mesmo login que está sendo pesquisado
        ///// </summary>
        internal Resultado ValidarSenha(Usuario oUsuario)
        {
            //UsuarioData usuarioData = new UsuarioData();
            Mensagem mensagem = new Mensagem();
            Resultado resultado = new Resultado();
            Usuario usuarioRetorno = new UsuarioData().Autenticar(oUsuario, ref resultado);

            if (resultado.Sucesso)
            {
                //Criptofrafa a senha atual
                MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
                UTF8Encoding encode = new UTF8Encoding();
                byte[] senhacripto = hash.ComputeHash(encode.GetBytes(oUsuario.Senha));

                //Obtém a senha atual do BD
                byte[] pwd = (byte[])usuarioRetorno.SenhaCript;
                if (Consts.Funcoes.CompararIgualdadeByteArray(pwd, senhacripto))
                {
                    m_resultado.Sucesso = true;
                }
                else
                {
                    mensagem.Campo = "Login";
                    mensagem.Descricoes.Add("Usuário ou senha inválidos!");
                    m_resultado.Mensagens.Add(mensagem);
                    m_resultado.Sucesso = false;
                }

            }
            else
            {
                mensagem.Campo = "Login";
                mensagem.Descricoes.Add("Usuário ou senha inválidos!");
                m_resultado.Mensagens.Add(mensagem);
                m_resultado.Sucesso = false;
            }

            
            return m_resultado;
        }

        ///// <summary>
        ///// O login deve ser obrigatório        
        ///// </summary>        
        //internal bool ValidarLoginInvalido()
        //{
        //    bool retorno = true;
        //    Mensagem mensagem = new Mensagem();
        //    mensagem.Campo = "Login";

        //    if (m_usuario.Login == string.Empty)
        //    {
        //        mensagem.Descricoes.Add("Login não informado!");
        //        m_resultado.Mensagens.Add(mensagem);
        //        m_resultado.Sucesso = false;
        //        retorno = false;
        //    }

        //    return retorno;
        //}

        ///// <summary>
        ///// Deve existir pelo meno um tipoAcesso
        ///// </summary>
        ///// <returns></returns>
        //internal Resultado ValidarPerfil()
        //{
        //    m_resultado.Sucesso = (m_usuario.ListaPerfil.Count > 0);

        //    if (!m_resultado.Sucesso)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Add("Nenhum tipoAcesso selecionado para o usuário!");
        //        m_resultado.Mensagens.Add(mensagem);
        //    }

        //    return m_resultado;
        //}
        //#endregion

        ///// <summary>
        ///// Validar inclusão do usuário        
        ///// </summary>        
        //public Resultado ValidarInclusao()
        //{
        //    if (ValidarLoginInvalido())
        //    {
        //        ValidarLoginExistente(m_usuario.Login);
        //        if (m_resultado.Sucesso)
        //        {
        //            ValidarPerfil();
        //        }
        //    }
        //    return m_resultado;
        //}

        ///// <summary>
        ///// Validar alteração do usuário        
        ///// </summary>        
        public Resultado ValidarLogin()
        {
            ValidarSenha(this.m_usuario);
            return m_resultado;
        }
        //#endregion
    }
}
