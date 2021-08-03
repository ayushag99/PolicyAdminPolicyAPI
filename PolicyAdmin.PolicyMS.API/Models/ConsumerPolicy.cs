using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class ConsumerPolicy
    {
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public int BusinessId { get; set; }
        public int PropertyId { get; set; }
        public int Amount { get; set; }

        public int PolicyMasterId { get; set; }
        [ForeignKey("PolicyMasterId")]
        public PolicyMaster Policy { get; set; }

        public PolicyStatus Status { get; set; }
        public int TransactionID { get; set; }
        [ForeignKey("TransactionID")]
        public Transaction PaymentDetails { get; set; }
    }
}
