using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.DesignPatterns.AdapterPattern
{
    public class TurkeyAdapter : IDuck
    {
        private Turkey _turkey;

        public TurkeyAdapter(Turkey turkey)
        {
            _turkey = turkey;
        }

        public string Fly()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine(_turkey.Flap());
            }
            return sb.ToString();
        }

        public string Quack()
        {
            return _turkey.Goble();
        }
    }
}
