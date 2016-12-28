using MVCCalculator.Models;
using MVCCalculator.Other;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;

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

        public ViewResult Clear()
        {
            Calculator model = GetModel();
            model.Display = "alla";
            return View("Index", model);
        }


        public ViewResult TakeNumber(string val)
        {
            Calculator model = GetModel();
            if (val.Equals("0"))
                if (model.Display.StartsWith("0"))
                    return View("Index", model);
            if (model.Start)
            {
                model.Display = "";
                model.Start = false;
            }

            model.Display += val;

            return View("Index", model);
        }

        public ViewResult TakeOperator(string op)
        {
            Calculator model = GetModel();

            if (model.Display.Equals(""))
                return View("Index", model);
            if (!model.Operator.Equals(""))
            {
                model.Display = Calculate(model.CurrVal, Decimal.Parse(model.Display), model.Operator);
                model.CurrVal = Decimal.Parse(model.Display);
                model.Operator = op;
                model.Start = true;
            }
            if (!op.Equals("="))
            {
                model.Operator = op;
                model.CurrVal = Decimal.Parse(model.Display);
                model.Display = "";
            }
            else
            {
                model.CurrVal = Decimal.Parse(model.Display);
                if (model.Operator.Equals(""))
                    return View("Index", model);
                model.Display = Calculate(model.CurrVal, decimal.Parse(model.Display), model.Operator);
                model.Operator = "";
                model.Start = true;
            }


            return View("Index", model);
        }

        public ViewResult Sqrt()
        {
            Calculator model = GetModel();

            if (!model.Operator.Equals(""))
            {
                double secondVal = double.Parse(model.Display);
                double result;
                if (!model.Operator.Equals("="))
                    result = double.Parse(Calculate(model.CurrVal, (decimal)secondVal, model.Operator));
                else
                    result = secondVal;
                if (result < 0)
                {
                    BlockLayout();
                    return View("Index", model);
                }
                model.Display = ((decimal)Math.Sqrt(result)).ToString();
                model.Operator = "";
                model.Start = true;
                return View("Index", model);
            }
            model.CurrVal = decimal.Parse(model.Display);

            if (model.CurrVal < 0)
            {
                BlockLayout();
            }
            else
                model.Display = (Math.Sqrt((double)model.CurrVal)).ToString();


            return View("Index", model);
        }

        public ViewResult TakeDot()
        {
            Calculator model = GetModel();
            if (model.Display.Contains('.'))
                return View("Index", model);
            model.Display += '.';
            model.Start = false;
            return View("Index", model);
        }

        public ViewResult Percent()
        {
            Calculator model = GetModel();
            decimal SecondVal = decimal.Parse(model.Display) / 100;
            if (model.Operator.Equals(""))
            {
                model.Display = (decimal.Parse(model.Display) / 100).ToString();
                return View("Index", model);
            }
            if (model.Operator.Equals("+") || model.Operator.Equals("-"))
                SecondVal = decimal.Parse(model.Display) / 100 * model.CurrVal;
            model.Display = Calculate(model.CurrVal, SecondVal, model.Operator);
            model.Operator = "";
            model.Start = true;
            return View("Index", model);
        }

        public ViewResult ChangeSign()
        {
            Calculator model = GetModel();
            decimal currVal = Decimal.Parse(model.Display);
            model.Display = (-currVal).ToString();
            return View("Index", model);
        }
        #region private members

        /// <summary>
        /// Returns session model, initializes new if not available
        /// </summary>
        /// <returns></returns>
        private Calculator GetModel()
        {
            var model = stateManager.Load("model");
            if (model == null)
            {
                model = new Calculator();
                stateManager.Save("model", model);
            }
            return model;
        }
        #endregion private members
    }
}