using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblClientsTeams
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? ProjectId { get; set; }
        public string ResponsibleName { get; set; }
        public string Position { get; set; }
        public DateTime? StartDate { get; set; }
        public string IdNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Sector { get; set; }
        public string Notes { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblProjects Project { get; set; }
    }
}
