using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class PresetModule : OptionModule, IDeploymentOption
    {
        public PresetModule(Queue<string> args) : base(args)
        {
        }

        public PresetModule()
        {
        }
         
        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            const string message = "This option runs individual tests as apposed to a full run" +
                                   " Requires a path to the assembly followed by the names " +
                                   "of the desired tests to run.";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }
    }
}
