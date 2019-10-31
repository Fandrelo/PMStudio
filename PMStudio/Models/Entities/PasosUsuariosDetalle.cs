using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMStudio.Models.Entities
{
    /// <summary>
    /// Instanced steps
    /// </summary>
    public partial class PasosUsuariosDetalle
    {
        public int IdPasosUsuarios { get; set; }
        public int PlantillaPasoDetalle { get; set; }
        [DisplayName("Usuario")]
        public string AspNetUser { get; set; }

        public virtual InstanciasPlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
    }
}
