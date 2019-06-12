using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblTechProposals
    {
        public int Id { get; set; }
        public int? SubItemId { get; set; }
        public DateTime? Date { get; set; }
        public int? ConsultantTeamId { get; set; }
        public int? ContractorTeamId { get; set; }
        public string FilePath { get; set; }
        public string Provider { get; set; }
        public string Decesions { get; set; }

        public virtual TblConsultantsTeams ConsultantTeam { get; set; }
        public virtual TblContractorsTeams ContractorTeam { get; set; }
        public virtual TblSubItemsSpecifications SubItem { get; set; }
    }
}
