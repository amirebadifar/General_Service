using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.ViewModel.Admin
{
    public class AddBrandViewModel
    {
        public IFormFile BrandFile { get; set; }
    }
}
