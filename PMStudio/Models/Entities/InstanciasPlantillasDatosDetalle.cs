using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class InstanciasPlantillasDatosDetalle
    {
        public InstanciasPlantillasDatosDetalle()
        {
            PasosInstanciasDatosDetalle = new HashSet<PasosInstanciasDatosDetalle>();
        }

        public int IdInstanciaPlantillaDato { get; set; }
        public int Instanciaplantilla { get; set; }
        public string NombreCampo { get; set; }
        public string Dato { get; set; }

        public virtual InstanciasPlantillas InstanciaplantillaNavigation { get; set; }
        public virtual ICollection<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
    }
}
