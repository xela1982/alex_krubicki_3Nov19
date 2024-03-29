﻿
using alex_krubicki_3Nov19.Repositories.Entities;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Interfaces
{
    public interface ITakeAway
    {
        Task<(bool,List<Report>)> GetReportByParam(int companyId, DateTime startDate, DateTime endDate);
        Task<(bool,List<Company>)> GetCompanies();
    }
}
