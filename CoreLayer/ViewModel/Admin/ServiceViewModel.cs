using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Table;

namespace CoreLayer.ViewModel.Admin
{
    public class InsertServiceViewModel
    {
        public ServiceTable Service { get; set; }
        public InsertServiceTable InsertService { get; set; }
    }
}
