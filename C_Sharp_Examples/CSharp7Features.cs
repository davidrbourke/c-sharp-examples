// Examples taken from https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
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


        // Ref locals and returns TODO

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
