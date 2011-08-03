using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class TipoDocumento
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
