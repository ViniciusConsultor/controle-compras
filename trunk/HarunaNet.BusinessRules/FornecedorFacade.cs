using System.Collections.Generic;
using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;


namespace HarunaNet.BusinessRules
{
    public class FornecedorFacade
    {
        public List<Fornecedor> Listar(ref Resultado resultado, Fornecedor oFornecedor)
        {
            return new FornecedorProcess().Listar(ref resultado, oFornecedor);
        }

        public Fornecedor Obter(ref Resultado resultado, int FornecedorID)
        {
            return new FornecedorProcess().Obter(ref resultado, FornecedorID);
        }


        public Resultado Salvar(Fornecedor oFornecedor)
        {
            Resultado resultado;
            if (oFornecedor.FornecedorID > 0)
            {
                resultado = new FornecedorProcess().Atualizar(oFornecedor);
            }
            else
            {
                resultado = new FornecedorProcess().Inserir(oFornecedor);
            }
            return resultado;
        }
    }
}
