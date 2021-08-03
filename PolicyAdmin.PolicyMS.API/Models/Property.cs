using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int BusinesssId { get; set; }
        [ForeignKey("BusinesssId")]
        public Business Business { get; set; }
        public PropertyType PropertyType { get; set; }
        public double BuildingSqFt { get; set; }
        public int Storeys { get; set; }
        public int PropertyAge { get; set; }
        public double CostOfAsset { get; set; }
        public double SalvageValue { get; set; }

    }
}
