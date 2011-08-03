using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using HarunaNet.BusinessRules;
using HarunaNet.BusinessRules.Process;
using HarunaNet.BusinessRules.Validation;
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
