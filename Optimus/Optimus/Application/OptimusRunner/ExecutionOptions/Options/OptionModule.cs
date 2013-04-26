using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.ExecutionOptions.Options
{
    public class OptionModule
    {
        public OptionModule(string[] args)
        {
            ExecutionValues = args;
        }

        public string[] ExecutionValues
        {
            get; set;
        }

    }
}
