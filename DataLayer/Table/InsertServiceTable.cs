using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class InsertServiceTable
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string FullName { get; set; }
        public string NumberPhone { get; set; }
        public string NumberHome { get; set; }
        public string Addres { get; set; }
        public double Addres_X { get; set; }
        public double Addres_Y { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
