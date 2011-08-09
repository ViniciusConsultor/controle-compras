using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class menu
    {
        public Int32 CodMenu { get; set; }
        public string ItemMenu { get; set; }
        public int ItemPai { get; set; }
        public string Pagina { get; set; }
        public bool Visivel { get; set; }
        public List<menu> itens { get; set; }
    }
}