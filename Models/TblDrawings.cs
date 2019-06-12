using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblDrawings
    {
        public TblDrawings()
        {
            TblDrawingDet = new HashSet<TblDrawingDet>();
        }

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string DrawingName { get; set; }
        public string DrawingType { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime? DateReceived { get; set; }
        public string DrawBy { get; set; }
        public string Receiver { get; set; }
        public string FilePath { get; set; }
        public string Notes { get; set; }

        public virtual TblItems Item { get; set; }
        public virtual ICollection<TblDrawingDet> TblDrawingDet { get; set; }
    }
}
