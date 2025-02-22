﻿using PMStudio.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMStudio.Models.Entities
{
    public partial class InstanciasPlantillas
    {
        public InstanciasPlantillas()
        {
            InstanciasPlantillasDatosDetalle = new HashSet<InstanciasPlantillasDatosDetalle>();
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
        }

        public int IdInstanciaPlantilla { get; set; }
        public string Nombre { get; set; }
        public string AspNetUser { get; set; }
        public string Estado { get; set; }
        public string Iniciada { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        [NotMapped]
        public int DoneSteps { get; set; }

        public virtual PMStudioUser AspNetUserNavigation { get; set; }
        public virtual ICollection<InstanciasPlantillasDatosDetalle> InstanciasPlantillasDatosDetalle { get; set; }
        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
    }
}
