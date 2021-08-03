using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class ResponseObject
    {
        public bool Success { get; set; }
        public List<string> Message { get; set; }
        public object Data { get; set; }
    }
}
