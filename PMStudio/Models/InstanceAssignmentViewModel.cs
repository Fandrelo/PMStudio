using PMStudio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMStudio.Models
{
    public class InstanceAssignmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PasosInstanciasDatosDetalle> Items { get; set; }
    }
}
