using alex_krubicki_3Nov19.Entities;
using alex_krubicki_3Nov19.Interfaces;
using alex_krubicki_3Nov19.Repositories;
using alex_krubicki_3Nov19.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Services
{
    public class TakeAwayService : ITakeAway
    {
        private readonly IRepository _repositoryService;
        public TakeAwayService(IRepository repositoryService)
        {
            _repositoryService = repositoryService;
        }
        public async Task<(bool, List<Company>)> GetCompanies()
        {

            try
            {
                var getCompanies = await _repositoryService.GetCompanies();
                return (true, getCompanies);
            }
            catch (Exception ex)
            {
                //TODO LOG Exception
                return (false, null);
            }

        }
        public async Task<(bool, List<Report>)> GetReportByParam(int companyId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var getReportByParam = await _repositoryService.GetReportByParam(companyId, startDate, endDate);
                return (true, getReportByParam);
            }
            catch (Exception ex)
            {
                //TODO LOG Exception
                return (false, null);
            }


        }

    }
}
