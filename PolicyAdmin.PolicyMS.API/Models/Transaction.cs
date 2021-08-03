using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public double Amount { get; set; }
        public string PayerName { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }

    }
}
