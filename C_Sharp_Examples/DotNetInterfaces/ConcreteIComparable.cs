using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DotNetInterfaces
{
    public class ConcreteIComparable
    {
        public void DoComparison()
        {
            var person1 = new PersonForComparison
            {
                Id = 3,
                Email = "c@c.com"
            };
            var person2 = new PersonForComparison
            {
                Id = 1,
                Email = "b@b.com"
            };
            var person3 = new PersonForComparison
            {
                Id = 2,
                Email = "a@a.com"
            };
            var collectionOfPeople = new List<PersonForComparison>
            {
                person1,
                person2,
                person3
            };

            // CompareTo will be called when sorting
            collectionOfPeople.Sort();

            // A comparer can also be passed - sorting by email
            collectionOfPeople.Sort(new PersonComparerByEmail());

        }
    }

    public class PersonForComparison : IComparable<PersonForComparison>
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public int CompareTo(PersonForComparison other)
        {
            if (other == null)
                return 1;

            if (Id == other.Id)
                return 0;

            return Id > other.Id ? 1 : -1;
        }

        public static bool operator <(PersonForComparison person1, PersonForComparison person2)
        {
            return person1.CompareTo(person2) == -1;
        }

        public static bool operator >(PersonForComparison person1, PersonForComparison person2)
        {
            return person1.CompareTo(person2) == 1;
        }
    }

    public class PersonComparerByEmail : IComparer<PersonForComparison>
    {
        public int Compare(PersonForComparison x, PersonForComparison y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            if (x.Email == y.Email)
                return 0;
 
            // Ordinal comparison is a byte by byte comparison
            return string.Compare(x.Email, y.Email, StringComparison.Ordinal);
        }
    }
}
