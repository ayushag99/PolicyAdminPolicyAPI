using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class PolicyMaster
    {

        public int Id { get; set; }
        public PropertyType PropertyType { get; set; }
        public ConsumerType ConsumerType { get; set; }
        public double AssuredSum { get; set; }
        public int Tenure { get; set; }
        public int BusinessValue { get; set; }
        public int PropertyValue { get; set; }
        public string Loacation { get; set; }
        public PolicyType policyType { get; set; }
    }
}
