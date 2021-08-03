using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models.Enum
{
    public enum PaymentMethodType
    {
        UPI=0,
        Cash = 1,
        DebitCard=2,
        Cheque=3,
        CreditCard=4,
        NetBanking=5,
        RTGS=6,
        NEFT=7,
    }
}
