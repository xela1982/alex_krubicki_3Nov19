using alex_krubicki_3Nov19.Entities;
using alex_krubicki_3Nov19.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Interfaces
{
    public interface IRepository
    {
        Task<List<Report>> GetReportByParam(int companyId, DateTime startDate, DateTime endDate);
        Task<List<Company>> GetCompanies();
        
    }
}
