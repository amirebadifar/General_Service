using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class InsertProductTable
    {
        [Key]
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string FullName { get; set; }
        public string numberPhone { get; set; }
        public string NumberHome { get; set; }
        public DateTime CreateTime { get; set; }
        public string Addres { get; set; }
        public double Addres_X { get; set; }
        public double Addres_Y { get; set; }
        public bool IsDelete { get; set; }
    }
}
