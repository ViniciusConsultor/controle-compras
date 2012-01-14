using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class TipoDocumento
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descricao { get; set; }
    }
}
