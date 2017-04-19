using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.CommonFuntion
{
    class Reflector
    {
        public void GetTypes()
        {

            System.Reflection.Assembly assembly = this.GetType().Assembly;
            Type[] typesArray = assembly.GetTypes();
            for (int i = 0; i < typesArray.Length; i++)
            {

            }

        }
    }
}
