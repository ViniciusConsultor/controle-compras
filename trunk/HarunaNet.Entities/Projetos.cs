using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Projetos
    {
        public int ProjetoID { get; set; }
        public string Nome { get; set; }
        public int CentrodeCusto { get; set; }
    }
}
