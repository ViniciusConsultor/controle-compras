using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Fornecedor
    {
        public int FornecedorID { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Telefone_1 { get; set; }
        public string Ramal_1 { get; set; }
        public string Telefone_2 { get; set; }
        public string Ramal_2 { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
