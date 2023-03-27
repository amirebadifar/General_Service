﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class ProductTable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
        public int Price { get; set; }
        public string Propertys { get; set; }
    }
}
