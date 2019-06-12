using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblConsultantsTeams
    {
        public TblConsultantsTeams()
        {
            TblRequests = new HashSet<TblRequests>();
            TblTechProposals = new HashSet<TblTechProposals>();
        }

        public int Id { get; set; }
        public int? ConsultantId { get; set; }
        public int? ProjectId { get; set; }
        public string ResponsibleName { get; set; }
        public string Position { get; set; }
        public DateTime? StartDate { get; set; }
        public string IdNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Sector { get; set; }
        public string Notes { get; set; }

        public virtual TblConsultants Consultant { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblRequests> TblRequests { get; set; }
        public virtual ICollection<TblTechProposals> TblTechProposals { get; set; }
    }
}
