using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class InputCreatePolicy
    {
        public int consumerId { get; set; }
        public int propertyId { get; set; }
        public int amount { get; set; }
        public int agentId { get; set; }
        public int policyMasterId { get; set; }
    }
}
