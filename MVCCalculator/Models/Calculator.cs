using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
putty -L 1433:base.ii.pw.edu.pl:1433 <twoj_email>@galera.ii.pw.edu.pl
i bd jest widoczna pod 127.0.0.1:1443
*/

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
