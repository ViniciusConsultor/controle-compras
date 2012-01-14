using System.Collections.Generic;
using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules
{
    /// <summary>
    /// Descrição da facade
    /// </summary>
    public class UsuarioFacade
    {

        public Resultado Autenticar(Usuario usuario, ref Resultado resultado)
        {
            return new UsuarioProcess().Autenticar(usuario);
        }

        public Resultado TemAcesso(Usuario oUsuario, string pNomeForm, ref Resultado resultado)
        {
            return new ModuloProcess().TemAcesso(oUsuario, pNomeForm, ref resultado);
        }

        public List<Usuario> Listar (string pNomeForm, ref Resultado resultado)
        {
            return new UsuarioProcess().Listar(pNomeForm, ref resultado);
        }

        public Resultado Inserir(Usuario oUsuario)
        {
            return new UsuarioProcess().Inserir(oUsuario);
        }

        public Resultado Alterar(Usuario oUsuario)
        {
            return new UsuarioProcess().Alterar(oUsuario);
        }

        public Resultado AlterarSenha(Usuario oUsuario)
        {
            return new UsuarioProcess().AlterarSenha(oUsuario);
        }

        public Usuario GetByID(int UsuarioID)
        {
            return new UsuarioProcess().GetByID(UsuarioID);
        }

        public Resultado Excluir(int UsuarioID)
        {
            return new UsuarioProcess().Excluir(UsuarioID);
        }

    }
}