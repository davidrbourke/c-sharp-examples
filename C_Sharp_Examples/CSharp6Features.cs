using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Import of static methods from a classs
using static C_Sharp_Examples.SampleForStaticImport;

namespace C_Sharp_Examples
{
    public class CSharp6Features
    {
        public string FirstName { get; }
        // Old: public string FirstName { get; private set; }
        // This get can only be in the constructor now.

        public CSharp6Features()
        {
            FirstName = "David";
        }

        // Auto-property initialisers
        public ICollection<double> Grades { get; } = new List<double>();

        // Expression body functions
        // Where an expression consists of only one statement:
        public string FullName => $"{FirstName } 23";

        // Using static method in another class
        public void ExecuteAStaticMethodWithoutNamespace()
        {
            DoSomethingAsStatic();
            // ExtensionMethodSample cannot be called, only in scope if used properly:
            var joinedString = "sample".ExensionMethodSample();
        }

        // Null conditional operators: check if person is null before attempting to access
        // This can also be used for deciding whether to call a method on an object:
        // e.g. person?.PrintNames();
        public string NullConditionalOperatorsForString()
        {
            Person p = null;
            // Will return null
            return p?.FirstName;
        }

        public int? NullConditionalOperatorsForInteger()
        {
            Person p = null;
            // Will return null - int? must be nullable
            return p?.Age;
        }

        // String interpolation
        // Methods can be called inside them as well as formatting options, also you can use linq in there.
        public void StringInterpolation()
        {
            var p = new Person { Age = 36, FirstName = "David" };
            string combined = $"{p.FirstName} {p.Age}";
        }

        // Exception Filters


    }

    public static class SampleForStaticImport
    {
        public static void DoSomethingAsStatic()
        {
            
        }

        public static string ExensionMethodSample(this string str)
        {
            return str + str;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
