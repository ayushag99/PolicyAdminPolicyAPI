using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Models;
using PolicyAdmin.PolicyMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Repository
{
    public class AuthenticationRepo : IAuthenticationManager
    {
        public string AuthToken { get ; set ; }
    }
}
