using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class InstanciasPlantillasPasosDetalle
    {
        public InstanciasPlantillasPasosDetalle()
        {
            PasosUsuariosDetalle = new HashSet<PasosUsuariosDetalle>();
        }

        public decimal InstanciaPlantilla { get; set; }
        public decimal Paso { get; set; }
        public decimal? Estado { get; set; }
        public decimal IdPlantillaPasoDetalle { get; set; }
        public decimal? UsuarioAccion { get; set; }

        public virtual Acciones EstadoNavigation { get; set; }
        public virtual InstanciasPlantillas InstanciaPlantillaNavigation { get; set; }
        public virtual PasosInstancias PasoNavigation { get; set; }
        public virtual Usuarios UsuarioAccionNavigation { get; set; }
        public virtual ICollection<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }
    }
}
