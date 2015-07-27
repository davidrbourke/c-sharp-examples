using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.TemplatePattern
{
    public class Coffee : BeverageTemplate
    {
        public override void Brew()
        {
            outputs.AppendLine("Add in coffee");
        }

        public override void AddCondiments()
        {
            if(Hook())
            {
                outputs.AppendLine("Add in sugar and Milk");
            }
        }

        public override bool Hook()
        {
            return true;
        }
    }
}
