using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Table
{
    public class QuestionsTable
    {
        [Key]
        public int Id { get; set; }
        public string Questions { get; set; }
        public string Response { get; set; }
    }
}
