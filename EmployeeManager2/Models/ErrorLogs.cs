using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Models
{
    public class ErrorLogs
    {
        [Key]
        public int Id { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
