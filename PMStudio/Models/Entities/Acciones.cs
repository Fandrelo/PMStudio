using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class Acciones
    {
        public Acciones()
        {
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
        }

        public string Nombre { get; set; }
        public decimal IdAccion { get; set; }

        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
    }
}
