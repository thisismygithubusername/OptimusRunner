using System;
using System.Collections.Generic;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class JenkinsModule : OptionModule, IDeploymentOption
    {
        public JenkinsModule(Queue<string> args) : base(args)
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
