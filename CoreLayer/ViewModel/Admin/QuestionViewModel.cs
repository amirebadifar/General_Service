using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModel.Admin
{
    public class AddQuestionViewModel
    {
        [DisplayName("سوال")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(150, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(2, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string Question { get; set; }

        [DisplayName("پاسخ")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(150, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(2, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string Response { get; set; }
    }
}
