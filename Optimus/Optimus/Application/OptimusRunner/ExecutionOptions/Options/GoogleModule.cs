using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.ExecutionOptions.Options
{
    public class GoogleModule : OptionModule, IRunnerOption
    {
        public GoogleModule(string[] args) : base(args)
        {
        }


        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
