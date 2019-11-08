using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class User
    {

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }


    }
}
