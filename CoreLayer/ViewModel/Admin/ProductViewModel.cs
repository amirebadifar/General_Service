using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModel.Admin
{
    public class ProductViewModel
    {
        public int? ID { get; set; }
        [DisplayName("نام کالا")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MinLength(3, ErrorMessage = "وارد کردن کمتر از {1} کارکتر مجاز نیست.")]
        [MaxLength(100, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر مجاز نیست.")]
        public string Name { get; set; }
        [DisplayName("دسته دوم")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public bool IsNew { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public int Price { get; set; }
        [DisplayName("ویژگی ها")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Propertys { get; set; }
    }
}
