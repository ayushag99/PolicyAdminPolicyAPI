using Microsoft.AspNetCore.Mvc;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolicyAdmin.PolicyMS.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyrepo;
        public PolicyController(IPolicyRepository policyrepo)
        {
            _policyrepo = policyrepo;
        }

        // GET: api/<PolicyController>
        [HttpGet]
        public async Task<List<QuoteMaster>> GetQuotes(int businessValue, int propertyValue)
        {
            List<QuoteMaster>  quotes = await _policyrepo.GetQuotes(businessValue, propertyValue);
            return quotes;
        }// GET: api/<PolicyController>
        [HttpGet]
        public async Task<ConsumerPolicy> GetPolicy(int PolicyId, int ConsumerId)
        {
            ConsumerPolicy  consumerPolicy = await _policyrepo.GetPolicy(PolicyId, ConsumerId);
            return consumerPolicy;
        }
        [HttpPost]
        public async Task<ResponseObject> CreatePolicy(InputCreatePolicy input)
        {
            ResponseObject responseObject = await _policyrepo.CreatePolicy(input.consumerId,input.propertyId,input.amount, input.agentId, input.policyMasterId);
            return responseObject;
        }
        [HttpPost]
        public async Task<ResponseObject> IssuePolicy(InputIssuePolicy input)
        {
            ResponseObject responseObject = await _policyrepo.IssuePolicy(input.PolicyId,input.ConsuemrId, input.BusinessId, input.PaymentDetails);
            return responseObject;
        }


    }
}
