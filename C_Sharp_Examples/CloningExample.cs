using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    public class CloningExample
    {
        public Person UseMemberCloneWise(Person personA)
        {
            var personB = personA.ShallowCopy();

            // A shallow copy will update the new objects value types
            personB.Age = 20;

            // The composed objects for personA & personB both reference the same Address instance
            // so both objects will appear updated with the new address
            personB.Address.Street = "Wardown";

            return personB;
        }

        public Person DeepCopyWithICloneable(Person personA)
        {
            var personB = (Person) personA.Clone();
            personB.Age = 15;

            // The Clone implementation does a deep copy which creates a new object
            // of Address for the cloned object, so changing it doesn't
            // effect the personA object.
            personB.Address.Street = "Wardown";

            return personB;
        }
                
        public class Person : ICloneable
        {
            public int PersonId { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }

            public object Clone()
            {
                var clone = (Person)this.MemberwiseClone();
                clone.Address = new Address();
                clone.Address.Street = this.Address.Street;

                return clone;
            }

            public Person ShallowCopy()
            {
                return (Person)this.MemberwiseClone();
            }
        }

        public class Address
        {
            public string Street { get; set; }
        }
    }

}
