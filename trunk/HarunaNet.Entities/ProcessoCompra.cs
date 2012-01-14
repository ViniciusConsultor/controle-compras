using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class ProcessoCompra
    {
        [DataMember]
        [DataObjectField(true, false, false)]
        public int CodProcessoCompra { get; set; }

        [DataMember]
        [DataObjectField(false, false, false)]
        public int Status { get; set; }
        
        [DataMember]
        [DataObjectField(false, false, false)]
        public string NomeCategoria { get; set; }
        
        [DataMember]
        [DataObjectField(false, false, false)]
        public string Pedidos { get; set; }
        
        [DataMember]
        [DataObjectField(false, false, false)]
        public DateTime DataProcesso { get; set; }

     
    }
}
