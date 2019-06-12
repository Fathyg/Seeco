using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblSubItemsSpecifications
    {
        public TblSubItemsSpecifications()
        {
            TblRequests = new HashSet<TblRequests>();
            TblTechProposals = new HashSet<TblTechProposals>();
        }

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string SubItemName { get; set; }
        public string Spcifications { get; set; }
        public string Notes { get; set; }

        public virtual TblItems Item { get; set; }
        public virtual ICollection<TblRequests> TblRequests { get; set; }
        public virtual ICollection<TblTechProposals> TblTechProposals { get; set; }
    }
}
