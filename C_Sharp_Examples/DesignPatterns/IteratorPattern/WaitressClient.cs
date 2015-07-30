using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.IteratorPattern
{
    /// <summary>
    /// This is the Client class in the iterator pattern. 
    /// The iterator pattern provides a way to access the elements of the aggregate object
    /// sequentially without exposing its underlying representation.
    /// The aggregate classes are DinnerMenu and PanckageHouseMenu.
    /// </summary>
    public class WaitressClient
    {
        private PancakeHouseMenu packageHouseMenu;
        private DinnerMenu dinnerMenu;

        public WaitressClient(PancakeHouseMenu packageHouseMenu, DinnerMenu dinnerMenu)
        {
            this.packageHouseMenu = packageHouseMenu;
            this.dinnerMenu = dinnerMenu;
        }

        public string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            BuildOutput(sb, packageHouseMenu);
            BuildOutput(sb, dinnerMenu);
            return sb.ToString();
        }

        private void BuildOutput(StringBuilder sb, IEnumerable<MenuItem> menuItems)
        {
            // Because we are using IEnumerable, we don't need two different algorithms here to 
            // interate through the alternative lists...
            foreach(MenuItem item in menuItems)
            {
                sb.AppendLine(string.Format("{0}    {1}    {2}    £{3}", item.Name,
                    item.Description,
                    item.IsVegeterian,
                    item.Price));
            }
        }
    }
}
