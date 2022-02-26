using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Models
{
    public class Accountants
    {
        [Key]
        public int Id { get; set; }        
        public DateTime? Date { get; set; }        
        public string Transaction { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
    }
}
