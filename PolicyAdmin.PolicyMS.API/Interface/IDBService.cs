using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Interface
{
    public interface IDBService
    {

        bool CreatePolicy(ConsumerPolicy consumerPolicy) ;
        PolicyMaster GetPolicyMaster(int businessValue, int propertyValue);

        bool createTrasaction(Transaction transaction);
        bool updatePolicyStatus(ConsumerPolicy consumerPolicy);

        ConsumerPolicy getPolicy(int policyId);
    }
}
