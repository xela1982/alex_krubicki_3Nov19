using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace alex_krubicki_3Nov19.Repositories.Entities
{
    public class Bank
    {
        [Column("payment")] //
        public double Payment { get; set; }
        [ForeignKey("CardId")]
        [Column("card_id")]
        public int CardId { get; set; }
        [Column("payment_date")]
        public DateTime PaymentDate  { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }

    }
    
}
