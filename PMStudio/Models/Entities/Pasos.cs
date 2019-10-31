using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMStudio.Models.Entities
{
    public partial class Pasos
    {
        public Pasos()
        {
            PlantillasPasosDetalle = new HashSet<PlantillasPasosDetalle>();
            PasosPlantillasCamposDetalle = new List<PasosPlantillasCamposDetalle>();
        }

        public int IdPaso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha Fin")]
        public DateTime? FechaFin { get; set; }
        public int? Numero { get; set; }

        public virtual ICollection<PlantillasPasosDetalle> PlantillasPasosDetalle { get; set; }
        public virtual List<PasosPlantillasCamposDetalle> PasosPlantillasCamposDetalle { get; set; }
    }
}
