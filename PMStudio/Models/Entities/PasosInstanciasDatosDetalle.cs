using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class PasosInstanciasDatosDetalle
    {
        public decimal InstanciaPlantillaDato { get; set; }
        public decimal Paso { get; set; }
        public string SoloLectura { get; set; }
        public decimal IdPasosInstanciasDatos { get; set; }

        public virtual InstanciasPlantillasDatosDetalle InstanciaPlantillaDatoNavigation { get; set; }
        public virtual PasosInstancias PasoNavigation { get; set; }
    }
}
