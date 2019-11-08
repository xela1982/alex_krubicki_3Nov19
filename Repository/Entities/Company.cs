using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class Company
    {
        [Key]
        [Column("company_id")]
        public int CompanyId { get; set; }
        [Column("company_name")]
        public string CompanyName { get; set; }
    }
}
