using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class menu
    {
        [DataMember()]
        [DataObjectField(true, false, false)]
        public Int32 CodMenu { get; set; }

        [DataMember()]
        [DataObjectField(false, false, false)]
        public string ItemMenu { get; set; }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public int ItemPai { get; set; }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public string Pagina { get; set; }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public bool Visivel { get; set; }
        [DataMember()]
        [DataObjectField(false, false, false)]
        public List<menu> itens { get; set; }
    }
}