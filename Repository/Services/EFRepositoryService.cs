using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alex_krubicki_3Nov19.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace alex_krubicki_3Nov19.Repositories.Services
{
    public class EFRepositoryService : IRepositories
    {
        private TakeAway2Context _context;
        public string ConnectionString;
        public EFRepositoryService(TakeAway2Context context)
        {
            _context = context;

        }
        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<List<Report>> GetReportByParam(int companyId, DateTime startDate, DateTime endDate)
        {

            var result = from bank in _context.Banks
                         join employeesCards in _context.EmployeesCards on bank.CardId equals employeesCards.CardId
                         join user in _context.Users on employeesCards.UserId equals user.UserId
                         join company in _context.Companies on employeesCards.CompanyId equals company.CompanyId
                         where company.CompanyId == companyId
                         group new { bank, employeesCards, user, company } by new { user.UserId, user.FirstName, user.LastName, employeesCards.LastDigit, employeesCards.CardId }
                         into output
                         select new Report
                         {
                             UserId = output.Key.UserId,
                             UserFullName = output.Key.FirstName + " " + output.Key.LastName,
                             Last4Digits = output.Key.LastDigit,
                             Payment = output.Sum(x => x.bank.Payment)
                         };

            return await result.ToListAsync();
            //return await _context.Banks
            //      .Include(obj => obj.Users)
            //     .Include(obj => obj.Companies)
            //      .Include(obj => obj.EmployeesCards)
            //      .Where(obj => obj.Companies.CompanyId == companyId)
            //      .Where(obj => obj.PaymentDate > startDate)
            //      .Where(obj => obj.PaymentDate < endDate)
            //      .GroupBy(s => new { s.Users.UserId, s.Users.FirstName, s.Users.LastName, s.EmployeesCards.LastDigit, s.CardId })
            //      .Select(g => new Report { UserId = g.Key.UserId, UserFullName = g.Key.FirstName + " " + g.Key.LastName, Last4Digits = g.Key.LastDigit, Payment = g.Sum(x => x.Payment) }).ToListAsync();


        }
    }
}
