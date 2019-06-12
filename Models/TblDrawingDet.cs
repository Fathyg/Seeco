using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblDrawingDet
    {
        public int Id { get; set; }
        public int? DrawingId { get; set; }
        public DateTime? Date { get; set; }
        public string DecisionMaker { get; set; }
        public string Decisions { get; set; }

        public virtual TblDrawings Drawing { get; set; }
    }
}
