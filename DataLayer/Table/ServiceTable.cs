using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class ServiceTable
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public bool OkGallery { get; set; }
    }
}
