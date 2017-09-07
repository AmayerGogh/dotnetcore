using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleThread
{
    public class SingleClass
    {
        private SingleClass()
        {

        }

        private static object obj = new object();

        private static SingleClass singleClass=null;
        
        public static SingleClass CreateInstance()
        {
            if (singleClass == null)
            {
                lock (obj)
                {
                    if (singleClass == null)
                    {
                        singleClass = new SingleClass();
                    }
                }
            }
            return singleClass;
        }
    }
}
