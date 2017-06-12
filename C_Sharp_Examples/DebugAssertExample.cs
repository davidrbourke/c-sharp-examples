using System.Diagnostics;

namespace C_Sharp_Examples
{
    public class DebugAssertExample
    {
        // Checks for a condition, if the condition is false, outputs a message and the call stack
        // This message is displayed in a pop-up window.
        public int ExecuteAssertion(int foo, int bar)
        {
            string message = "Foo and bar cannot both be zero";
            //Debug.Assert(foo == 0 || bar == 0, message);
            Debug.WriteLineIf(foo == 0 || bar == 0, message);
            return foo * bar;
        }
    }
}
