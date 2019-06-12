using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblConsultants
    {
        public TblConsultants()
        {
            TblConsultantsTeams = new HashSet<TblConsultantsTeams>();
            TblContractsConsultantContractor = new HashSet<TblContracts>();
            TblContractsConsultantDesign = new HashSet<TblContracts>();
            TblContractsConsultantSupervision = new HashSet<TblContracts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Faxes { get; set; }
        public string Ceo { get; set; }
        public string Cofounder { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<TblConsultantsTeams> TblConsultantsTeams { get; set; }
        public virtual ICollection<TblContracts> TblContractsConsultantContractor { get; set; }
        public virtual ICollection<TblContracts> TblContractsConsultantDesign { get; set; }
        public virtual ICollection<TblContracts> TblContractsConsultantSupervision { get; set; }
    }
}
