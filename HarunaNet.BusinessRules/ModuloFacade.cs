using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using HarunaNet.BusinessRules;
using HarunaNet.BusinessRules.Process;
using HarunaNet.BusinessRules.Validation;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules
{
    public class ModuloFacade
    {
        ///// <summary>
        ///// </summary>
        ///// <param name="completo">Indica se a lista de funcionalidades será preenchida</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de Módulo</returns>
        //public List<Modulo> Listar(bool completo, ref Resultado resultado)
        //{
        //    List<Modulo> listaModulo = new ModuloProcess().Listar(ref resultado);

        //    if (resultado.Sucesso && completo)
        //    {
        //        foreach (Modulo modulo in listaModulo)
        //        {
        //            modulo.ListaFuncionalidade = new ModuloProcess().ListarFuncionalidade(modulo, ref resultado);

        //            if (resultado.Sucesso)
        //            {
        //                foreach (Funcionalidade funcionalidade in modulo.ListaFuncionalidade)
        //                {
        //                    funcionalidade.ListaTipoAcesso = new ModuloProcess().ListarTipoAcesso(funcionalidade.Id, ref resultado);

        //                    if (!resultado.Sucesso) break;
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    return listaModulo;
        //}

        ///// <summary>
        ///// Lista os tipos de acesso existentes
        ///// </summary>
        ///// <param name="idFuncionalidade">Identificador da Funcionalidade (Passar 0 para listar todos)</param>
        ///// <param name="resultado">Estância da Entidade Resultado</param>
        ///// <returns>Lista de TipoAcesso</returns>
        //public List<TipoAcesso> ListarTipoAcesso(int idFuncionalidade, ref Resultado resultado)
        //{
        //    return new ModuloProcess().ListarTipoAcesso(idFuncionalidade, ref resultado);
        //}


        public List<Modulo> Listar(ref Resultado resultado)
        {
            return  new ModuloProcess().Listar(ref resultado);
        }


        public List<Modulo> ListarModulosPerfil(int pPerfilID, ref Resultado resultado)
        {
            return new ModuloProcess().ListarModulosPerfil(pPerfilID, ref resultado);
        }

       
    }
}
