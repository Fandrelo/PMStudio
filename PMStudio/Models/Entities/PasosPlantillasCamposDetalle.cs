using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMStudio.Models.Entities
{
    public partial class PasosPlantillasCamposDetalle
    {
        public int IdPasosPlantillasDatos { get; set; }
        [DisplayName("Dato")]
        public int PlantillaCampo { get; set; }
        public int Paso { get; set; }
        [DisplayName("Solo Lectura")]
        public bool SoloLectura { get; set; }

        public virtual PlantillasCamposDetalle PlantillaCampoNavigation { get; set; }
        public virtual Pasos PasoNavigation { get; set; }
    }
}
