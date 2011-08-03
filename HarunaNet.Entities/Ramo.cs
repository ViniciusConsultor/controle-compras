using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Ramo
    {
        public int RamoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
    }
}
