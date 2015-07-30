using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.IteratorPattern
{
    /// <summary>
    /// This is one of our Aggregate classes, it implement IEnumerable so we 
    /// have the GetEnumerator method.
    /// </summary>
    public class DinnerMenu : IEnumerable<MenuItem>
    {
        private MenuItem[] menuItems;

        public DinnerMenu()
        {
            menuItems = new MenuItem[2]
            {
                new MenuItem
                {
                    Name = "Roast Dinner",
                    Description = "Beef, Chicken, Turkey, Vegetables and Sauce",
                    IsVegeterian = false,
                    Price = 9.99M
                },
                new MenuItem
                {
                    Name = "Chips and Salad",
                    Description = "Fried chips and fresh salad",
                    IsVegeterian = true,
                    Price = 4.99M
                },
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return menuItems.GetEnumerator();
        }

        /// <summary>
        /// Here were are going to use the new DinnerMenuIterator which will
        /// return an interator (IEnumerator in C#) which defines how the MenuItems list is iterated.
        /// </summary>
        /// <returns></returns>
        IEnumerator<MenuItem> IEnumerable<MenuItem>.GetEnumerator()
        {
            return new DinnerMenuIterator(menuItems);
        }
    }
}
