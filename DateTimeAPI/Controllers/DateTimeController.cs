using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DateTimeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateTimeController : ControllerBase
    {
        int id = 1;

        private readonly ILogger<DateTimeController> _logger;

        public DateTimeController(ILogger<DateTimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public string Get()
        {
            return GetCurrentDate();
            
        }

        private string GetCurrentDate()
        {
         
            DateTime currentDate = DateTime.Now;

            string dateToFormat = currentDate.ToString("F", new CultureInfo("RO-ro"));

            string[] currentDateSplit = dateToFormat.Split(",")[1].Split(" ");
            string date = $"{currentDateSplit[1]} {CapitalizeMonth(currentDateSplit[2])} {currentDateSplit[3]}";
            string hour = currentDateSplit[4];
            string correctDate = $"{id} - Data: {date} Ora: {hour}";

            id++;
           
            return correctDate;

          
        }

        private static string CapitalizeMonth(string month)
        {
            return char.ToUpper(month[0]) + month.Substring(1);
        }
    }
}
