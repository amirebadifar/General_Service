using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.ViewModel.Admin
{
    public class WorkSampleViewModel
    {
        public int? Id { get; set; }
        [DisplayName("موضوع")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        [MinLength(5, ErrorMessage = "وارد کردن کمتر از {1} کارکتر مجاز نیست.")]
        public string Title { get; set; }

        [DisplayName("تاریخ ایجاد")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public DateTime CreateTime { get; set; }

        [DisplayName("عکس اصلی نمونه کار")]
        public IFormFile? MainImage { get; set; }

        [DisplayName("عکس های گالری")]
        public List<IFormFile>? Images { get; set; }
    }
}
