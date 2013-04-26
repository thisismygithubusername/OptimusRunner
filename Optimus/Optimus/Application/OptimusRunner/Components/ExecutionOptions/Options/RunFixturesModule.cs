using System;
using System.Collections.Generic;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    //Todo
    public class RunFixturesModule : OptionModule, IDeploymentOption
    {
        public RunFixturesModule(Queue<string> args) : base(args)
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
