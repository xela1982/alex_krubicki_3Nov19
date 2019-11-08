using alex_krubicki_3Nov19.Repositories.Entities;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Repositories.Services
{
    public interface IRepositories
    {
        Task<List<Report>> GetReportByParam(int companyId, DateTime startDate, DateTime endDate);
        Task<List<Company>> GetCompanies();

    }
}
