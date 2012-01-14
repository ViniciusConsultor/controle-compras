using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;

namespace HarunaNet.SisWeb
{
    public class HarunaService : IHarunaService
    {
        public List<TipoDocumento> ListarTipoDocumento()
        {
            Resultado resultado = new Resultado();

            List<TipoDocumento> Teste = new TipoDocumentoFacade().Listar(ref resultado);

            return Teste;
        }

        public List<Usuario> ListarUsuarios()
        {
            Resultado resultado = new Resultado();
            List<Usuario> Teste = new UsuarioFacade().Listar("", ref resultado);
            return Teste;

        }
    }
}
