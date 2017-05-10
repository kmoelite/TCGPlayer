using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCGPlayerKevinMohan.Models
{
    [Table("Cards.Set")]
    public class Set
    {
        [Key]
        [Required, MaxLength(1, ErrorMessage = "SetId can not be greater than the number of sets.")]
        public int SetId { get; set; }
        public string SetName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}