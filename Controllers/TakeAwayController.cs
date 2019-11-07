using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using alex_krubicki_3Nov19.Model;
using alex_krubicki_3Nov19.Interfaces;
using alex_krubicki_3Nov19.Repositories.Entities;

namespace alex_krubicki_3Nov19.Controllers
{
    
    [ApiController]
    public class TakeAwayController : ControllerBase
    {

        private readonly ITakeAway _takeAwayService;
        public TakeAwayController(ITakeAway takeAwayService)
        {
            _takeAwayService = takeAwayService;
        }
        [Route("/")]
        [Route("/[action]")]
        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            (bool success, List<Company> output) = await _takeAwayService.GetCompanies();
            if (success)
                return output;
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("/[action]")]
        [HttpGet]
        public async Task<ActionResult<List<Report>>> GetReportByParam([FromQuery] QueryParameters request)
        {
            (bool success, List<Report> output) = await _takeAwayService.GetReportByParam(request.CompanyId, request.StartDate, request.EndDate);
            if (success)
                return output;
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}