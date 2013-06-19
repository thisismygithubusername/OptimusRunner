using System;
using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    //Todo
    public class RunFixturesModule : OptionModule, IDeploymentOption
    {
        public RunFixturesModule(Queue<string> args) : base(args)
        {
        }

        public RunFixturesModule()
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            const string message = "This option runs test contained in a fixture." +
                                   " Requires a path to the assembly followed by the names " +
                                   "of the desired test fixtures.";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }
    }
}
