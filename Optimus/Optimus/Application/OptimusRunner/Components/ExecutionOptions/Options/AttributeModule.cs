using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class AttributeModule : OptionModule, IDeploymentOption
    {
        public AttributeModule(Queue<string> args) : base(args)
        {
        }

        public AttributeModule()
            : base()
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            const string message = "This option runs tests based on a custom attribute name." +
                                   " Requires a path to the assembly followed by a string " +
                                   "correspinding to the name of the attribte";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }
    }
}
