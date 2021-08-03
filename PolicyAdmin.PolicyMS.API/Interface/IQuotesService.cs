using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Interface
{
    public interface IQuotesService
    {
        List<QuoteMaster> GetQuotesForPolicy(PolicyMaster policyMaster);
    }
}
