using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.IteratorPattern
{
    /// <summary>
    /// This is our customised implementation of the IEnumerator class.
    /// We have to implement each of the methods to control how the MenuItem[] array is iterated.
    /// </summary>
    public class DinnerMenuIterator : IEnumerator<MenuItem>
    {
        private MenuItem[] menuItems;
        private int position;

        public DinnerMenuIterator(MenuItem[] items)
        {
            position = 0;
            menuItems = items;
        }

        public MenuItem Current
        {
            get {
                return menuItems[position++];
            }
        }

        public void Dispose()
        {
            menuItems = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return menuItems[position++]; }
        }

        public bool MoveNext()
        {
            if (position >= menuItems.Length)
                return false;
            else if (menuItems[position] == null)
                return false;
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
