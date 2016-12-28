using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCalculator.Other
{
    public interface IStateManager<T>
    {
        void Save(string name, T state);
        T Load(string name);
    }
}
