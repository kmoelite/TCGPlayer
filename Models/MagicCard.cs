using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace TCGPlayerKevinMohan.Models
{
    [Table("Cards.Card")]
    public class MagicCard
    {
        [Key]
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string CardText { get; set; }
        public string Number { get; set; }
        public int SetId { get; set; }
        public int RarityId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string AccessPath { get; set; }
    }
}