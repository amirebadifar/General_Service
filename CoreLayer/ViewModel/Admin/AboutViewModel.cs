using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreLayer.ViewModel.Admin
{
    public class AboutViewModel
    {
        [DisplayName("موضوع")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "وارد کردن فیلد {0} اجباری هست")]
        public string Description { get; set; }
        [DisplayName("عکس")]
        public IFormFile? Imege { get; set; }
    }
}
