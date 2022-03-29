using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class Retyping
    {
        public void Run()
        {
            var o = new object();
            dynamic testAAA = "adsas";

            //o = "asdas";
            //o.GetType();

            if (o.GetType() == typeof(int))
            {
                
            }

            //runtime exception
            int? myNumber = (int?) o;

            // possible null if type not match
            int? myNumber2 = o as int?;

            if (myNumber2 == null)
            {
                // work with myNumber2
            }

            if (o is int?)
            {
                int? myNumber3 = (int?)o;
                // work with myNumber2
            }

            if (o is int myNumber4)
            {
                myNumber4 = 55;
                // work with myNumber2
            }

        }
    }
}
