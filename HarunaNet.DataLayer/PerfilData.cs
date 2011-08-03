using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;

namespace HarunaNet.DataLayer
{
    public class PerfilData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de tipoAcesso.
        /// </summary>
        public PerfilData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        #region Parte DAO
        public List<Perfil> Listar()
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PERFIL_LISTA");
            List<Perfil> listPerfil = new List<Perfil>();

            using (IDataReader readerCategoria = this.m_db.ExecuteReader(dbc))
            {
                while (readerCategoria.Read())
                {
                    Perfil oPerfil = new Perfil();
                    oPerfil.PerfilId = Conversion.preencheCampoInt(readerCategoria["PERFIL_ID"]);
                    oPerfil.Descricao = Conversion.preencheCampoString(readerCategoria["DSC_PERFIL"]);
                    oPerfil.Modulos = new ModuloData().Listar(oPerfil.PerfilId);

                    listPerfil.Add(oPerfil);
                }
                readerCategoria.Dispose();
            }
            return listPerfil;

        }

        public Perfil GetPerfilByID(int PerfilID)
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_PERFIL_PESQUISAR");
            this.m_db.AddInParameter(dbc, "@IDPERFIL", DbType.Int32, PerfilID);

            Perfil oPerfil = new Perfil();

            using (IDataReader readerPerfil = this.m_db.ExecuteReader(dbc))
            {
                if (readerPerfil.Read())
                {
                    oPerfil.PerfilId = Conversion.preencheCampoInt(readerPerfil["PERFIL_ID"]);
                    oPerfil.Descricao = Conversion.preencheCampoString(readerPerfil["DSC_PERFIL"]);
                    oPerfil.Modulos = new ModuloData().Listar(oPerfil.PerfilId);

                }
                readerPerfil.Dispose();
            }
            return oPerfil;

        }
        
        public Resultado Inserir(String DescPerfil)
        {

            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_INSERE_PERFIL");

                this.m_db.AddInParameter(dbCommand, "@DESCRICAO", DbType.String, DescPerfil.ToUpper());

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Perfil";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado Atualizar(int PerfilID, String DescPerfil)
        {

            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_ALTERA_PERFIL");

                this.m_db.AddInParameter(dbCommand, "@DESCRICAO", DbType.String, DescPerfil.ToUpper());
                this.m_db.AddInParameter(dbCommand, "@PERFILID", DbType.Int32, PerfilID);


                resultado.Sucesso = (this.m_db.ExecuteNonQuery(dbCommand) > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PerfilALTERAR";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado InserirAcesso(int PerfilID, int ModuloID, int Acesso)
        {

            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_SALVA_PERFIL_MODULO");

                this.m_db.AddInParameter(dbCommand, "@PERFIL_ID", DbType.Int32, PerfilID);
                this.m_db.AddInParameter(dbCommand, "@MODULO_ID", DbType.Int32, ModuloID);
                this.m_db.AddInParameter(dbCommand, "@TEM_ACESSO", DbType.Int32, Acesso);
                
                resultado.Sucesso = (this.m_db.ExecuteNonQuery(dbCommand) > 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PerfilModulos";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado LimpaAcesso(int PerfilID)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_PERFIL_MODULO_LIMPAR");

                this.m_db.AddInParameter(dbCommand, "@PERFIL_ID", DbType.Int32, PerfilID);
                resultado.Sucesso = (this.m_db.ExecuteNonQuery(dbCommand) == 0);

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PerfilModulosLimpar";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }


        //public Resultado Atualizar(Usuario oUsuario)
        //{
        //    Resultado resultado = new Resultado();
        //    Mensagem mensagem = new Mensagem();
        //    mensagem.Campo = "Usuario";
        //    try
        //    {
        //        DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_UPDATE");
        //        byte[] senhacripto = null;
        //        if (oUsuario.Senha != null)
        //        {
        //            //Criptofrafa a senha atual
        //            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
        //            UTF8Encoding encode = new UTF8Encoding();
        //            senhacripto = hash.ComputeHash(encode.GetBytes(oUsuario.Senha));
        //        }

        //        this.m_db.AddInParameter(dbCommand, "@NOME", DbType.String, oUsuario.Nome.ToUpper().Trim());
        //        this.m_db.AddInParameter(dbCommand, "@EMAIL", DbType.String, oUsuario.Email.Trim());
        //        this.m_db.AddInParameter(dbCommand, "@PERFIL_ID", DbType.Int32, oUsuario.PerfilId);
        //        this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.String, oUsuario.Status);
        //        this.m_db.AddInParameter(dbCommand, "@SENHA", DbType.Binary, senhacripto);
        //        this.m_db.AddInParameter(dbCommand, "@USUARIO_ID", DbType.Int32, oUsuario.UsuarioId);

        //        resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
        //        resultado.Sucesso = (resultado.Id >= 0);
        //        mensagem.Descricoes.Add("Usuário atualizado com sucesso!");
        //        resultado.Mensagens.Add(mensagem);
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.Sucesso = false;
        //        mensagem.Descricoes.Add(ex.Message);
        //        resultado.Mensagens.Add(mensagem);
        //    }

        //    return resultado;
        //}
        #endregion
    }
}
