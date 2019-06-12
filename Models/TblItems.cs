using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seeco.Models
{
    public partial class TblItems
    {
        public TblItems()
        {
            TblBoq = new HashSet<TblBoq>();
            TblDrawings = new HashSet<TblDrawings>();
            TblSubItemsSpecifications = new HashSet<TblSubItemsSpecifications>();
        }
        [Key]
        public int Id { get; set; }
        [Display(Name ="Project")]
        [Required]
        public int? ProjectId { get; set; }
        [Display(Name ="Item Name")]
        [Required]
        public string ItemName { get; set; }
        [Display(Name ="Item Number")]
        [Required]
        public string ItemNo { get; set; }
        [Display(Name ="Type")]
        public string ItemType { get; set; }
        public string Description { get; set; }

        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblBoq> TblBoq { get; set; }
        public virtual ICollection<TblDrawings> TblDrawings { get; set; }
        public virtual ICollection<TblSubItemsSpecifications> TblSubItemsSpecifications { get; set; }
    }
}
