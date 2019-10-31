using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMStudio.Models.Entities
{
    public partial class PasosInstancias
    {
        public PasosInstancias()
        {
            InstanciasPlantillasPasosDetalle = new HashSet<InstanciasPlantillasPasosDetalle>();
            PasosInstanciasDatosDetalle = new List<PasosInstanciasDatosDetalle>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdPasoinstancia { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Fin")]
        public DateTime? FechaFin { get; set; }
        [NotMapped]
        public int IdLinkHelper { get; set; }
        public int? Numero { get; set; }

        public virtual ICollection<InstanciasPlantillasPasosDetalle> InstanciasPlantillasPasosDetalle { get; set; }
        public virtual List<PasosInstanciasDatosDetalle> PasosInstanciasDatosDetalle { get; set; }
    }
}
