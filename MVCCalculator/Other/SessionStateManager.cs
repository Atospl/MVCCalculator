using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCalculator.Other
{
    public class SessionStateManager<T> : IStateManager<T>
    {
        public void Save(string name, T state)
        {
            HttpContext.Current.Session[name] = state;
        }
        public T Load(string name)
        {
            return (T)HttpContext.Current.Session[name];
        }
    }
}