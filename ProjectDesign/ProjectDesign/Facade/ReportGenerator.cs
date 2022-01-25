using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ReportGenerator
    {
        public void GenerateReport(IEnumerable<string> qualityErrors, IEnumerable<string> securityErrors, IEnumerable<string> dependencyErrors)
        {
            Console.WriteLine("Generating report.");
            Console.WriteLine("Quality Scan Errors:");
            Console.WriteLine(string.Join(",", qualityErrors));

            Console.WriteLine("Security Scan Errors:");
            Console.WriteLine(string.Join(",", securityErrors));

            Console.WriteLine("Dependency Scan Errors:");
            Console.WriteLine(string.Join(",", dependencyErrors));
        }
    }
}
