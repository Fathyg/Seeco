using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seeco
{
    public class tblConsultant
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="الاسم")]
        public string Name { get; set; }
        [Display(Name = "العنوان")]
        public string Address { get; set; }
        [Display(Name = "تليفون")]
        public string Phones { get; set; }
        [Display(Name = "فاكس")]
        public string Faxes { get; set; }
        [Display(Name = "الرئيس التنفيذى")]
        public string Ceo { get; set; }
        [Display(Name = "المؤسس")]

        public string Cofounder { get; set; }
        [Display(Name = "الايميل")]

        public string Email { get; set; }
        [Display(Name = "موقع الويب")]

        public string WebSite { get; set; }
        [Display(Name = "ملاحظات")]

        public string Notes { get; set; }

    }
}
