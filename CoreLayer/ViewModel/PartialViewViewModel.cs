using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModel
{
    public class InsertServicePartialViewModel
    {
        public int ServiceId { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string FullName { get; set; }

        [DisplayName("شماره تلفن همراه")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string NumberPhone { get; set; }

        [DisplayName("شماره تلفن ثابت")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string NumberHome { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string Addres { get; set; }

        [DisplayName("نقشه")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public double Addres_X { get; set; }

        public double Addres_Y { get; set; }

    }

    public class InsertProductPartialViewmodel
    {
        public int IdProduct { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string FullName { get; set; }

        [DisplayName("شماره تلفن همراه")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string NumberPhone { get; set; }

        [DisplayName("شماره تلفن ثابت")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string NumberHome { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(700, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر برای {0} مجاز نیست.")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر برای {0} مجاز نیست.")]
        public string Addres { get; set; }

        [DisplayName("نقشه")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public double Addres_X { get; set; }

        public double Addres_Y { get; set; }
    }
}
