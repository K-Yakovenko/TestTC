using NUnit.Framework;
using System.Diagnostics;
using TestTC.Framework.Log;
using Application = TestTC.Framework.App.Application;

namespace TestTC.Framework.Base
{
    public class BaseTest
    {
        [SetUp]
        public void Init()
        {
            Process[] processes = Process.GetProcessesByName("TOTALCMD64");
            if (processes.Length != 0)
            {
                Application.app = TestStack.White.Application.Attach("TOTALCMD64");
                Nlog.log.Info($"Close application Total Commander");
                Application.app.Close();
            }
        }

        [TearDown]
        public void Cleanup()
        {
            Nlog.log.Info($"Close application Total Commander");
            Application.app.Close();
        }
    }
}
