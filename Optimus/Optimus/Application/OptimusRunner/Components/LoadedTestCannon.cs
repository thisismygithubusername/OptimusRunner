using System;
using System.IO;
using System.Threading;
using GallioRunnerLibrary.Models.TestModels;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions;

namespace Optimus.Application.OptimusRunner.Components
{
    public class LoadedTestCannon
    {
        private readonly IDeploymentOption _deployer;
        private TextWriter _consoleOutRef;
        private TextWriter _hijackedStream = new StringWriter();

        public LoadedTestCannon(IDeploymentOption deployModule)
        {
            _deployer = deployModule;
            _consoleOutRef = Console.Out;
        }

        public LoadedTestCannon Fire()
        {
            var StartTests = new Thread(new ThreadStart(ExecuteRun));
            var WatchOutput = new Thread(VerifyChromeDriveInitiated);
            StartTests.Start();
            WatchOutput.Start();
            return this; 
        }

        public GallioTestRun Results
        {
            get; set;
        }

        private void ExecuteRun()
        {
            Console.SetOut(HijackedStream);
            _deployer.Run();
            _deployer.TestResults = Results;
            Console.SetOut(_consoleOutRef);
        }

        private TextWriter HijackedStream 
        { 
            get { return _hijackedStream; }
        }

        private void VerifyChromeDriveInitiated()
        {
            Thread.Sleep(2000);
            HijackedStream.FlushAsync();
            var ouptut = HijackedStream.ToString();
            if (ouptut.Contains("Started ChromeDriver"))
            {
                Console.WriteLine("ChromeDriverInitiated");
                Console.WriteLine("Tests Running");
            }
            Console.SetOut(_consoleOutRef);

        }

    }
}
