using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            InstanciasPlantillas = new HashSet<InstanciasPlantillas>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosUsuariosDetalle = new HashSet<PasosUsuariosDetalle>();
        }

        public decimal IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string UsuarioEmail { get; set; }
        public decimal Rango { get; set; }

        public virtual Rangos RangoNavigation { get; set; }
        public virtual ICollection<InstanciasPlantillas> InstanciasPlantillas { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual ICollection<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }
    }
}
