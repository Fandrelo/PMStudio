using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class Rangos
    {
        public Rangos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdRango { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
