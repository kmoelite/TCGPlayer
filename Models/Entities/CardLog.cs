//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCGPlayerKevinMohan.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardLog
    {
        public int CardLogId { get; set; }
        public Nullable<int> CardId { get; set; }
        public string UpdatedCardName { get; set; }
        public string UpdatedCardText { get; set; }
        public string UpdatedNumber { get; set; }
        public Nullable<int> UpdatedSetId { get; set; }
        public Nullable<int> UpdatedRarityId { get; set; }
        public Nullable<decimal> UpdatedPrice { get; set; }
        public Nullable<int> UpdatedQuantity { get; set; }
        public string UpdatedAccessPath { get; set; }
        public Nullable<System.DateTime> UpdatedTime { get; set; }
    }
}
