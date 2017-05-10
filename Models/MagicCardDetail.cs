using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCGPlayerKevinMohan.Models
{
    public class MagicCardDetail
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string CardText { get; set; }
        public string Number { get; set; }
        public Set SetInfo { get; set; }
        public Rarity RarityInfo { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string AccessPath { get; set; }
    }
}