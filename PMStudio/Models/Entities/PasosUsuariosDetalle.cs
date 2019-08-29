using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class PasosUsuariosDetalle
    {
        public int PlantillaPasoDetalle { get; set; }
        public int Usuario { get; set; }
        public string AspNetUser { get; set; }
        public int IdPasosUsuarios { get; set; }

        public virtual InstanciasPlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
    }
}
