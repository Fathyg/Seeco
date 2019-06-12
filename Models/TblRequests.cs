using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblRequests
    {
        public int Id { get; set; }
        public int? SubItemId { get; set; }
        public DateTime? Date { get; set; }
        public string Subject { get; set; }
        public int? ContractorTeamId { get; set; }
        public int? ConsultantTeamId { get; set; }
        public string FilePath { get; set; }
        public string Decisions { get; set; }

        public virtual TblConsultantsTeams ConsultantTeam { get; set; }
        public virtual TblContractorsTeams ContractorTeam { get; set; }
        public virtual TblSubItemsSpecifications SubItem { get; set; }
    }
}
