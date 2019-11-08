

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using alex_krubicki_3Nov19.Repositories.Services;
using alex_krubicki_3Nov19.Interfaces;
using alex_krubicki_3Nov19.Model;
using alex_krubicki_3Nov19.Repositories.Entities;
using Repositories.Models;

namespace alex_krubicki_3Nov19.Services
{
    public class TakeAwayService : ITakeAway
    {
        private readonly IRepositories _repositoryService;
        public TakeAwayService(IRepositories repositoryService)
        {
            _repositoryService = repositoryService;
        }
        public async Task<(bool, List<Company>)> GetCompanies()
        {

            try
            {
                var output = await _repositoryService.GetCompanies();
                return (true, output);
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
                var output = await _repositoryService.GetReportByParam(companyId, startDate, endDate);
                return (true, output);
            }
            catch (Exception ex)
            {
                //TODO LOG Exception
                return (false, null);
            }


        }

    }
}
