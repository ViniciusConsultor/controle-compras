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
    public class CategoriaFacade
    {
        public List<Categoria> Listar(ref Resultado resultado)
        {
            return new CategoriaProcess().Listar(ref resultado); 
        }
    }
}
