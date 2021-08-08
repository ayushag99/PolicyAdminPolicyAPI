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
        private string _authToken;
        public string AuthToken {
            get
            {
                return this._authToken;
            }
            set
            {
                if (value == null)
                {
                    this._authToken = "";
                }
                else
                {
                    this._authToken = value.Split(" ")[1];
                }
            }
        }

        
    }
}
