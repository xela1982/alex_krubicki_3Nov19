
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace alex_krubicki_3Nov19.Entities
{
    public class Report
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserFullName { get; set; }
        [Required]
        public int  Last4Digits { get; set; }
        [Required]
        public double Payment { get; set; }
        
    }
}