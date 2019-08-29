using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class PasosInstancias
    {
        public PasosInstancias()
        {
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosInstanciasDatosDetalle = new HashSet<PasosInstanciasDatosDetalle>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdPasoinstancia { get; set; }

        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual ICollection<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
    }
}
