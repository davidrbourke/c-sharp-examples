using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Sharp_Examples
{
    // Language Integrated Queries
    public class LinqExamples
    {
        public void SimpleSample()
        {
            string[] instructors = { "David", "Robert", "Bourke", "Empty" };
            IEnumerable<string> query = from s in instructors
                                     //   where s.Length == 5
                                      //  orderby s descending
                                        select s;
            // select is always last!
            IList<string> output = query.ToList();
        }

        public void ClassSample()
        {
            HiredEmployee e1 = new HiredEmployee { Id = 1, Name = "David", HireDate = DateTime.Now };
            HiredEmployee e2 = new HiredEmployee { Id = 2, Name = "Robert", HireDate = DateTime.Now.AddMonths(-7) };
            HiredEmployee e3 = new HiredEmployee { Id = 3, Name = "Bourke", HireDate = DateTime.Now.AddYears(-2) };
            IEnumerable<HiredEmployee> employees = new List<HiredEmployee>
            {
                e1, e2, e3
            };

            IEnumerable<HiredEmployee> query = from e in employees
                                          where e.HireDate.Year < 2015
                                          orderby e.Name
                                          select e;

            IList<HiredEmployee> output = query.ToList();
        }

        private class HiredEmployee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime HireDate { get; set; }
        }


        public void LingToXmlSample()
        {
            // Using linq to produce xml
            XDocument document = new XDocument(
            new XElement("Processes",
                from p in Process.GetProcesses()
                orderby p.ProcessName ascending
                select new XElement("Process",
                    new XAttribute("Name", p.ProcessName),
                    new XAttribute("PID", p.Id))));


            IEnumerable<int> pids = from d in document.Descendants("Process")
                                    where d.Attribute("Name").Value == "devenv"
                                    orderby (int)d.Attribute("PID") ascending
                                    select (int)d.Attribute("PID");

            IEnumerable<int> output = pids.ToList();

        }


        public void LinqToSqlSample()
        {
            EmployeesDatabaseDataContext context =
                new EmployeesDatabaseDataContext();

            IQueryable<Employee> employees = from e in context.Employees
                                             where e.JobDescription.JobDescription1 == "Developer"
                                              select e;

            var output = employees.ToList();


        }

        /// <summary>
        /// When using Linq to sql for example, the .Net code uses expressions to read the function passed in.
        /// </summary>
        public void LinqExpressionExample()
        {
            // Function
            Func<int, int, int> multiply = (x, y) => x * y;
            int z = multiply(2, 5);

            // Using System.Linq.Expressions    
            // Expressions contain data about the Function
            Expression<Func<int, int, int>> multiplyExp = (x, y) => x * y;
            Func<int, int, int> mult = multiplyExp.Compile();
            mult(10, 20);


        }


        public void GeneralLinqToSql()
        {
            EmployeesDatabaseDataContext context =
              new EmployeesDatabaseDataContext();
            //

            IQueryable<Employee> employees = from e in context.Employees
                                             where e.JobDescription.JobDescription1 == "Developer"
                                             orderby e.Name descending
                                             select e;

            IQueryable<Employee> employees2 = context.Employees.Where(e => e.JobDescription.JobDescription1 == "Developer")
                                            .OrderByDescending(e => e.Name)
                                            .Select(e => e); // Select is actually OPTIONAL

            // Single selection
            Employee employee1 = context.Employees.Where(e => e.JobDescription.JobDescription1 == "Developer")
                                            .OrderByDescending(e => e.Name)
                                            .Select(e => e)
                                            .First(); // No corresponding keyword in comprehension syntax

        }

        public void LinqToAnonymousTypes()
        {
            EmployeesDatabaseDataContext context = new EmployeesDatabaseDataContext();
            
            // var keyword has a key role
            // Single selection
            var employees1 = context.Employees.Where(e => e.JobDescription.JobDescription1 == "Developer")
                                           .OrderByDescending(e => e.Name)
                                           .Select(e => new
                                           {
                                               FirstName = e.Name
                                           });
        }

        /// <summary>
        /// Let allows variables to be introduced into a query to help with reuse
        /// </summary>
        public void UsingLet()
        {
            EmployeesDatabaseDataContext context = new EmployeesDatabaseDataContext();

            var output = from a in context.Employees
                         let lname = a.Name.ToLower()
                         where lname == "david"
                         select lname;

        }

        /// <summary>
        /// Allows you to continue using a query after using Select.
        /// </summary>
        public void UsingInto()
        {
            EmployeesDatabaseDataContext context = new EmployeesDatabaseDataContext();

            var output = from a in context.Employees
                         where a.Name == "David"
                         select a
                             into p
                             where p.Name.Length < 5
                             select p;


            // Grouping
            var output2 = from a in context.Employees
                          group a by a.JobDescriptionId into b
                          orderby b.Key ascending
                          select b;

            // Composite Key grouping requires an anonymous type
            var output3 = from a in context.Employees
                          group a by new
                          {
                              a.Name,
                              a.JobDescriptionId
                          };

        }
    }
}

