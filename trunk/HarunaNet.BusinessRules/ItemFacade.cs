using System.Collections.Generic;

using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules
{
    public class ItemFacade
    {
        public List<Item> Listar(int CategoriaID, ref Resultado resultado)
        {
            return new ItemProcess().Listar(CategoriaID, ref resultado);
        }

        public Item Seleciona(int ID, ref Resultado resultado)
        { 
            return new ItemProcess().Seleciona(ID, ref resultado); 
        }

        public Resultado Inserir(Item oItem)
        {
            Resultado resultado = new Resultado();

            resultado = new ItemProcess().Incluir(oItem);
            return resultado;
        }

        public Resultado Atualiza(Item oItem)
        {
            Resultado resultado = new Resultado();

            resultado = new ItemProcess().Atualiza(oItem);
            return resultado;
        }

        public Resultado Excluir(Item oItem)
        {
            Resultado resultado = new Resultado();

            resultado = new ItemProcess().Atualiza(oItem);
            return resultado;
        }
    }
}
