using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblContracts
    {
        public TblContracts()
        {
            TblProjects = new HashSet<TblProjects>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? ContractorId { get; set; }
        public int? ConsultantDesignId { get; set; }
        public int? ConsultantSupervisionId { get; set; }
        public int? ConsultantContractorId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? BaseValue { get; set; }
        public int? Period { get; set; }
        public string Notes { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblConsultants ConsultantContractor { get; set; }
        public virtual TblConsultants ConsultantDesign { get; set; }
        public virtual TblConsultants ConsultantSupervision { get; set; }
        public virtual TblContractors Contractor { get; set; }
        public virtual ICollection<TblProjects> TblProjects { get; set; }
    }
}
