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
    public class ProjetosFacade
    {
        public List<Projetos> Listar(ref Resultado resultado)
        {
            return new ProjetosProcess().Listar(ref resultado);
        }
    }
}
