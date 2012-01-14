using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
     [Serializable()]
   [DataContract(Namespace = "HarunaNet.Entities")]
    public class Grupo
    {
       [DataMember()]
       [DataObjectField(true, false, false)]
        public int ID { get; set; }
       [DataMember()]
       [DataObjectField(false, false, false)]
        public string Nome { get; set; }
    }

}
