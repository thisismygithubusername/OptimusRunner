using System;
using System.Collections.Generic;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class GoogleModule : OptionModule, IDeploymentOption
    {
        public GoogleModule(Queue<string> args) : base(args)
        {
        }


        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
