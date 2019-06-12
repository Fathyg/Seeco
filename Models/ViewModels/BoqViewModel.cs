using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seeco.Models.ViewModels
{
    public class BoqViewModel
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string Unit { get; set; }
        public int? Qty { get; set; }
        public decimal? Uprice { get; set; }
        public string Notes { get; set; }

        public virtual TblItems Item { get; set; }

        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public string ItemType { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
