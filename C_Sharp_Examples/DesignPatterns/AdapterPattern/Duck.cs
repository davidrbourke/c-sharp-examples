using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.DesignPatterns.AdapterPattern
{
    public class Duck : IDuck
    {
        public string Fly()
        {
            return "Duck Flying";
        }

        public string Quack()
        {
            return "Duck Quacking";
        }
    }
}
