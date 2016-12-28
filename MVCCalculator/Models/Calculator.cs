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
        private string display;
        private bool start;
        public Calculator()
        {
            CurrVal = 0;
            display = "";
            Operator = "";
        }
        public string Display 
        {
            get {  return display; }

            set {
                decimal d;
                if (display.Equals("") || display.Contains("ERR") || display.StartsWith("."))
                {
                    display = value;
                    return;
                }
                if(!decimal.TryParse(value, out d))
                {
                    display = value;
                    return;
                }
                if (d == -decimal.Parse(display))
                {
                    display = value;
                    return;
                }
                if (value.Length > 12 && decimal.TryParse(value, out d))
                    display = value.Substring(0, 12);
                else display = value; }
        }
        public decimal CurrVal { get; set; }
        public string Operator { get; set; }

        public bool Start {
            get { return start; }
            set { start = value; }
        }

        public bool ButtonsEnabled;

    }
}
