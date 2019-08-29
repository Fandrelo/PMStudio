using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace PMStudio.Models.Entities
{
    public partial class InstanciasPlantillas
    {
        public InstanciasPlantillas()
        {
            InstanciasPlantillasDatosDetalle = new HashSet<InstanciasPlantillasDatosDetalle>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
        }

        public string Nombre { get; set; }
        public decimal Usuario { get; set; }
        public string AspNetUser { get; set; }
        public string Estado { get; set; }
        public decimal IdInstanciaPlantilla { get; set; }
        public string Iniciada { get; set; }
        public string Descripcion { get; set; }

        public virtual Usuarios UsuarioNavigation { get; set; }
        public virtual PMStudioUser AspNetUserNavigation { get; set; }
        public virtual ICollection<InstanciasPlantillasDatosDetalle> InstanciasPlantillasDatosDetalle { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
    }
}
