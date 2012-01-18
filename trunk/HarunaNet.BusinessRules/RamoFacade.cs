using System.Collections.Generic;

using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;
namespace HarunaNet.BusinessRules
{
     public class RamoFacade
    {
         public List<Ramo> Listar(ref Resultado resultado)
         {
             return new RamoProcess().Listar(ref resultado);
         }
    }
}
