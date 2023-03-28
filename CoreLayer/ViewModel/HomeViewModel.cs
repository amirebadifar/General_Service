using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Table;


namespace CoreLayer.ViewModel
{
    public class IndexViewModel
    {
        public AboutTable About { get; set; }
        public List<ServiceTable> Service { get; set; }
        public List<ServiceTable> GalleryService { get; set; }
        public List<WorkSampleTable> WorkSample { get; set; }
        public List<QuestionsTable> Questions { get; set; }
        public List<ProductTable> Product { get; set; }
    }
}
