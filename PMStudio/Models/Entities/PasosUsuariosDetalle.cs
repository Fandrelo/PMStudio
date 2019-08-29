using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class PasosUsuariosDetalle
    {
        public decimal PlantillaPasoDetalle { get; set; }
        public decimal Usuario { get; set; }
        public string AspNetUser { get; set; }
        public decimal IdPasosUsuarios { get; set; }

        public virtual InstanciasPlantillasPasosDetalle PlantillaPasoDetalleNavigation { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
    }
}
