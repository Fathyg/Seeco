using System;
using System.Collections.Generic;

namespace Seeco.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblUserRole = new HashSet<TblUserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? ProjectId { get; set; }

        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblUserRole> TblUserRole { get; set; }
    }
}
