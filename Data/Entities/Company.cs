using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class Company
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
