using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Projetos
    {
        public int ProjetoID { get; set; }
        public string Nome { get; set; }
        public int CentrodeCusto { get; set; }
    }
}
