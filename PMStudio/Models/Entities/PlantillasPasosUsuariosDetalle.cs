using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMStudio.Models.Entities
{
    public partial class PlantillasPasosUsuariosDetalle
    {
        public int IdPlantillaPasosUsuarios { get; set; }
        public int PlantillaPasoDetalle { get; set; }
        [DisplayName("Usuario")]
        public string AspNetUser { get; set; }

        public virtual PlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
    }
}
