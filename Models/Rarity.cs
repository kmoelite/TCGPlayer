using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCGPlayerKevinMohan.Models
{
    [Table("Cards.Set")]
    public class Rarity
    {
        [Key]
        public int RarityId { get; set; }
        public string RarityName { get; set; }
    }
}