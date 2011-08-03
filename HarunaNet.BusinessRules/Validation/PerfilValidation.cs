using System;
using System.Collections.Generic;
using System.Text;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.BusinessRules.Validation
{
    internal class PerfilValidation
    {
        #region Atributos

        private Perfil m_perfil;
        private Resultado m_resultado = new Resultado();
        private List<Mensagem> m_mensagem = new List<Mensagem>();

        #endregion

        #region Construtor

        public PerfilValidation(Perfil perfil)
        {
            this.m_perfil = perfil;
            m_resultado.Sucesso = true;
        }

        /// <summary>        
        /// Construtor Vazio
        /// </summary>
        public PerfilValidation() { }

        #endregion

        //#region Métodos

        //#region Validação de Campos
        ///// <summary>
        ///// Verificar se já existe um algum funcionalidade com mesmo nome que está sendo pesquisado
        ///// </summary>
        //internal void ValidarPerfilExistente()
        //{
        //    PerfilData perfilData = new PerfilData();
        //    Mensagem mensagem = new Mensagem();
        //    List<Perfil> listaPerfis = perfilData.Listar(m_perfil.Nome);

        //    m_resultado.Sucesso = true;

        //    if (listaPerfis.Count > 0)
        //    {
        //        if (listaPerfis[0].Id != m_perfil.Id)
        //        {
        //            mensagem.Campo = "Nome Perfil";
        //            mensagem.Descricoes.Add("Nome do funcionalidade já cadastrado!");
        //            m_resultado.Mensagens.Add(mensagem);
        //            m_resultado.Sucesso = false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// O nome deve ser obrigatório        
        ///// </summary>        
        //internal void ValidarPerfilInvalido()
        //{
        //    m_resultado.Sucesso = true;
        //    Mensagem mensagem = new Mensagem();
        //    mensagem.Campo = "Nome Perfil";

        //    if (m_perfil.Nome == string.Empty)
        //    {
        //        mensagem.Descricoes.Add("Nome do funcionalidade não informado!");
        //        m_resultado.Mensagens.Add(mensagem);
        //        m_resultado.Sucesso = false;
        //    }
        //}

        ///// <summary>
        ///// Deve existir pelo menos um acesso
        ///// </summary>
        ///// <returns></returns>
        //internal void ValidarAcesso()
        //{
        //    m_resultado.Sucesso = false;

        //    foreach (Modulo modulo in m_perfil.ListaModulo)
        //    {
        //        foreach (Funcionalidade funcionalidade in modulo.ListaFuncionalidade)
        //        {
        //            foreach (TipoAcesso tipoAcesso in funcionalidade.ListaTipoAcesso)
        //            {
        //                if (tipoAcesso.Selecionado)
        //                {
        //                    m_resultado.Sucesso = true;
        //                    break;
        //                }
        //            }
        //            if (m_resultado.Sucesso) break;
        //        }
        //        if (m_resultado.Sucesso) break;
        //    }

        //    if (!m_resultado.Sucesso)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil Acesso";
        //        mensagem.Descricoes.Add("Nenhum acesso selecionado para o funcionalidade!");
        //        m_resultado.Mensagens.Add(mensagem);
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// Validar inclusão do funcionalidade
        ///// </summary>        
        //public Resultado ValidarInclusao()
        //{
        //    ValidarPerfilInvalido();
        //    if (m_resultado.Sucesso)
        //    {
        //        ValidarPerfilExistente();
        //        if (m_resultado.Sucesso)
        //        {
        //            ValidarAcesso();
        //        }
        //    }
        //    return m_resultado;
        //}

        ///// <summary>
        ///// Validar alteração do funcionalidade        
        ///// </summary>        
        //public Resultado ValidarAlteracao()
        //{
        //    ValidarPerfilInvalido();
        //    if (m_resultado.Sucesso)
        //    {
        //        ValidarPerfilExistente();
        //        if (m_resultado.Sucesso)
        //        {
        //            ValidarAcesso();
        //        }
        //    }
        //    return m_resultado;
        //}
        //#endregion
    }
}
