using System;
using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class GoogleModule : OptionModule, IDeploymentOption
    {
        public GoogleModule(Queue<string> args) : base(args)
        {
        }

        public GoogleModule()
            : base()
        {
        }


        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            const string message = "No help info yet";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }

        public Queue<string> GuidedArgSetup()
        {
            throw new NotImplementedException();
        }
    }
}
