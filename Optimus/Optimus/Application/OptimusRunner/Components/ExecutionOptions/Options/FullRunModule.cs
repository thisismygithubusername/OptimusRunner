using System.Collections.Generic;
using System.Linq;
using GallioRunnerLibrary.Runners;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    public class FullRunModule : OptionModule, IDeploymentOption
    {
        private readonly List<string> _assembliesPaths = new List<string>();
        private bool _multipleRunners;

        public FullRunModule(Queue<string> args) : base(args)
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
        //Todo
        private void RunMultipleRunners()
        {
            
        }
    }
}
