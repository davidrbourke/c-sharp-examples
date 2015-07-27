using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.TemplatePattern
{
    public class Tea : BeverageTemplate
    {
        public override void Brew()
        {
            outputs.AppendLine("Add in tea bag and soak, remove tea bag");
        }

        public override void AddCondiments()
        {
            outputs.AppendLine("Squeeze in Lemon juice");
        }
    }
}
