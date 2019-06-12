using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblSchedules
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string ScheduleNo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? SchStartDate { get; set; }
        public DateTime? SchEndDate { get; set; }
        public int? Period { get; set; }
        public string Decision { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }

        public virtual TblProjects Project { get; set; }
    }
}
