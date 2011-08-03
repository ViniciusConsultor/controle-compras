using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;


namespace HarunaNet.DataLayer
{
    public class FornecedorData
    {
        #region Atributos
        private Database m_db;
        #endregion

        #region Construtores
        /// <summary>
        /// Acesso a dados de módulo.
        /// </summary>
        public FornecedorData()
        {
            this.m_db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        //#region Métodos
        ///// <summary>
        ///// Selecionar a lista de Fornecedores Ativos
        ///// </summary>
        ///// <returns>Lista de Fornecedores</returns>
        public List<Fornecedor> Listar(Fornecedor oFornecedor)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_FORNECEDOR_LISTA");
            this.m_db.AddInParameter(dbc, "@NomeFantasia", DbType.String, oFornecedor.NomeFantasia);
            this.m_db.AddInParameter(dbc, "@RazaoSocial", DbType.String, oFornecedor.RazaoSocial);
            this.m_db.AddInParameter(dbc, "@Status", DbType.Int32, oFornecedor.Status == 0 ? 1 : oFornecedor.Status);

            List<Fornecedor> listaFornecedor = new List<Fornecedor>();

            using (IDataReader readerFornecedor = this.m_db.ExecuteReader(dbc))
            {
                while (readerFornecedor.Read())
                {
                     Fornecedor newFornecedor = new Fornecedor();

                     newFornecedor.FornecedorID = Conversion.preencheCampoInt(readerFornecedor["FORNECEDOR_ID"]);
                     newFornecedor.RazaoSocial = Conversion.preencheCampoString(readerFornecedor["NOM_RAZAO_SOCIAL"]);
                     newFornecedor.CNPJ = Conversion.preencheCampoString(readerFornecedor["NUM_CNPJ"]);
                     newFornecedor.NomeFantasia = Conversion.preencheCampoString(readerFornecedor["NOM_FANTASIA"]);

                     listaFornecedor.Add(newFornecedor);
                }
                readerFornecedor.Dispose();
            }
            return listaFornecedor;

        }

        public Fornecedor Obter(int FornecedorID)
        {
            DbCommand dbc = this.m_db.GetStoredProcCommand("dbo.SP_FORNECEDOR_GETbyID");
            this.m_db.AddInParameter(dbc, "@FORNECEDOR_ID", DbType.Int32, FornecedorID);
            Fornecedor oFornecedor = new Fornecedor();
            using (IDataReader readerFornecedor = this.m_db.ExecuteReader(dbc))
            {
                if (readerFornecedor.Read())
                {
                    oFornecedor.FornecedorID = Conversion.preencheCampoInt(readerFornecedor["FORNECEDOR_ID"]);
                    oFornecedor.RazaoSocial = Conversion.preencheCampoString(readerFornecedor["NOM_RAZAO_SOCIAL"]);
                    oFornecedor.CNPJ = Conversion.preencheCampoString(readerFornecedor["NUM_CNPJ"]);
                    oFornecedor.NomeFantasia = Conversion.preencheCampoString(readerFornecedor["NOM_FANTASIA"]);
                    oFornecedor.InscricaoEstadual = Conversion.preencheCampoString(readerFornecedor["NUM_INSCRICAO_ESTADUAL"]);
                    oFornecedor.InscricaoMunicipal = Conversion.preencheCampoString(readerFornecedor["NUM_INSCRICAO_MUNICIPAL"]);
                    oFornecedor.Logradouro = Conversion.preencheCampoString(readerFornecedor["NOM_LOGRADOURO"]);
                    oFornecedor.Bairro = Conversion.preencheCampoString(readerFornecedor["NOM_BAIRRO"]);
                    oFornecedor.Cidade = Conversion.preencheCampoString(readerFornecedor["NOM_CIDADE"]);
                    oFornecedor.UF = Conversion.preencheCampoString(readerFornecedor["NOM_UF"]);
                    oFornecedor.CEP = Conversion.preencheCampoString(readerFornecedor["NUM_CEP"]);
                    oFornecedor.Telefone_1 = Conversion.preencheCampoString(readerFornecedor["NUM_TELEFONE1"]);
                    oFornecedor.Ramal_1 = Conversion.preencheCampoString(readerFornecedor["NUM_RAMAL1"]);
                    oFornecedor.Telefone_2 = Conversion.preencheCampoString(readerFornecedor["NUM_TELEFONE2"]);
                    oFornecedor.Ramal_2 = Conversion.preencheCampoString(readerFornecedor["NUM_RAMAL2"]);
                    oFornecedor.Celular = Conversion.preencheCampoString(readerFornecedor["NUM_CEL"]);
                    oFornecedor.Email = Conversion.preencheCampoString(readerFornecedor["EMAIL"]);
                    oFornecedor.Status = Conversion.preencheCampoInt(readerFornecedor["NUM_STATUS_ID"]);
                }
                readerFornecedor.Dispose();
            }
            return oFornecedor;
        }


