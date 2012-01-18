using System;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
    [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class UnidadeMedida
    {
         public UnidadeMedida(int id, string nome)
         {
             this.Id = id;
             this.Nome = nome;
         }

         public UnidadeMedida()
         {
         }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
    }
}
