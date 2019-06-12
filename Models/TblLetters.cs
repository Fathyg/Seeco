using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblLetters
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateReceived { get; set; }
        public string IssuedBy { get; set; }
        public string DirectedTo { get; set; }
        public string Subject { get; set; }
        public string FilePath { get; set; }
        public string Descriptiopn { get; set; }

        public virtual TblProjects Project { get; set; }
    }
}
