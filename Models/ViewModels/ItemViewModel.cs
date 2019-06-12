using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seeco.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public TblItems Items { get; set; }
      
    }
}
