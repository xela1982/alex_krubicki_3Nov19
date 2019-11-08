using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class EmployeesCards
    {
        [Key]
        [Column("card_id")]
        public int CardId { get; set; }
        [Column("last_digit")]
        public int LastDigit { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("company_id")]
        public int CompanyId { get; set; }

  

    }
}
