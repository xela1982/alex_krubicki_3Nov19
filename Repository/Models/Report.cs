using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Models
{
    public class Report
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int Last4Digits { get; set; }
        public double Payment { get; set; }
    }
}
