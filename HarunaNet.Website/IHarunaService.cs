using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHarunaService" in both code and config file together.
    [ServiceContract]
    public interface IHarunaService
    {
        
        [OperationContract]
        List<TipoDocumento> ListarTipoDocumento();

        [OperationContract]
        List<Usuario> ListarUsuarios();
    }
}
