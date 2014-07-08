using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostingSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add reference to System.Management.Automation

            // Create runspace using RunspaceFactory

            // Open runspace

            // Create PowerShell object

            // add to runspace

            // add script

            // invoke and capture results

            // display results

            #region Here's one we prepared earlier
#if false
            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell psh = PowerShell.Create();
            psh.Runspace = runspace;

            psh.AddScript("1 + 1");

            var results = psh.Invoke();

            foreach (var r in results)
            {
                Console.WriteLine(r.BaseObject);
            }
#endif
            #endregion
            Console.ReadLine();
        }
    }
}
