using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    public class CloningExample
    {
        public CloneablePerson UseMemberCloneWise(CloneablePerson personA)
        {
            var personB = personA.ShallowCopy();

            // A shallow copy will update the new objects value types
            personB.Age = 20;

            // The composed objects for personA & personB both reference the same Address instance
            // so both objects will appear updated with the new address
            personB.Address.Street = "Wardown";

            return personB;
        }

        public CloneablePerson DeepCopyWithICloneable(CloneablePerson personA)
        {
            var personB = (CloneablePerson) personA.Clone();
            personB.Age = 15;

            // The Clone implementation does a deep copy which creates a new object
            // of Address for the cloned object, so changing it doesn't
            // effect the personA object.
            personB.Address.Street = "Wardown";

            return personB;
        }
                
        public class CloneablePerson : ICloneable
        {
            public int PersonId { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }

            public object Clone()
            {
                var clone = (CloneablePerson)this.MemberwiseClone();
                clone.Address = new Address();
                clone.Address.Street = this.Address.Street;

                return clone;
            }

            public CloneablePerson ShallowCopy()
            {
                return (CloneablePerson)this.MemberwiseClone();
            }
        }

        public class Address
        {
            public string Street { get; set; }
        }
    }

}
