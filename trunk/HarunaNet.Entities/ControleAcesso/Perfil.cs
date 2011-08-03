using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Perfil
    {
        private int _PERFIL_ID = 0;
        private string _DESCRICAO = "";
        private string _SearchSQL = "";
        private List<Modulo> _Modulos = new List<Modulo>();

        public int PerfilId { get { return _PERFIL_ID; } set { _PERFIL_ID = value; } }
        public string Descricao { get { return _DESCRICAO; } set { _DESCRICAO = value; } }
        public List<Modulo> Modulos { get { return _Modulos; } set { _Modulos = value; } }

    }
}
