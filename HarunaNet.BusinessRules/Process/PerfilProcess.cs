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
    internal class PerfilProcess
    {
        ///// <summary>
        ///// Lista vários perfis por uma condição
        ///// </summary>
        ///// <param name="ativo">Nome do tipoAcesso para filtro</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de Perfil</returns>
        public List<Perfil> Listar(ref Resultado resultado)
        {
            List<Perfil> listaPerfil = new PerfilData().Listar();

            if (listaPerfil.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Perfil";
                mensagem.Descricoes.Add("Nenhum Perfil encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaPerfil;
        }


        public Perfil Seleciona(int PerfilID, ref Resultado resultado)
        {
            Perfil listaPerfil = new PerfilData().GetPerfilByID(PerfilID);

            if (listaPerfil == null)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Perfil";
                mensagem.Descricoes.Add("Nenhum Perfil encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaPerfil;
        }

        ///// <summary>
        ///// Selecionar um tipoAcesso especifico
        ///// </summary>
        ///// <param name="idPerfil">Identificador do Perfil</param>
        ///// <param name="resultado">Retorna se a busca foi bem sucedida por referência</param>
        ///// <returns>Objeto tipoAcesso preenchido</returns>
        //public Perfil Selecionar(int idPerfil, ref Resultado resultado)
        //{
        //    Perfil perfilRetorno = new PerfilData().Selecionar(idPerfil);

        //    if (perfilRetorno == null)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Add("Perfil não encontrado!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return perfilRetorno;
        //}

        ///// <summary>
        ///// Lista os perfis por status
        ///// </summary>
        ///// <param name="ativo">Somente ativos (true) ou inativos (false)</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de Perfil</returns>
        //public List<Perfil> ListarPorStatus(bool ativo, ref Resultado resultado)
        //{
        //    List<Perfil> listaPerfil = new PerfilData().ListarPorStatus(ativo);

        //    if (listaPerfil.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Add("Nenhum Perfil encontrado!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return listaPerfil;
        //}

        ///// <summary>
        ///// Alteração do status do tipoAcesso
        ///// </summary>
        ///// <param name="tipoAcesso">Perfil que será alterado</param>
        ///// <returns>Objeto com o resultado da atualização</returns>
        //public Resultado AtualizarStatus(int idPerfil, string login)
        //{
        //    Resultado resultado = new Resultado();
        //    resultado = new PerfilData().AtualizarStatus(idPerfil, login);

        //    Mensagem mensagem = new Mensagem();
        //    mensagem.Campo = "Status";

        //    if (resultado.Sucesso)
        //    {
        //        mensagem.Descricoes.Add("Status do funcionalidade atualizado com sucesso!"); 
        //    }
        //    else
        //    {
        //        mensagem.Descricoes.Add("Erro ao atualizar status do funcionalidade!");
        //    }
        //    resultado.Mensagens.Add(mensagem);

        //    return resultado;
        //}

        ///// <summary>
        ///// Inclui um novo funcionalidade
        ///// </summary>
        ///// <param name="funcionalidade">Dados do novo funcionalidade</param>
        ///// <param name="login">Usuário logado</param>
        ///// <returns>Resultado</returns>
        //public Resultado Incluir(Perfil perfil, string login)
        //{
        //    PerfilData perfilData = new PerfilData();
        //    Resultado resultado = new PerfilValidation(perfil).ValidarInclusao();

        //    if (resultado.Sucesso)
        //    {
        //        resultado = perfilData.Incluir(perfil, login);

        //        if (!resultado.Sucesso)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Usuário";
        //            mensagem.Descricoes.Insert(0, "Erro ao inserir funcionalidade!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //        }
        //    }
        //    return resultado;
        //}

        ///// <summary>
        ///// Altera um funcionalidade
        ///// </summary>
        ///// <param name="funcionalidade">Dados do funcionalidade a alterar</param>
        ///// <param name="login">Usuário logado</param>
        ///// <returns>Resultado</returns>
        //public Resultado Alterar(Perfil perfil, string login)
        //{
        //    PerfilData perfilData = new PerfilData();
        //    Resultado resultado = new PerfilValidation(perfil).ValidarAlteracao();

        //    if (resultado.Sucesso)
        //    {
        //        resultado = perfilData.Alterar(perfil, login);

        //        if (!resultado.Sucesso)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Perfil";
        //            mensagem.Descricoes.Insert(0, "Erro ao alterar funcionalidade!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //        }
        //    }
        //    return resultado;
        //}
        
        ///// <summary>
        ///// Inclui os acessos para o funcionalidade
        ///// </summary>
        ///// <param name="usuario">Dados do novo usuário</param>
        ///// <returns>Resultado</returns>
        //public Resultado IncluirAcesso(Perfil perfil)
        //{
        //    PerfilData perfilData = new PerfilData();
        //    Resultado resultado = new Resultado();

        //    foreach (Modulo modulo in perfil.ListaModulo)
        //    {
        //        foreach (Funcionalidade funcionalidade in modulo.ListaFuncionalidade)
        //        {
        //            foreach (TipoAcesso tipoAcesso in funcionalidade.ListaTipoAcesso)
        //            {
        //                if (tipoAcesso.Selecionado)
        //                {
        //                    resultado = perfilData.IncluirAcesso(tipoAcesso, funcionalidade.Id, perfil.Id);
        //                    if (!resultado.Sucesso)
        //                    {
        //                        Mensagem mensagem = new Mensagem();
        //                        mensagem.Campo = "Perfil";
        //                        mensagem.Descricoes.Insert(0, "Erro ao inserir tipoAcesso para o usuário!");

        //                        resultado.Mensagens.Add(mensagem);
        //                        resultado.Sucesso = false;
        //                        break;
        //                    }
        //                }
        //            }

        //            if (!resultado.Sucesso) break;
        //        }

        //        if (!resultado.Sucesso) break;
        //    }

        //    return resultado;
        //}
        
        ///// <summary>
        ///// Limpar os perfis do usuário
        ///// </summary>
        ///// <param name="idPerfil">Identificador do funcionalidade</param>
        ///// <returns>Resultado</returns>
        //public Resultado LimparAcesso(int idPerfil)
        //{
        //    PerfilData perfilData = new PerfilData();
        //    Resultado resultado = new Resultado();

        //    resultado = perfilData.LimparAcesso(idPerfil);
        //    if (!resultado.Sucesso)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Insert(0, "Erro ao limpar perfis do usuário!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }

        //    return resultado;
        //}

        ///// <summary>
        ///// Retorna a lista de módulos atrelados ao perfil
        ///// </summary>
        ///// <param name="idPerfil">Identificador do Perfil</param>
        ///// <returns>Lista de módulos</returns>
        //public List<Modulo> ListarAcesso(int idPerfil, ref Resultado resultado)
        //{
        //    List<Modulo> listaModulo = new PerfilData().ListarModulo(idPerfil);

        //    if (listaModulo.Count > 0)
        //    {
        //        resultado.Sucesso = true;

        //        foreach (Modulo modulo in listaModulo)
        //        {
        //            modulo.ListaFuncionalidade = new PerfilData().ListarFuncionalidade(idPerfil, modulo);

        //            if (!resultado.Sucesso) break;
        //        }
        //    }
        //    else
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Módulos";
        //        mensagem.Descricoes.Insert(0, "Nenhum módulo encontrado para o funcionalidade!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }

        //    return listaModulo;
        //}

        public Resultado Inserir(Perfil oPerfil)
        {
            return new PerfilData().Inserir(oPerfil.Descricao);
        }

        public Resultado InserirAcesso(int PerfilID, int ModuloID, int Acesso)
        {
            return new PerfilData().InserirAcesso(PerfilID, ModuloID, Acesso);
        }

        public Resultado LimpaAcesso(int PerfilID)
        {
            return new PerfilData().LimpaAcesso(PerfilID);
        }

        public Resultado Atualizar(Perfil oPerfil)
        {
            return new PerfilData().Atualizar(oPerfil.PerfilId, oPerfil.Descricao);
        }
    }
}
