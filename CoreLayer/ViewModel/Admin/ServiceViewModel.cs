using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Table;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.ViewModel.Admin
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }
        [DisplayName("موضوع")]
        [MinLength(3, ErrorMessage = "وارد کردن کمتر از {1} کارکتر مجاز نیست.")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MaxLength(100, ErrorMessage = "وارد کردن بیشتر از {1} کارکتر مجاز نیست.")]
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر مجاز نیست.")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Descripton { get; set; }
        [DisplayName("نمایش در صفحه اصلی")]
        public bool OkGallery { get; set; }

        [DisplayName("عکس اصلی سرویس")]
        public IFormFile? MainImage { get; set; }

        [DisplayName("عکس های گالری")]
        public List<IFormFile>? Images { get; set; }
    }

    public class InsertServiceViewModel
    {
        public ServiceTable Service { get; set; }
        public InsertServiceTable InsertService { get; set; }
    }
}
