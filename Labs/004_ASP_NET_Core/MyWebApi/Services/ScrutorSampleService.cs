using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace MyWebApi.Services
{
    public class ScrutorGenericSampleServiceA : IScrutorGenericSampleService<string>
    {
        public string Test()
        {
            return "test hahah";
        }
    }

    public class ScrutorGenericSampleServiceB : IScrutorGenericSampleService<int>
    {
        public int Test()
        {
            return 0;
        }
    }
    public class ScrutorSampleService: IScrutorSampleService
    {
        public string Test()
        {
            return "ABCD";
        }
    }
}
