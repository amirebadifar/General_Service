using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class ContactTable
    {
        [Key]
        public int Id { get; set; }
        public string Numberphone { get; set; }
        public string ResponseTime { get; set; }
        public string Addres { get; set; }
        public double Addres_X { get; set; }
        public double Addres_Y { get; set; }
    }
}
