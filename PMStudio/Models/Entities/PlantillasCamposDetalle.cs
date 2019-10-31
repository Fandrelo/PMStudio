using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMStudio.Models.Entities
{
    public partial class PlantillasCamposDetalle
    {
        public PlantillasCamposDetalle()
        {
            PasosPlantillasCamposDetalle = new List<PasosPlantillasCamposDetalle>();
        }
        public int IdPlantillaCampo { get; set; }
        public int Plantilla { get; set; }
        [DisplayName("Tipo de Dato")]
        public int IdDatoTipo { get; set; }
        [DisplayName("Nombre")]
        public string NombreCampo { get; set; }

        public virtual DatoTipo IdDatoTipoNavigation { get; set; }
        public virtual Plantillas PlantillaNavigation { get; set; }
        public virtual List<PasosPlantillasCamposDetalle> PasosPlantillasCamposDetalle { get; set; }
    }
}
