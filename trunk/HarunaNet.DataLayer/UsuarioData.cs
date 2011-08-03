using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;
using System.Security.Cryptography;

namespace HarunaNet.DataLayer
{
    public class UsuarioData
    {

        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados do usuário.
        /// </summary>
        public UsuarioData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        /// <summary>
        /// Selecionar um usuário especifico
        /// </summary>
        /// <param name="idPerfil">Identificador do Usuario</param>
        /// <returns>Objeto usuário preenchido</returns>
        public Usuario Autenticar(Usuario login, ref Resultado resultado)
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.sp_login");
            this.m_db.AddInParameter(dbc, "@LOGIN", DbType.String, login.Login);

            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                if (readerUsuario.Read())
                {
                    resultado.Sucesso = true;
                    login.UsuarioId = Conversion.preencheCampoInt(readerUsuario["USUARIO_ID"]);
                    login.Login = Conversion.preencheCampoString(readerUsuario["LOGIN"]);
                    login.SenhaCript = readerUsuario["SENHA"];
                    login.Nome = Conversion.preencheCampoString(readerUsuario["NOME"]);
                    login.Email = Conversion.preencheCampoString(readerUsuario["EMAIL"]);
                    login.Status = Conversion.preencheCampoString(readerUsuario["STATUS"]);

                    Perfil _Perfil = new Perfil();
                    _Perfil.PerfilId = Conversion.preencheCampoInt(readerUsuario["Perfil_ID"]);
                    _Perfil.Descricao = Conversion.preencheCampoString(readerUsuario["DSC_Perfil"]);

                    Grupo _Area = new Grupo();
                    _Area.ID = Conversion.preencheCampoInt(readerUsuario["Grupo_ID"]);
                    _Area.Nome = Conversion.preencheCampoString(readerUsuario["nom_Grupo"]);

                    login.Area = _Area;

                    _Perfil.Modulos = new ModuloData().Listar(_Perfil.PerfilId);
                    login.ItensMenu = new ModuloData().ListarMenu(_Perfil.PerfilId);

                    login.Perfil = _Perfil;
                }
                else
                {
                    resultado.Sucesso = false;
                }

