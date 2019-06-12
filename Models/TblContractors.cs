using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblContractors
    {
        public TblContractors()
        {
            TblContractorsTeams = new HashSet<TblContractorsTeams>();
            TblContracts = new HashSet<TblContracts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Faxes { get; set; }
        public string Ceo { get; set; }
        public string Parent { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<TblContractorsTeams> TblContractorsTeams { get; set; }
        public virtual ICollection<TblContracts> TblContracts { get; set; }
    }
}
