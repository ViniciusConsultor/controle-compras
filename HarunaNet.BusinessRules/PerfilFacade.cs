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
    /// <summary>
    /// Descrição da facade
    /// </summary>
    public class PerfilFacade
    {
        /// <summary>
        /// </summary>
        /// <param name="ativo">Nome do tipoAcesso para filtro</param>
        /// <param name="resultado">Estância da Entidade Resultado</param>
        /// <returns>Lista de Perfil</returns>
        public List<Perfil> Listar(ref Resultado resultado)
        {
            return new PerfilProcess().Listar(ref resultado);
        }

        public Perfil Seleciona(int PerfilID, ref Resultado resultado)
        {
            return new PerfilProcess().Seleciona(PerfilID, ref resultado);
        }

        public Resultado Inserir(Perfil oPerfil)
        {
            PerfilProcess oPerfilProcess = new PerfilProcess();
            Resultado resultado = new Resultado();

            resultado = oPerfilProcess.Inserir(oPerfil);

            if (resultado.Sucesso)
            {
                oPerfil.PerfilId = resultado.Id;
                foreach (Modulo oModulo in oPerfil.Modulos)
                {
                    if (oModulo.PodeAcessar > 0)
                    {
                        resultado = oPerfilProcess.InserirAcesso(oPerfil.PerfilId, oModulo.ModuloId, oModulo.PodeAcessar);

                        if (!resultado.Sucesso)
                        {
                            break;
                        }
                    }
                }
            }

            return resultado;

        }

        public Resultado Atualizar(Perfil oPerfil)
        {
            PerfilProcess oPerfilProcess = new PerfilProcess();
            Resultado resultado = new Resultado();

            resultado = oPerfilProcess.Atualizar(oPerfil);
            
            if (resultado.Sucesso)
            {
                resultado = oPerfilProcess.LimpaAcesso(oPerfil.PerfilId);
                foreach (Modulo oModulo in oPerfil.Modulos)
                {
                    if (oModulo.PodeAcessar > 0)
                    {
                        resultado = oPerfilProcess.InserirAcesso(oPerfil.PerfilId, oModulo.ModuloId, oModulo.PodeAcessar);

                        if (!resultado.Sucesso)
                        {
                            break;
                        }
                    }
                }
            }

            return resultado;

        }
    }
}