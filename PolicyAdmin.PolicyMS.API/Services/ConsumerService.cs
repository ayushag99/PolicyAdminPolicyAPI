using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationManager _auth;

        public ConsumerService(IConfiguration configuration, IAuthenticationManager auth)
        {
            _auth = auth;
            _configuration = configuration;
        }
        public Consumer GetConsumer(int consumerId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetConnectionString("ConsumerAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _auth.AuthToken);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                //_log4net.Debug("Connecting with PensionDetails");
                try
                {
                    response = client.GetAsync($"ViewConsumerBusiness?id={consumerId}").Result;
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
                    Consumer consumer = JsonConvert.DeserializeObject<Consumer>(ObjResponse);
                    return consumer;
                }
                return null;
            }
        }

        public Property GetProperty(int propertyId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetConnectionString("ConsumerAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _auth.AuthToken);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                //_log4net.Debug("Connecting with PensionDetails");
                try
                {
                    response = client.GetAsync($"ViewBusinessProperty?id={propertyId}").Result;
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
                    Property property = JsonConvert.DeserializeObject<Property>(ObjResponse);
                    return property;
                }
                return null;
            }
        }
    }
}
