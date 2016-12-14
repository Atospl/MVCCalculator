using MVCCalculator.Models;
using MVCCalculator.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        protected IStateManager<Calculator> stateManager = new SessionStateManager<Calculator>();
        private Calculator calculator = new Calculator();

        public void setStateManager(IStateManager<Calculator> manager)
        {
            stateManager = manager;

            
        }

        // GET: Calculator
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Akcja(string s)
        {
            Console.WriteLine("Klikniety chuj");
    //        calculator.CurrVal += 1;
            return View();
        }

        //public void TakeNumber(string number)
        //{
        //    Console.WriteLine(number);
        //    if (number.Equals("0"))
        //        if (Display.StartsWith("0"))
        //            return;
        //    if (Start)
        //    {
        //        Display = "";
        //        Start = false;
        //    }

        //    Display += number;
        //}

        //public void TakeOperator(string op)
        //{
        //    if (Display.Equals(""))
        //        return;
        //    if (!Operator.Equals(""))
        //    {
        //        Display = Calculate(CurrVal, Decimal.Parse(Display), Operator);
        //        CurrVal = Decimal.Parse(Display);
        //        Operator = op;
        //        Start = true;
        //    }
        //    if (!op.Equals("="))
        //    {
        //        Operator = op;
        //        CurrVal = Decimal.Parse(Display);
        //        Display = "";
        //    }
        //    else
        //    {
        //        CurrVal = Decimal.Parse(Display);
        //        if (Operator.Equals(""))
        //            return;
        //        Display = Calculate(CurrVal, decimal.Parse(Display), Operator);
        //        Operator = "";
        //        Start = true;
        //    }
        //}

        //public virtual void TakeClear(string str)
        //{
        //    Console.WriteLine(str);
        //    this.Display = "";
        //    this.CurrVal = 0;
        //    this.ButtonsEnabled = true;
        //}

        //public virtual void TakeDot(string str)
        //{
        //    Console.WriteLine(str);
        //    if (Display.Contains('.'))
        //        return;
        //    Display += '.';
        //    Start = false;
        //}

        //public void TakeSign(string str)
        //{
        //    decimal currVal = Decimal.Parse(Display);
        //    Display = (-currVal).ToString();
        //}

        //public void TakeSqrt(string str)
        //{
        //    if (!Operator.Equals(""))
        //    {
        //        double secondVal = double.Parse(Display);
        //        double result;
        //        if (!Operator.Equals("="))
        //            result = double.Parse(Calculate(CurrVal, (decimal)secondVal, Operator));
        //        else
        //            result = secondVal;
        //        if (result < 0)
        //        {
        //            BlockLayout();
        //            return;
        //        }
        //        Display = ((decimal)Math.Sqrt(result)).ToString();
        //        Operator = "";
        //        Start = true;
        //        return;
        //    }
        //    CurrVal = decimal.Parse(Display);

        //    if (CurrVal < 0)
        //    {
        //        BlockLayout();
        //    }
        //    else
        //        Display = (Math.Sqrt((double)CurrVal)).ToString();
        //}

        //public void TakePercent(string op)
        //{
        //    decimal SecondVal = decimal.Parse(Display) / 100;
        //    if (Operator.Equals(""))
        //    {
        //        Display = (decimal.Parse(Display) / 100).ToString();
        //        return;
        //    }
        //    if (Operator.Equals("+") || Operator.Equals("-"))
        //        SecondVal = decimal.Parse(Display) / 100 * CurrVal;
        //    Display = Calculate(CurrVal, SecondVal, Operator);
        //    Operator = "";
        //    Start = true;
        //}

        //public string Calculate(decimal FirstVal, decimal SecondVal, string op)
        //{
        //    string res = "0.0";

        //    switch (op)
        //    {
        //        case "+":

        //            res = (FirstVal + SecondVal).ToString();
        //            break;
        //        case "-":
        //            res = (FirstVal - SecondVal).ToString();
        //            break;
        //        case "*":
        //            res = (FirstVal * SecondVal).ToString();
        //            break;
        //        case "/":
        //            if (SecondVal == 0.0M)
        //            {
        //                BlockLayout();
        //                break;
        //            }
        //            res = (FirstVal / SecondVal).ToString();
        //            break;
        //        case "=":
        //            res = (FirstVal).ToString();
        //            break;
        //    }
        //    if (res != "0.0")
        //        log.Info(FirstVal + op + SecondVal + "=" + res);
        //    return res;
        //}

        //public virtual void BlockLayout()
        //{
        //    Display = "ERR";
        //    ButtonsEnabled = false;
        //}

    }
}