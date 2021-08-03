using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public BusinessType BusinessType { get; set; }
        public double AnnualTurnOver { get; set; }
        public double CapitalInvested { get; set; }
        public DateTime BusinesIncorporation { get; set; }
        public int TotalEmployees { get; set; }
    }
}
