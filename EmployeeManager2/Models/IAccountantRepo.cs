using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Models
{
    public interface IAccountantRepo
    {
        Task<Accountants> Add(Accountants accountant);
        Task<List<Accountants>> GetAccountants();
        Task<Accountants> UpdateAccountant(Accountants accountant);
        Task<Accountants> GetAccountant(int id);
        Task DeleteAccountant(int id);
    }
}
