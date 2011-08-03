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
    internal class ModuloProcess
    {
        ///// <summary>
        ///// Lista os módulos existentes
        ///// </summary>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de Módulos</returns>
        //public List<Modulo> Listar(ref Resultado resultado)
        //{
        //    List<Modulo> listaModulo = new ModuloData().Listar();

        //    if (listaModulo.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Módulo";
        //        mensagem.Descricoes.Add("Nenhum módulo encontrado!");

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
        ///// Lista as funcionalidades existes para o módulo especificado
        ///// </summary>
        ///// <param name="funcionalidade">Módulo de consulta</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de Módulos</returns>
        //public List<Funcionalidade> ListarFuncionalidade(Modulo modulo, ref Resultado resultado)
        //{
        //    List<Funcionalidade> listaFuncionalidade = new ModuloData().ListarFuncionalidade(modulo);

        //    if (listaFuncionalidade.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Funcionalidade";
        //        mensagem.Descricoes.Add("Nenhuma tipoAcesso encontrada!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return listaFuncionalidade;
        //}
        
        ///// <summary>
        ///// Lista os tipos de acesso existentes
        ///// </summary>
        ///// <param name="idFuncionalidade">Identificador da Funcionalidade (Passar 0 para listar todos)</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de TipoAcesso</returns>
        //public List<TipoAcesso> ListarTipoAcesso(int idFuncionalidade, ref Resultado resultado)
        //{
        //    List<TipoAcesso> listaTipoAcesso = new ModuloData().ListarTipoAcesso(idFuncionalidade);

        //    if (listaTipoAcesso.Count == 0)
        //    {
        //        Mensagem mensagem = new Mensagem();
        //        mensagem.Campo = "Tipo Acesso";
        //        mensagem.Descricoes.Add("Nenhum Tipo de Acesso encontrado!");

        //        resultado.Mensagens.Add(mensagem);
        //        resultado.Sucesso = false;
        //    }
        //    else
        //    {
        //        resultado.Sucesso = true;
        //    }

        //    return listaTipoAcesso;
        //}

        public List<Modulo> ListarModulosPerfil(int pPerfilID, ref Resultado resultado)
        {
            List<Modulo> listaModulo = new ModuloData().Listar(pPerfilID);

            if (listaModulo.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Módulo";
                mensagem.Descricoes.Add("Nenhum módulo encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaModulo;
        }
        
        public List<Modulo> Listar(ref Resultado resultado)
        {
            List<Modulo> listaModulo = new ModuloData().Listar(0);

            if (listaModulo.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Módulo";
                mensagem.Descricoes.Add("Nenhum módulo encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaModulo;
        }
        
        public Resultado TemAcesso(Usuario oUsuario, string pNomeForm, ref Resultado resultado)
        {
            foreach (Modulo m in oUsuario.Perfil.Modulos)
            {
                if (m.PaginaWeb.ToUpper().Equals(pNomeForm.ToUpper()) && m.PodeAcessar.Equals(1))
                {
                    resultado.Sucesso = true;
                    break;
                }
                else
                {
                    Mensagem mensagem = new Mensagem();
                    mensagem.Campo = "Módulos";
                    mensagem.Descricoes.Insert(0, "Nenhum módulo encontrado para o funcionalidade!");

                    resultado.Mensagens.Add(mensagem);
                    resultado.Sucesso = false;
                }
            }

            return resultado;
        }
    }
}
