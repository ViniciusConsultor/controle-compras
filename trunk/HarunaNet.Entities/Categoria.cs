using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public Ramo Ramo { get; set; }
    }
}
