using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly IConsumerService _consumerService;
        private readonly IQuotesService _quotesService;
        private readonly IDBService _dbService;
        public PolicyRepository(IConsumerService consumerService, IQuotesService quotesService, IDBService dbService) {
            _consumerService = consumerService;
            _quotesService = quotesService;
            _dbService = dbService;
        }


        public async Task<List<QuoteMaster>> GetQuotes(int businessValue, int propertyValue)
        {
            PolicyMaster policyMaster =   _dbService.GetPolicyMaster(businessValue, propertyValue);
            List<QuoteMaster> quotes =  _quotesService.GetQuotesForPolicy(policyMaster);
            return quotes;
        }
        //public async Task<PolicyMaster> GetPolicy(int businessValue, int propertyValue)
        //{
        //    PolicyMaster policyMaster = _dbService.GetPolicyMaster(businessValue, propertyValue);
        //    //List<QuoteMaster> quotes = await _quotesService.GetQuotesForPolicy(policyMaster);
        //    return policyMaster;
        //}
        public async Task<ConsumerPolicy> GetPolicy(int PolicyId, int CosumerId)
        {
            return _dbService.getPolicy(PolicyId);
        }

        public async Task<ResponseObject> CreatePolicy(int consumerId, int propertyId, int amount,string agentId,int policyId)
        {
            ResponseObject responseobject = new ResponseObject { Success = true ,Message=new List<String>(){ } };
            Consumer consumer = _consumerService.GetConsumer(consumerId);
            Property property = _consumerService.GetProperty(propertyId);
            if (consumer == null)
            {
                responseobject.Success = false;
                responseobject.Message.Add("incorrect consumer id");
            }
            if (property == null)
            {
                responseobject.Success = false;
                responseobject.Message.Add("incorrect property id");
            }

            if (consumer != null && property != null && consumer.BusinessId != property.BusinesssId)
            {
                responseobject.Success = false;
                responseobject.Message.Add("this property does not belong to this business. policy creation failed.");
            }
            if (responseobject.Success == false)
                return responseobject;
            ConsumerPolicy consumerPolicy = new ConsumerPolicy
            {
                ConsumerId = consumerId,
                BusinessId = consumer.BusinessId,
                PropertyId = propertyId,
                Amount = amount,
                PolicyMasterId = policyId,
                Status = PolicyStatus.Initiated,
                PaymentDetails = null,
            };

            if (_dbService.CreatePolicy(consumerPolicy))
            {
                responseobject.Message.Add("Policy Created Successfully");
                responseobject.Data = new { policyId = consumerPolicy.Id};
                return responseobject;
            }
            responseobject.Success = false;
            responseobject.Message.Add("Somer Eror Occured");
            return responseobject;
        }

        public async Task<ResponseObject> IssuePolicy(int policyId, int consumerId, int businessId, Transaction transaction)
        {
            ResponseObject responseobject = new ResponseObject
            {
                Success = true,
                Message = new List<String>() { }
            };

            ConsumerPolicy policy =  _dbService.getPolicy(policyId);
            if (policy == null)
            {
                responseobject.Success = false;
                responseobject.Message.Add($"policy Not Found");
                return responseobject;
            }

            
            if (_dbService.createTrasaction(transaction))
            {
                responseobject.Message.Add($"Transaction Created Successfully. Id={transaction.Id}");
            }
            else
            {
                responseobject.Success = false;
                responseobject.Message.Add($"Adding Transaction Failed");
                return responseobject;
            }
            policy.TransactionID = transaction.Id;
            if (_dbService.updatePolicyStatus(policy))
            {
                responseobject.Message.Add($"POlicy Issued Successfully. Id={policy.Id}");
            }
            else
            {
                responseobject.Success = false;
                responseobject.Message.Add($"Policy Updation Failed");
                return responseobject;
            }



            return responseobject;
        }


        public int calculateBusinessValue(Business business)
        {
            double annaulTurnover = business.AnnualTurnOver;
            double capitalInvested = business.CapitalInvested;
            int businessValue = (int)((capitalInvested / annaulTurnover) * 3.5);
            if (businessValue < 0)
                return 0;
            if (businessValue > 10)
                return 10;
            return businessValue;
        }
        public int calculatePropertyValue(Property property)
        {
            double annualDepreciation = (property.CostOfAsset - property.SalvageValue) / (100 - property.PropertyAge);
            // Normalize

            double Value = 10-((annualDepreciation / property.CostOfAsset) * 10);
            if (Value < 0)
                return 0;
            if (Value > 10)
                return 10;
            return (int)Value;

        }

        
    }
}
