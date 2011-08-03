using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Status
    {
        public int StatusId { get; set; }
        public string Descricao { get; set; }
    }
}
