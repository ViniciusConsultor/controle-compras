using System;
using System.Collections.Generic;
using System.Text;
using HarunaNet.Entities;
using HarunaNet.BusinessRules.Process;

namespace HarunaNet.BusinessRules
{
    public class GrupoFacade
    {
        public List<Grupo> Listar(ref Resultado resultado)
        {
            return new GrupoProcess().Listar(ref resultado);
        }
    }
}
