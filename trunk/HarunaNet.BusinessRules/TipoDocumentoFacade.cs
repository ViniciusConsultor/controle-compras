using System.Collections.Generic;

using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules
{
    public class TipoDocumentoFacade
    {
        public List<TipoDocumento> Listar(ref Resultado resultado)
        {
            return new TipoDocumentoProcess().Listar(ref resultado);
        }

      
    }
}
