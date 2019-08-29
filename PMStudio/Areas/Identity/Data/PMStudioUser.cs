using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PMStudio.Models.Entities;

namespace PMStudio.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PMStudioUser class
    public class PMStudioUser : IdentityUser
    {
        public PMStudioUser()
        {
            InstanciasPlantillas = new HashSet<InstanciasPlantillas>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosUsuariosDetalle = new HashSet<PasosUsuariosDetalle>();
        }

        public virtual ICollection<InstanciasPlantillas> InstanciasPlantillas { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual ICollection<PasosUsuariosDetalle> PasosUsuariosDetalle { get; set; }
    }
}
