using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seeco.Models
{
    public partial class TblBoq
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Item")]
        [Required]
        public int? ItemId { get; set; }
        [Display(Name ="Unit")]
        [Required]
        public string Unit { get; set; }
        
        public int? Qty { get; set; }
        [Display(Name ="Unit Price")]
        public decimal? Uprice { get; set; }
        public string Notes { get; set; }

        public virtual TblItems Item { get; set; }
    }
}
