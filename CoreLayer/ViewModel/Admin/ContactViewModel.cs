using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModel.Admin
{
    public class ContactViewModel
    {
        [DisplayName("شماره تماس")]
        [MinLength(8, ErrorMessage = "وارد کردن کمتر از {1} کارکتر مجاز نیست.")]
        [MaxLength(12, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر مجاز نیست.")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Numberphone { get; set; }
        [DisplayName("زمان پاسخ گویی")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string ResponseTime { get; set; }
        [DisplayName("آدرس")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Addres { get; set; }
        
        public double Addres_X { get; set; }
        
        public double Addres_Y { get; set; }

    }
}
