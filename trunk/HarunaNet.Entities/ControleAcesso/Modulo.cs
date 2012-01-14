using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Modulo
    {
        private int _MODULO_ID = 0;
        private string _DESCRICAO = "";
        private int _PODE_ACESSAR = 0;
        private string _PAGINA_WEB = "";
        public bool ItemMenu { get; set; }
        public string EnderecoWeb { get; set; }

        [DataMember()]
        [DataObjectField(true, false, false)]
        public int ModuloId { get { return _MODULO_ID; } set { _MODULO_ID = value; } }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public string Descricao { get { return _DESCRICAO; } set { _DESCRICAO = value; } }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public int PodeAcessar { get { return _PODE_ACESSAR; } set { _PODE_ACESSAR = value; } }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public string PaginaWeb { get { return _PAGINA_WEB; } set { _PAGINA_WEB = value; } }
    }
}
