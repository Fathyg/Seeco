using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblInvoicesContractor
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? Date { get; set; }
        public decimal? StoresValue { get; set; }
        public decimal? WorksUpToDate { get; set; }
        public decimal? Total { get; set; }
        public decimal? DiscountContractor { get; set; }
        public decimal? TotalAfterDiscountContractor { get; set; }
        public decimal? PreviousInvoices { get; set; }
        public decimal? InvoiceValue { get; set; }
        public decimal? PrePayed { get; set; }
        public decimal? Liability { get; set; }
        public decimal? Net { get; set; }
        public string Notes { get; set; }

        public virtual TblProjects Project { get; set; }
    }
}
