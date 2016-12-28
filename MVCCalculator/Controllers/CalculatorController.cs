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

        public ViewResult Clear()
        {
            Calculator model = GetModel();
            model.Display = "alla";
            return View("Index", model);
        }


        public ViewResult TakeNumber(string val)
        {
            Calculator model = GetModel();
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