        public Resultado Inserir(Fornecedor oFornecedor)
        {

            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_FORNECEDOR_INSERE");

                this.m_db.AddInParameter(dbCommand, "@NOMEFANTASIA", DbType.String, oFornecedor.NomeFantasia.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAZAOSOCIAL", DbType.String, oFornecedor.RazaoSocial.Trim());
                this.m_db.AddInParameter(dbCommand, "@CNPJ", DbType.String, oFornecedor.CNPJ.Trim());
                this.m_db.AddInParameter(dbCommand, "@IE", DbType.String, oFornecedor.InscricaoEstadual.Trim());
                this.m_db.AddInParameter(dbCommand, "@IM", DbType.String, oFornecedor.InscricaoMunicipal.Trim());
                this.m_db.AddInParameter(dbCommand, "@LOGRADOURO", DbType.String, oFornecedor.Logradouro.Trim());
                this.m_db.AddInParameter(dbCommand, "@BAIRRO", DbType.String, oFornecedor.Bairro.Trim());
                this.m_db.AddInParameter(dbCommand, "@CIDADE", DbType.String, oFornecedor.Cidade.Trim());
                this.m_db.AddInParameter(dbCommand, "@UF", DbType.String, oFornecedor.UF.Trim());
                this.m_db.AddInParameter(dbCommand, "@CEP", DbType.String, oFornecedor.CEP.Trim());
                this.m_db.AddInParameter(dbCommand, "@TELEFONE1", DbType.String, oFornecedor.Telefone_1.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAMAL1", DbType.String, oFornecedor.Ramal_1.Trim());
                this.m_db.AddInParameter(dbCommand, "@TELEFONE2", DbType.String, oFornecedor.Telefone_2.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAMAL2", DbType.String, oFornecedor.Ramal_2.Trim());
                this.m_db.AddInParameter(dbCommand, "@CELULAR", DbType.String, oFornecedor.Celular.Trim());
                this.m_db.AddInParameter(dbCommand, "@EMAIL", DbType.String, oFornecedor.Email.Trim());
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, oFornecedor.Status);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id > 0);
               

            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Fornecedor";
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }
            return resultado;
        }

        public Resultado Atualizar(Fornecedor oFornecedor)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_FORNECEDOR_UPDATE");

                this.m_db.AddInParameter(dbCommand, "@NOMEFANTASIA", DbType.String, oFornecedor.NomeFantasia.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAZAOSOCIAL", DbType.String, oFornecedor.RazaoSocial.Trim());
                this.m_db.AddInParameter(dbCommand, "@CNPJ", DbType.String, oFornecedor.CNPJ.Trim());
                this.m_db.AddInParameter(dbCommand, "@IE", DbType.String, oFornecedor.InscricaoEstadual.Trim());
                this.m_db.AddInParameter(dbCommand, "@IM", DbType.String, oFornecedor.InscricaoMunicipal.Trim());
                this.m_db.AddInParameter(dbCommand, "@LOGRADOURO", DbType.String, oFornecedor.Logradouro.Trim());
                this.m_db.AddInParameter(dbCommand, "@BAIRRO", DbType.String, oFornecedor.Bairro.Trim());
                this.m_db.AddInParameter(dbCommand, "@CIDADE", DbType.String, oFornecedor.Cidade.Trim());
                this.m_db.AddInParameter(dbCommand, "@UF", DbType.String, oFornecedor.UF.Trim());
                this.m_db.AddInParameter(dbCommand, "@CEP", DbType.String, oFornecedor.CEP.Trim());
                this.m_db.AddInParameter(dbCommand, "@TELEFONE1", DbType.String, oFornecedor.Telefone_1.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAMAL1", DbType.String, oFornecedor.Ramal_1.Trim());
                this.m_db.AddInParameter(dbCommand, "@TELEFONE2", DbType.String, oFornecedor.Telefone_2.Trim());
                this.m_db.AddInParameter(dbCommand, "@RAMAL2", DbType.String, oFornecedor.Ramal_2.Trim());
                this.m_db.AddInParameter(dbCommand, "@CELULAR", DbType.String, oFornecedor.Celular.Trim());
                this.m_db.AddInParameter(dbCommand, "@EMAIL", DbType.String, oFornecedor.Email.Trim());
                this.m_db.AddInParameter(dbCommand, "@STATUS", DbType.Int32, oFornecedor.Status);
                this.m_db.AddInParameter(dbCommand, "@FORNECEDOR_ID", DbType.Int32, oFornecedor.FornecedorID);

                resultado.Id = Convert.ToInt32(this.m_db.ExecuteScalar(dbCommand));
                resultado.Sucesso = (resultado.Id >= 0);
            }
            catch (Exception ex)
            {
                Mensagem mensagem = new Mensagem();
                resultado.Sucesso = false;
                mensagem.Descricoes.Add(ex.Message);
                resultado.Mensagens.Add(mensagem);
            }

            return resultado;
        }

        public Resultado Excluir(int FornecedorID)
        {
            Resultado resultado = new Resultado();

            try
            {
                DbCommand dbCommand = this.m_db.GetStoredProcCommand("dbo.SP_FORNECEDOR_DELETE");
                this.m_db.AddInParameter(dbCommand, "@FORNECEDOR_ID", DbType.Int32, FornecedorID);

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
