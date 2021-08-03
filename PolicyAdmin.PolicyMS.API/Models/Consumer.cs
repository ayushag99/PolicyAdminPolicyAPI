using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API.Models
{
    public class Consumer
    {
        public int Id { get; set; }

        [Required]
        public string ConsumerName { get; set; }

        [Required]
        public DateTime ConsumerDOB { get; set; }

        [Required]
        public string ConsumerEmail { get; set; }

        [Required]
        public string ConsumerPan { get; set; }

        [Required]
        public string AgentId { get; set; }

        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
