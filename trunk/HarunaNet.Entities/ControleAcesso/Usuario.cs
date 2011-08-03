using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Usuario
    {
        #region Parte VO
        private int _USUARIO_ID = 0;
        private string _NOME = "";
        private string _LOGIN = "";
        private string _EMAIL = "";
        private int _PERFIL_ID = 0;
        private string _SENHA = ""; //a ser criptografada quando for gravada no BD
        private object _SENHACRIPTOGRAFADA; //a ser criptografada quando for gravada no BD
        private string _STATUS = "";
        private string _SqlSearch = "";
        private Perfil _PERFIL = new Perfil();
        private Grupo _Area = new Grupo();
        private string _Novasenha = "";

        public List<menu> ItensMenu { get; set; }
        
        public string NovaSenha { get { return _Novasenha; } set { _Novasenha = value; } }

        public int UsuarioId { get { return _USUARIO_ID; } set { _USUARIO_ID = value; } }
        public string Nome { get { return _NOME; } set { _NOME = value; } }
        public string Login { get { return _LOGIN; } set { _LOGIN = value; } }
        public string Email { get { return _EMAIL; } set { _EMAIL = value; } }
        public int PerfilId { get { return _PERFIL_ID; } set { _PERFIL_ID = value; } }
        public string Senha { get { return _SENHA; } set { _SENHA = value; } }
        public object SenhaCript { get { return _SENHACRIPTOGRAFADA; } set { _SENHACRIPTOGRAFADA = value; } }
        public string Status { get { return _STATUS; } set { _STATUS = value; } }
        public Perfil Perfil { get { return _PERFIL; } set { _PERFIL = value; } }
        public Grupo Area { get { return _Area; } set { _Area = value; } } 
         
        #endregion
    }
}
