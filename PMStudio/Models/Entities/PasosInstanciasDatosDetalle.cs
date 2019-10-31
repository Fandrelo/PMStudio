using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMStudio.Models.Entities
{
    public partial class PasosInstanciasDatosDetalle
    {
        public int IdPasosInstanciasDatos { get; set; }
        [DisplayName("Dato")]
        public int InstanciaPlantillaDato { get; set; }
        public int Paso { get; set; }
        [DisplayName("Solo Lectura")]
        public bool? SoloLectura { get; set; }

        public virtual InstanciasPlantillasDatosDetalle InstanciaPlantillaDatoNavigation { get; set; }
        public virtual PasosInstancias PasoNavigation { get; set; }
    }
}
