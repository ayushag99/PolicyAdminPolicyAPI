using Microsoft.EntityFrameworkCore;
using PolicyAdmin.PolicyMS.API.DBContext;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Services
{

    public class DBService : IDBService
    {
        private readonly PolicyContext _context;
        public DBService(PolicyContext policyContext)
        {
            _context = policyContext;
        }

        public bool CreatePolicy(ConsumerPolicy consumerPolicy)
        {
            _context.ConsumerPolicies.Add(consumerPolicy);
            int val = _context.SaveChanges();
            if (val > 0)
            {
                return true;
            }
            return false;
        }

        public bool createTrasaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            int val = _context.SaveChanges();
            if (val > 0)
            {
                return true;
            }
            return false;
        }

        public ConsumerPolicy getPolicy(int policyId)
        {
            ConsumerPolicy policy = _context.ConsumerPolicies.FirstOrDefault(policy => policy.Id == policyId);
            if (policy.TransactionID > 0)
            {
                policy.PaymentDetails = _context.Transactions.Find(policy.TransactionID);
            }
            return policy;
        
        }

        public PolicyMaster GetPolicyMaster(int businessValue, int propertyValue)
        {
            return  _context.PolicyMasters.FirstOrDefault(pm => pm.BusinessValue == businessValue && pm.PropertyValue == propertyValue);
            
        }

        public bool updatePolicyStatus(ConsumerPolicy consumerPolicy)
        {
            try
            {
               
                _context.Entry(consumerPolicy).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }


            return true;
        }
    }
}
