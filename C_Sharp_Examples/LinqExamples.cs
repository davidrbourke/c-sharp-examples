using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                                              select e;

            var output = employees.ToList();
        }
    }
}

