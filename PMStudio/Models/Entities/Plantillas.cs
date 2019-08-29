using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class Plantillas
    {
        public Plantillas()
        {
            PlantillasCamposDetalle = new HashSet<PlantillasCamposDetalle>();
            PlantillasPasosDetalle = new HashSet<PlantillasPasosDetalle>();
        }

        public int IdPlantilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
        public virtual ICollection<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
    }
}
