using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCalculator.Models
{
    public class Calculator
    {
        public Calculator()
        {
            CurrVal = 0;
            Display = "";
        }
        public string Display { get; set; }
        public decimal CurrVal { get; set; }
        public string Operator { get; set; }
        public string Color { get; set; }
    }
}