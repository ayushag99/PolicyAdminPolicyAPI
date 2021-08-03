using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Services
{
    public class QuotesService : IQuotesService
    {
        private readonly IConfiguration _configuration;
        public QuotesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<QuoteMaster> GetQuotesForPolicy(PolicyMaster policyMaster)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetConnectionString("QuotesAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                //_log4net.Debug("Connecting with PensionDetails");




                try
                {
                    response = client.GetAsync($"getQuotesForPolicy?propertyType={policyMaster.PropertyType}&propertyValue={policyMaster.PropertyValue}&businessValue={policyMaster.BusinessValue}").Result;
                }
                catch (Exception e)
                {

                    response = null;

                }

                if
                    (response != null)
                {
                    // _log4net.Debug("Connecting Sucessfull");

                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    List<QuoteMaster> quotes = JsonConvert.DeserializeObject<List<QuoteMaster>>(ObjResponse);
                    return quotes;
                }
                return null;
            }
        }
    }
}
