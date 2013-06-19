using System;
using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class JenkinsModule : OptionModule, IDeploymentOption
    {
        public JenkinsModule(Queue<string> args) : base(args)
        {
        }

        public JenkinsModule()
            : base()
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            throw new NotImplementedException();
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }
    }
}
