using System.Collections.Generic;
using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules
{
     public class UnidadeMedidaFacade
    {
         public List<UnidadeMedida> Listar(ref Resultado resultado)
         {
             return new UnidadeMedidaProcess().Listar(ref resultado);
         }
    }
}
