using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IScrutorSampleService
    {
        string Test();
    }

    public interface IScrutorGenericSampleService<T>
    {
        T Test();
    }
}
