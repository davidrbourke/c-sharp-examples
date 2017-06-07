// Examples taken from https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7

using System;

namespace C_Sharp_Examples
{
    // In VS2015 the nuget package Microsoft.Net.Compilers must be installed
    // For Tuples, System.ValueTuple must be installed
    public class CSharp7Features
    {
        public int? OutVariables(string inputToConvertToInt)
        {
            if (int.TryParse(inputToConvertToInt, out int result))
            {
                return result;
            }
            return default(int?);
        }

        // In C# 7, tuples can be assigned semantic names, whereas previously they could on be accessed with: Item1, Item2, etc
        public void TuplesExample()
        {
            (string Alpha, string Beta) namedLetters = ("a", "b");
            string alpha = namedLetters.Alpha;
            string beta = namedLetters.Beta;

            // Or
            var letter = (Gamma: "g", Delta: "d");
            string gamma = letter.Gamma;
            string delta = letter.Delta;

            // Tuples are most useful as return types from private and internal methods
            var result = ReturningTuple("z", "x");
            string zed = result.Zed;
            string ekx = result.Ekx;
            // Deconstructing the tuple
            (string Zed, string Ekx) deconstrTuple = ReturningTuple("z", "x");

            // Deconstructing a class
            MyPoint myPoint = new MyPoint(0.3D, 1.5D);
            (double x, double y) = myPoint;
        }

        private (string Zed, string Ekx) ReturningTuple(string zed, string ekx)
        {
            return (Zed: zed, Ekx: ekx);
        }

        // Pattern matching
        public void PatternMatchingWithIs(object obj)
        {
            // In C# 7 the is operator can create a new variable of the validated runtime type 
            if (obj is int ii)
            {
                // do something with i
            }
            if (obj is string ss)
            {
                // do something with s
            }

            // It can also be used in a switch
            // The order is important - e.g. checking for 0 after int will mean that 0 will never be hit
            switch (obj)
            {
                case 0:
                    break;
                case int i:
                    break;
                case string s:
                    break;
                case null:
                    break;
            }
        }


        // Ref locals and return
        // ref - a reference to an object can be returned from anywhere in a method.
        // In the example, when the matrix object is found, a reference to the int is returned
        // so in UsingFind, when the valItem is updated, the object in the matrix is 
        // actually updated. 
        // Note there are 4 uses of the ref keyword for safety
        // 1. The Find method
        // 2. when returing the foudn int
        // 3. In UsingFind when making the method call
        // 4. In UsingFind when declaring the variable to hold the result of the ref method call.
        public ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
                }
            }
           throw new InvalidOperationException("Not found");
        }

        public void UsingFind()
        {
            int[,] matrix = new int[3,3];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = i + j;

            ref var valItem = ref this.Find(matrix, val => val == 4);
            valItem = 5;
            int updatedReferenceValue = matrix[2, 2];

        }
    }
    // The Deconstruct method can be used to assign the output of a method to a tuple using the out
    // and Deconstruct keyword
    public class MyPoint
    {
        public MyPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y)
        {
            x = this.X;
            y = this.Y;
        }
    }
}
