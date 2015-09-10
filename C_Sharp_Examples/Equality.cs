using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    public class Equality
    {

        public bool AreObjectsEqual(EqualityObject ea, EqualityObject eb)
        {
            return ea.Equals(eb);
        }
    }

    public class EqualityObject : IEquatable<EqualityObject>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(EqualityObject other)
        {
            if (this.Id.Equals(other.Id) &&
               this.Name.Equals(other.Name))
            {
                return true;
            }
            return false;
        }

        public EqualityObject CloneMe()
        {
            return this.MemberwiseClone() as EqualityObject;
        }
    }
}
