using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.IteratorPattern
{
    /// <summary>
    /// This is an Aggregate class, it implements IEnumerable to ensure the 
    /// get enumerator method is available BUT we don't need an custom implementation
    /// for iteratorating the IList because List provides an iterator already: GetEnumerator().
    /// </summary>
    public class PancakeHouseMenu : IEnumerable<MenuItem>
    {
        private IList<MenuItem> menuItems;

        public PancakeHouseMenu()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Name = "K & B's Pancake Breakfast",
                    Description = "Pancakes with scrambled eggs, and toast",
                    IsVegeterian = true,
                    Price = 2.99M
                },
                new MenuItem
                {
                    Name = "Regular Pancake Breakfast",
                    Description = "Pancakes with fried eggs, and sausage",
                    IsVegeterian = false,
                    Price = 2.99M
                },
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return menuItems.GetEnumerator();
        }

        IEnumerator<MenuItem> IEnumerable<MenuItem>.GetEnumerator()
        {
            return menuItems.GetEnumerator();
        }
    }
}
