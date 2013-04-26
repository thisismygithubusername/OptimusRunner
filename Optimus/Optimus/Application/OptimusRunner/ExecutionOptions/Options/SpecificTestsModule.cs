using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.ExecutionOptions.Options
{
    public class SpecificTestsModule : OptionModule, IRunnerOption
    {
        public SpecificTestsModule(string[] args) : base(args)
        {
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
