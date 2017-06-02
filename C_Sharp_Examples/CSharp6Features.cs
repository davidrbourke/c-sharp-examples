using System;
using System.Collections.Generic;
using System.IO;
// Import of static methods from a classs
using static C_Sharp_Examples.SampleForStaticImport;

namespace C_Sharp_Examples
{
    // All information from https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6
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
        // A 'when' clause can be added to handle a specific exception, anything available can exception
        // can go into the 'when' clause.
        // The advantage of this over handling the logic in the catch and re-throwing, is that the stack trace
        // will now show the real source of the error.
        /*
            catch (FileNotFoundException e) 
            {
                if (e.FileName == @"C:\doesnotexist.txt")
                    return "File not found";
                else
                    throw; // the exception in this way comes from this line in the stack trace
            } 
        */
        public string FileExceptionFilter(string pathFilename)
        {
            try
            {
                using (FileStream f = File.Open(pathFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
            }
            catch (FileNotFoundException e) when (e.FileName == @"C:\doesnotexist.txt")
            {
                return "File not found";
            }

            return string.Empty;
        }

        public string FileExceptionFilterLogging(string pathFilename)
        {
            try
            {
                using (FileStream f = File.Open(pathFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
            }
            catch (Exception e) when (e.LogException())
            {
                // This will never exception
            }
            catch (FileNotFoundException fe)
            {
                // This one will be hit though...this scenario is unusual because a less specific handler is excecuted before a more specific one
            }

            return string.Empty;
        }
        
        // nameof Expression: this returns the name of an obejct
        public string NameofExample(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                return $"Not provided: {nameof(itemName)}";
            }

            return string.Empty;
        }

        // Index initializer on Dictionary and other similar types
        public void IndexInitialiseADictionary()
        {
            var webErrors = new Dictionary<int, string>
            {
                [404] = "Page not found",
                [302] = "Page moved",
                [500] = "Server error...."
            };
        }

        // Also extension Add methods in collection initialisers
        // See: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#index-initializers
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

    public static class Logger
    {
        public static bool LogException(this Exception e)
        {
            // Do some logging...
            return false;
        }
    }
}
