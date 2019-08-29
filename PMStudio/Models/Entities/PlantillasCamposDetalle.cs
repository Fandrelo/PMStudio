using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class PlantillasCamposDetalle
    {
        public decimal IdPlantillaCampo { get; set; }
        public decimal Plantilla { get; set; }
        public string NombreCampo { get; set; }

        public virtual Plantillas PlantillaNavigation { get; set; }
    }
}
