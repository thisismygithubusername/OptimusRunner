using System;
using System.Collections.Generic;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    //Todo
    public class CategoryModule : OptionModule, IDeploymentOption
    {
        public CategoryModule(Queue<string> args) : base(args)
        {

        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
