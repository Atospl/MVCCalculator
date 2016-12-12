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
        protected IStateManager<CalcModel> stateManager = new SessionStateManager<CalcModel>();
        public void setStateManager(IStateManager<CalcModel> manager)
        {
            stateManager = manager;
        }

        // GET: Calculator
        public ViewResult Index()
        {
            return View();
        }
    }
}