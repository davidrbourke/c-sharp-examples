using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    // Delegate delcaration - void
    // A blue-print for a method that data is going to get put into
    public delegate int WorkPerformanceHandler(int hours, string workType);

    public class DelegateExample
    {
        public void DoTheWork()
        {
            Manager manager = new Manager();
            // Create a new instance of the delegate and pass in the function handler
            WorkPerformanceHandler handler = new WorkPerformanceHandler(manager.ManagerWorkPerformed);

            Employee employee = new Employee();
            handler += new WorkPerformanceHandler(employee.EmployeeWorkPerformed);

            // Anonymous method can also be used as handler for a delegate
            handler += delegate(int hours, string workType) { return hours + 3; };

            // Anonymous lambda expression, the parameters are passed into the brackets
            // types don't have to be defined.
            handler += (hours, workType) => hours + 4;

            // Run the delegate by calling it with the required parameters
            int i = handler(3, "manager");
        }

        public void MyDelegateFunction()
        {
            Func<int, bool> myFunc = a => a == 5;
            bool isIt = ProcessSomething(myFunc);
        }

        public bool ProcessSomething(Func<int, bool> process)
        {
            return process(5);
        }

        public class Manager
        {
            // This is the handler for the delegate, there can be many...
            public int ManagerWorkPerformed(int hours, string workType)
            {
                return hours + 1;
            }
        }

        public class Employee
        {
            // This is the handler for the delegate, there can be many...
            public int EmployeeWorkPerformed(int hours, string workType)
            {
                return hours + 2;
            }
        }
    }
}
