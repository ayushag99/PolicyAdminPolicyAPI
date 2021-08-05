using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Interface
{
    public interface IPolicyRepository
    {
        Task<ResponseObject> CreatePolicy(int consumerId, int propertyId, int amount, string agentId, int policyId);
        Task<List<QuoteMaster>> GetQuotes(int businessValue, int propertyValue);
        Task<object> GetPolicy(int PolicyId, int CosumerId);
        Task<ResponseObject> IssuePolicy(int policyId, int consumerId, int businessId, Transaction tranasction);
        Task<object> GetPolicyMaster(int ConsumerId, int PropertyId);
    }
}
