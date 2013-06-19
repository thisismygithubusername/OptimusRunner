using System;
using System.Collections.Generic;
using System.Linq;
using GallioRunnerLibrary.Models.TestModels;
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

        public FullRunModule()
            : base()
        {

        }

        public void Run()
        {
            if (_multipleRunners)
            {
                RunMultipleRunners();
            }
            RunSingleRunner();   
        }

        public void DisplayHelpInfo()
        {
            const string message =
                "This option runs a full test run on a given binary. " +
                "You need to specify a location of the binary file";
            Console.WriteLine(message);
        }
        //Todo
        public Queue<string> GuidedArgSetup(string path)
        {
            return new Queue<string>();
        }

        public GallioTestRun TestResults { get; set; }

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
            var results = runner.TestRuns.First();
        }
        //Todo
        private void RunMultipleRunners()
        {
            
        }
    }
}
