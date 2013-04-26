using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallioRunnerLibrary.Runners;
using Optimus.Application.OptimusRunner.Utils;

namespace Optimus.Application.OptimusRunner.ExecutionOptions.Options
{
    public class FullRunModule : OptionModule, IRunnerOption
    {
        private readonly List<string> _assembliesPaths = new List<string>();
        private bool _multipleRunners;

        public FullRunModule(string[] args) : base(args)
        {
            ParseAssemblies();
        }

        public void Run()
        {
            if (_multipleRunners)
            {
                RunMultipleRunners();
            }
            RunSingleRunner();   
        }

        private void ParseAssemblies()
        {
            foreach (var executionValue in base.ExecutionValues)
            {
                _assembliesPaths.Add(executionValue);
            }
            _multipleRunners = _assembliesPaths.Count > 1;
        }

        private void RunSingleRunner()
        {
            var runner = new SimpleGallioRunner(_assembliesPaths.First());
            runner.RunLoadedTests();
        }

        private void RunMultipleRunners()
        {
            
        }
    }
}
