using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMStudio.Models.Entities
{
    public partial class Plantillas
    {
        public Plantillas()
        {
            PlantillasCamposDetalle = new List<PlantillasCamposDetalle>();
            PlantillasPasosDetalle = new List<PlantillasPasosDetalle>();
            PasosPlantillasCamposDetalle = new List<PasosPlantillasCamposDetalle>();
        }

        public int IdPlantilla { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual List<PlantillasCamposDetalle> PlantillasCamposDetalle { get; set; }
        public virtual List<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
        [NotMapped]
        public virtual List<PasosPlantillasCamposDetalle> PasosPlantillasCamposDetalle { get; set; }
    }
}
