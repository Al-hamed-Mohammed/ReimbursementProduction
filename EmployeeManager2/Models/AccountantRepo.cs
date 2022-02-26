using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Models
{
    public class AccountantRepo : IAccountantRepo
    {
        private readonly AppDbContext context;

        public AccountantRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Accountants> Add(List<Accountants> accountant)
        {
            foreach(Accountants a in accountant)
            {
                await context.Accountants.AddAsync(a);
            }
            await context.SaveChangesAsync();
            return accountant[0];
        }

        public async Task DeleteAccountant(int id)
        {
            var result = await GetAccountant(id);
            if(result !=null)
            {
                context.Remove(result);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Accountants> GetAccountant(int id)
        {
            return await context.Accountants.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Accountants>> GetAccountants()
        {
            return await context.Accountants.ToListAsync();
        }

        public async Task<Accountants> UpdateAccountant(Accountants accountant)
        {
            var a = await GetAccountant(accountant.Id);
            a.Category = accountant.Category;
            a.Credit = accountant.Credit;
            a.Date = accountant.Date;
            a.Debit = accountant.Debit;
            a.Description = accountant.Description;
            a.Transaction = accountant.Transaction;            
            await context.SaveChangesAsync();
            return a;
        }
    }
}
