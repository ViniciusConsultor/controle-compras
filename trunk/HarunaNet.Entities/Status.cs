using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Status
    {
        public int StatusId { get; set; }
        public string Descricao { get; set; }
    }
}
