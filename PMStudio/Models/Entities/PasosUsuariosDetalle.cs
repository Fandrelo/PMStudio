using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    /// <summary>
    /// Instanced steps
    /// </summary>
    public partial class PasosUsuariosDetalle
    {
        public int IdPasosUsuarios { get; set; }
        public int PlantillaPasoDetalle { get; set; }
        public string AspNetUser { get; set; }

        public virtual InstanciasPlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
    }
}
