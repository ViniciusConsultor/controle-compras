using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Perfil
    {
        private int _PERFIL_ID = 0;
        private string _DESCRICAO = "";
        private string _SearchSQL = "";
        private List<Modulo> _Modulos = new List<Modulo>();

        [DataMember()]
        [DataObjectField(true, false, false)]
        public int PerfilId { get { return _PERFIL_ID; } set { _PERFIL_ID = value; } }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public string Descricao { get { return _DESCRICAO; } set { _DESCRICAO = value; } }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public List<Modulo> Modulos { get { return _Modulos; } set { _Modulos = value; } }

    }
}
