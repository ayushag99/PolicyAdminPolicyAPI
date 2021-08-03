using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class InputIssuePolicy
    {
        public int PolicyId { get; set; } 
        public int ConsuemrId { get; set; } 
        public int BusinessId { get; set; } 
        public Transaction PaymentDetails { get; set; }
    }
}
