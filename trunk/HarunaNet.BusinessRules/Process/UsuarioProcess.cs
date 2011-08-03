using System.Collections.Generic;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.BusinessRules.Validation;

namespace HarunaNet.BusinessRules.Process
{
    internal class UsuarioProcess
    {
        /// <summary>
        /// Lista v�rios usu�rios por uma condi��o
        /// </summary>
        /// <param name="usuarioFiltro">Condi��es filtradas</param>
        /// <param name="resultado">Retorna a busca foi bem sucedida por refer�ncia</param>
        /// <returns>Retorna a lista de usu�rios</returns>
        public List<Usuario> Listar(string usuarioFiltro, ref Resultado resultado)
        {
            List<Usuario> listaUsuario = new UsuarioData().Listar(usuarioFiltro);

            if (listaUsuario.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Usu�rio";
                mensagem.Descricoes.Add("Nenhum Usu�rio encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaUsuario;
        }

        ///// <summary>
        ///// Selecionar um usu�rio especifico
        ///// </summary>
        ///// <param name="idPerfil">Identificador do Usu�rio</param>
        ///// <param name="resultado">Retorna se a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Objeto usu�rio preenchido</returns>
        public Resultado Autenticar(Usuario usuario)
        {
            Resultado resultado = new UsuarioValidation(usuario).ValidarLogin();
            if (resultado.Sucesso)
            {
                resultado.Sucesso = true;
            }
            else
            {
                resultado.Sucesso = false;
            }

            return resultado;
        }

        ///// <summary>
        ///// Selecionar um usu�rio especifico
        ///// </summary>
        ///// <param name="idPerfil">Identificador do Usu�rio</param>
        ///// <param name="resultado">Retorna se a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Objeto usu�rio preenchido</returns>
        public Resultado Inserir(Usuario oUsuario)
        {
            Resultado resultado = new Resultado();

            UsuarioData usuarioData = new UsuarioData();
            resultado = usuarioData.Inserir(oUsuario);
            return resultado;
        }

        ///// <summary>
        ///// Selecionar um usu�rio especifico
        ///// </summary>
        ///// <param name="idPerfil">Identificador do Usu�rio</param>
        ///// <param name="resultado">Retorna se a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Objeto usu�rio preenchido</returns>
        public Resultado Alterar(Usuario oUsuario)
        {
            Resultado resultado = new Resultado();

            UsuarioData usuarioData = new UsuarioData();
            resultado = usuarioData.Atualizar(oUsuario);
            return resultado;
        }

        public Resultado AlterarSenha(Usuario oUsuario)
        {
            Resultado resultado = new Resultado();
            resultado = new UsuarioValidation().ValidarSenha(oUsuario);

            if (resultado.Sucesso)
            {
                oUsuario.Senha = oUsuario.NovaSenha;
                UsuarioData usuarioData = new UsuarioData();
                resultado = usuarioData.AtualizarSenha(oUsuario);
                
            }
           
            return resultado;
        }

        public Usuario GetByID(int UsuarioID)
        {
             Usuario oUsuario = new UsuarioData().GetByID(UsuarioID);

             return oUsuario;

            //if (listaUsuario.Count == 0)
            //{
            //    Mensagem mensagem = new Mensagem();
            //    mensagem.Campo = "Usu�rio";
            //    mensagem.Descricoes.Add("Nenhum Usu�rio encontrado!");

            //    resultado.Mensagens.Add(mensagem);
            //    resultado.Sucesso = false;
            //}
            //else
            //{
            //    resultado.Sucesso = true;
            //}

            //return listaUsuario;
        
        }

        public Resultado Excluir(int UsuarioID)
        {
            UsuarioData oUsuarioData = new UsuarioData();

            Resultado resultado = new UsuarioData().Excluir(UsuarioID);

            if (!resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "ExcluirUsuario";
                mensagem.Descricoes.Insert(0, "Erro ao excluir Usu�rio!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;
        }
        ///// <summary>
        ///// Altera��o do status do usu�rio
        ///// </summary>
        ///// <param name="tipoAcesso">Usuario que ser� alterado</param>
        ///// <returns>Objeto com o resultado da atualiza��o</returns>
        //public Resultado AtualizarStatus(int idUsuario, string login)
        //{
        //    Resultado resultado = new Resultado();
        //    resultado = new UsuarioData().AtualizarStatus(idUsuario, login);

        //    Mensagem mensagem = new Mensagem();
        //    mensagem.Campo = "Status";

        //    if (resultado.Sucesso)
        //    {
        //        mensagem.Descricoes.Add("Status do usu�rio atualizado com sucesso!");
        //    }
        //    else
        //    {
        //        mensagem.Descricoes.Add("Erro ao atualizar status do usu�rio!");
        //    }
        //    resultado.Mensagens.Add(mensagem);

        //    return resultado;
        //}

        ///// <summary>
        ///// Busca o nome completo do usu�rio no AD
        ///// </summary>
        ///// <param name="login">Login para pesquisa (com dom�nio)</param>
        ///// <param name="resultado">Est�ncia da Entidade Resultado</param>
        ///// <returns>Nome Completo do usu�rio</returns>
        //public string SelecionarNomeCompleto(string login, ref Resultado resultado)
        //{
        //    resultado.Sucesso = true;
        //    string ret = string.Empty;
        //    try
        //    {

        //        ret = Authentication.UserName(login);
        //        if (ret == string.Empty)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Login";
        //            mensagem.Descricoes.Add("Login n�o encontrado!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Login";
        //        mensagem.Descricoes.Add(ex.Message);

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }

        //    return ret;
        //}

        ///// <summary>
        ///// Verifica se o login ainda n�o est� cadastrado e retorna o nome completo do usu�rio no AD
        ///// </summary>
        ///// <param name="login">Login para pesquisa (com dom�nio)</param>
        ///// <returns>Objeto resultado</returns>
        //public Resultado VerificarLoginDisponivel(string login)
        //{
        //    return new UsuarioValidation().ValidarLoginExistente(login);
        //}

        ///// <summary>
        ///// Inclui um novo usu�rio
        ///// </summary>
        ///// <param name="tipoAcesso">Dados do novo usu�rio</param>
        ///// <param name="login">Usu�rio logado</param>
        ///// <returns>Resultado</returns>
        //public Resultado Incluir(Usuario usuario, string login)
        //{
        //    UsuarioData usuarioData = new UsuarioData();
        //    Resultado resultado = new UsuarioValidation(usuario).ValidarInclusao();

        //    if (resultado.Sucesso)
        //    {
        //        resultado = usuarioData.Incluir(usuario, login);

        //        if (!resultado.Sucesso)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Usu�rio";
        //            mensagem.Descricoes.Add("Erro ao inserir usu�rio!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //        }
        //    }
        //    return resultado;
        //}

        ///// <summary>
        ///// Altera um usu�rio
        ///// </summary>
        ///// <param name="tipoAcesso">Dados do usu�rio a alterar</param>
        ///// <param name="tipoAcesso">Usu�rio logado</param>
        ///// <returns>Resultado</returns>
        //public Resultado Alterar(Usuario usuario, string login)
        //{
        //    UsuarioData usuarioData = new UsuarioData();
        //    Resultado resultado = new UsuarioValidation(usuario).ValidarAlteracao();

        //    if (resultado.Sucesso)
        //    {
        //        resultado = usuarioData.Alterar(usuario, login);

        //        if (!resultado.Sucesso)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Usu�rio";
        //            mensagem.Descricoes.Add("Erro ao alterar usu�rio!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //        }
        //    }
        //    return resultado;
        //}

        ///// <summary>
        ///// Limpar os perfis do usu�rio
        ///// </summary>
        ///// <param name="idUsuario">Identificador do usu�rio</param>
        ///// <returns>Resultado</returns>
        //public Resultado LimparPerfil(int idUsuario)
        //{
        //    UsuarioData usuarioData = new UsuarioData();
        //    Resultado resultado = new Resultado();

        //    resultado = usuarioData.LimparPerfil(idUsuario);
        //    if (!resultado.Sucesso)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Add("Erro ao limpar perfis do usu�rio!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }

        //    return resultado;
        //}

        ///// <summary>
        ///// Inclui os perfis para o usu�rio
        ///// </summary>
        ///// <param name="usuario">Dados do novo usu�rio</param>
        ///// <returns>Resultado</returns>
        //public Resultado IncluirPerfil(Usuario usuario)
        //{
        //    UsuarioData usuarioData = new UsuarioData();
        //    Resultado resultado = new Resultado();

        //    foreach (Perfil perfil in usuario.ListaPerfil)
        //    {
        //        resultado = usuarioData.IncluirPerfil(perfil, usuario.Id);
        //        if (!resultado.Sucesso)
        //        {
        //            Mensagem mensagem = new Mensagem();
        //            mensagem.Campo = "Perfil";
        //            mensagem.Descricoes.Add("Erro ao inserir tipoAcesso para o usu�rio!");

        //            resultado.Mensagens.Add(mensagem);
        //            resultado.Sucesso = false;
        //            break;
        //        }
        //    }

        //    return resultado;
        //}

        ///// <summary>
        ///// Listar os perfis do usu�rio
        ///// </summary>
        ///// <param name="idPerfil">Identificador do usu�rio</param>
        ///// <param name="resultado">Retorna a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Retorna a lista de perfis do usu�rio</returns>
        //public List<Perfil> ListarPerfil(int idUsuario, ref Resultado resultado)
        //{
        //    List<Perfil> listaPerfil = new UsuarioData().ListarPerfil(idUsuario);

        //    if (listaPerfil.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Perfil";
        //        mensagem.Descricoes.Add("Nenhum tipoAcesso encontrado!");

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
        ///// Listar os m�dulos que o usu�rio tem acesso
        ///// </summary>
        ///// <param name="idUsuario">Identificador do usu�rio</param>
        ///// <param name="resultado">Retorna a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Retorna a lista de perfis do usu�rio</returns>
        //public List<Modulo> ListarModulo(int idUsuario, ref Resultado resultado)
        //{
        //    List<Modulo> listaModulo = new UsuarioData().ListarModulo(idUsuario);

        //    if (listaModulo.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Modulo";
        //        mensagem.Descricoes.Add("Nenhum m�dulo cadastrado para o usu�rio!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return listaModulo;
        //}

        ///// <summary>
        ///// Listar as funcionalidade que o usu�rio tem acesso dentro do m�dulo especificado
        ///// </summary>
        ///// <param name="idUsuario">Identificador do Usu�rio</param>
        ///// <param name="idModulo">Identificador do M�dulo</param>
        ///// <param name="resultado">Retorna a busca foi bem sucedida por refer�ncia</param>
        ///// <returns>Lista de funcionalidades</returns>
        //public List<Funcionalidade> ListarFuncionalidade(int idUsuario, int idModulo, ref Resultado resultado)
        //{
        //    List<Funcionalidade> listaFuncionalidade = new UsuarioData().ListarFuncionalidade(idUsuario, idModulo);

        //    if (listaFuncionalidade.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "M�dulos";
        //        mensagem.Descricoes.Insert(0, "Nenhuma funcionalidade encontrada para o m�dulo!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return listaFuncionalidade;
        //}
    }
}
