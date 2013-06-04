using System.Collections.Generic;
using GallioRunnerLibrary.Runners;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    /*
     * "SpecificTests: path test test1 test2 test3"
     */
    public class SpecificTestsModule : OptionModule, IDeploymentOption
    {

        public SpecificTestsModule(Queue<string> args) : base(args) {}

        public void Run()
        {
            RunSingleRunnerWithTests();
        }

        private void RunSingleRunnerWithTests()
        {
            var v1Runner = new SimpleGallioRunner(Path);
            v1Runner.LoadTests(ExecutionValues).RunLoadedTests();
        }

    }
}
