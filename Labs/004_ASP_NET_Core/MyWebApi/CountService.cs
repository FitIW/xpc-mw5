using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi
{
    public class CountService
    {
        private static int count = 0;
        public CountService()
        {
            count++;
        }

        public int Count => count;
    }
}
