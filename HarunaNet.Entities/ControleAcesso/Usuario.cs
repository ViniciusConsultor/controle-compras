using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
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
        private Perfil _PERFIL = new Perfil();
        private Grupo _Area = new Grupo();

        [DataMember]
        [DataObjectField(false, false, false)]
        public List<menu> ItensMenu { get; set; }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string NovaSenha { get; set; }

        [DataMember]
        [DataObjectField(true, false, false)]
        public int UsuarioId { get { return _USUARIO_ID; } set { _USUARIO_ID = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string Nome { get { return _NOME; } set { _NOME = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string Login { get { return _LOGIN; } set { _LOGIN = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string Email { get { return _EMAIL; } set { _EMAIL = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public int PerfilId { get { return _PERFIL_ID; } set { _PERFIL_ID = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string Senha { get { return _SENHA; } set { _SENHA = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public object SenhaCript { get { return _SENHACRIPTOGRAFADA; } set { _SENHACRIPTOGRAFADA = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public string Status { get { return _STATUS; } set { _STATUS = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public Perfil Perfil { get { return _PERFIL; } set { _PERFIL = value; } }

        [DataMember]
        [DataObjectField(false, false, false)]
        public Grupo Area { get { return _Area; } set { _Area = value; } }

        #endregion
    }
}
