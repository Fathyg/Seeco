using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblProjects
    {
        public TblProjects()
        {
            TblClientsTeams = new HashSet<TblClientsTeams>();
            TblConsultantsTeams = new HashSet<TblConsultantsTeams>();
            TblContractorsTeams = new HashSet<TblContractorsTeams>();
            TblInvoicesContractor = new HashSet<TblInvoicesContractor>();
            TblItems = new HashSet<TblItems>();
            TblLetters = new HashSet<TblLetters>();
            TblSchedules = new HashSet<TblSchedules>();
            TblUsers = new HashSet<TblUsers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ContractId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? Period { get; set; }
        public string Notes { get; set; }

        public virtual TblContracts Contract { get; set; }
        public virtual ICollection<TblClientsTeams> TblClientsTeams { get; set; }
        public virtual ICollection<TblConsultantsTeams> TblConsultantsTeams { get; set; }
        public virtual ICollection<TblContractorsTeams> TblContractorsTeams { get; set; }
        public virtual ICollection<TblInvoicesContractor> TblInvoicesContractor { get; set; }
        public virtual ICollection<TblItems> TblItems { get; set; }
        public virtual ICollection<TblLetters> TblLetters { get; set; }
        public virtual ICollection<TblSchedules> TblSchedules { get; set; }
        public virtual ICollection<TblUsers> TblUsers { get; set; }
    }
}
