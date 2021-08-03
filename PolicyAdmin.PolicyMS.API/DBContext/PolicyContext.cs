using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyAdmin.PolicyMS.API.Models;

namespace PolicyAdmin.PolicyMS.API.DBContext

{
    public class PolicyContext : DbContext
    {
        public PolicyContext() { }
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) { }

        public DbSet<PolicyMaster> PolicyMasters { get; set; }
        public DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
    }
}
