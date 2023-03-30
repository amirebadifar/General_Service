using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("شماره تلفن")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(11, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست")]
        [MinLength(8, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست")]
        public string NumberPhone { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(20, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست")]
        [MinLength(6, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست")]
        public string Password { get; set; }

        [DisplayName("لاگین بماند؟")]
        public bool IsLogin { get; set; }

        public string? BackPage { get; set; }
    }
    }