                readerUsuario.Close();
            }
            return login;
        }

        public List<Usuario> Listar(string pNome)
        {

            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_PESQUISA");
            this.m_db.AddInParameter(dbc, "@NOME", DbType.String, pNome);

            List<Usuario> listaCategoria = new List<Usuario>();

            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                while (readerUsuario.Read())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.UsuarioId = Conversion.preencheCampoInt(readerUsuario["USUARIO_ID"]);
                    oUsuario.Nome = Conversion.preencheCampoString(readerUsuario["NOME"]);
                    oUsuario.Login = Conversion.preencheCampoString(readerUsuario["LOGIN"]);
                    oUsuario.Email = Conversion.preencheCampoString(readerUsuario["SENHA"]);
                    oUsuario.Status = Conversion.preencheCampoString(readerUsuario["STATUS"].ToString().Trim());
                    oUsuario.Perfil = new PerfilData().GetPerfilByID(Conversion.preencheCampoInt(readerUsuario["PERFIL_ID"]));

                    Grupo _Area = new Grupo();
                    _Area.ID = Conversion.preencheCampoInt(readerUsuario["Grupo_ID"]);
                    _Area.Nome = Conversion.preencheCampoString(readerUsuario["nom_Grupo"]);

                    oUsuario.Area = _Area;

                    listaCategoria.Add(oUsuario);
                }
                readerUsuario.Dispose();
            }
            return listaCategoria;
        }

        public Usuario GetByID(int UsuarioID)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_GET_USUARIO");
            this.m_db.AddInParameter(dbc, "@USUARIO_ID", DbType.String, UsuarioID);

            Usuario oUsuario = new Usuario();
            using (IDataReader readerUsuario = this.m_db.ExecuteReader(dbc))
            {
                if (readerUsuario.Read())
                {
                    //usuarioRetorno = new Usuario();
                    oUsuario.UsuarioId = Conversion.preencheCampoInt(readerUsuario["USUARIO_ID"]);
                    oUsuario.Login = Conversion.preencheCampoString(readerUsuario["LOGIN"]);
                    oUsuario.SenhaCript = readerUsuario["SENHA"];
                    oUsuario.Nome = Conversion.preencheCampoString(readerUsuario["NOME"]);
                    oUsuario.Email = Conversion.preencheCampoString(readerUsuario["EMAIL"]);
                    oUsuario.Status = Conversion.preencheCampoString(readerUsuario["STATUS"]);

                    Perfil _Perfil = new Perfil();
                    _Perfil.PerfilId = Conversion.preencheCampoInt(readerUsuario["Perfil_ID"]);
                    _Perfil.Descricao = Conversion.preencheCampoString(readerUsuario["DSC_Perfil"]);


                    Grupo _Area = new Grupo();
                    _Area.ID = Conversion.preencheCampoInt(readerUsuario["Grupo_ID"]);
                    _Area.Nome= Conversion.preencheCampoString(readerUsuario["nom_Grupo"]);
                        
                    oUsuario.Area = _Area;

                    _Perfil.Modulos = new ModuloData().Listar(_Perfil.PerfilId);

                    oUsuario.Perfil = _Perfil;
                }
                else

                    readerUsuario.Close();
            }
            return oUsuario;
        }

        public Resultado Inserir(Usuario oUsuario)
        {

            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_INSERE_USUARIO");

                //Criptofrafa a senha atual
                MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
                UTF8Encoding encode = new UTF8Encoding();
                byte[] senhacripto = hash.ComputeHash(encode.GetBytes(oUsuario.Senha));

                this.m_db.AddInParameter(dbCommand, "@NOME", DbType.String, oUsuario.Nome.Trim());
                this.m_db.AddInParameter(dbCommand, "@LOGIN", DbType.String, oUsuario.Login.Trim());
                this.m_db.AddInParameter(dbCommand, "@EMAIL", DbType.String, oUsuario.Email.Trim());
                this.m_db.AddInParameter(dbCommand, "@PERFIL_ID", DbType.Int32, oUsuario.PerfilId);
                this.m_db.AddInParameter(dbCommand, "@GRUPO_ID", DbType.Int32, oUsuario.Area.ID);
                this.m_db.AddInParameter(dbCommand, "@SENHA", DbType.Binary, senhacripto);
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.String, oUsuario.Status);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);

            }
            catch (SqlException ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Pedido";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado Atualizar(Usuario oUsuario)
        {
            Resultado resultado = new Resultado();
            Mensagem mensagem = new Mensagem();
            mensagem.Campo = "Usuario";
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_UPDATE");
                byte[] senhacripto = null;
                if (oUsuario.Senha != null)
                {
                     //Criptofrafa a senha atual
                    MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
                    UTF8Encoding encode = new UTF8Encoding();
                    senhacripto = hash.ComputeHash(encode.GetBytes(oUsuario.Senha));
                }

                this.m_db.AddInParameter(dbCommand, "@NOME", DbType.String, oUsuario.Nome.ToUpper().Trim());
                this.m_db.AddInParameter(dbCommand, "@EMAIL", DbType.String, oUsuario.Email.Trim());
                this.m_db.AddInParameter(dbCommand, "@PERFIL_ID", DbType.Int32, oUsuario.PerfilId);
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.String, oUsuario.Status);
                this.m_db.AddInParameter(dbCommand, "@SENHA", DbType.Binary, senhacripto);
                this.m_db.AddInParameter(dbCommand, "@USUARIO_ID", DbType.Int32, oUsuario.UsuarioId);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id >= 0);
                mensagem.Descricoes.Add("Usuário atualizado com sucesso!");
                resultado.Mensagens.Add(mensagem);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado AtualizarSenha(Usuario oUsuario)
        {
            Resultado resultado = new Resultado();
            Mensagem mensagem = new Mensagem();
            mensagem.Campo = "Usuario";
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_UPDATE");
                byte[] senhacripto = null;
                if (oUsuario.Senha != null)
                {
                    //Criptofrafa a senha atual
                    MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
                    UTF8Encoding encode = new UTF8Encoding();
                    senhacripto = hash.ComputeHash(encode.GetBytes(oUsuario.Senha));
                }

                this.m_db.AddInParameter(dbCommand, "@SENHA", DbType.Binary, senhacripto);
                this.m_db.AddInParameter(dbCommand, "@USUARIO_ID", DbType.Int32, oUsuario.UsuarioId);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id >= 0);
                mensagem.Descricoes.Add("Senha atualizada com sucesso!");
                resultado.Mensagens.Add(mensagem);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado Excluir(int UsuarioID)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_USUARIO_DELETE");
                this.m_db.AddInParameter(dbCommand, "@USUARIO_ID", DbType.Int32, UsuarioID);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id == 0);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Apagar";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }


            return resultado;
        }

    }
}
