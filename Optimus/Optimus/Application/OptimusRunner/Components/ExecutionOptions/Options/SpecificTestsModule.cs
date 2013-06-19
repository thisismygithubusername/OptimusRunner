using System;
using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;
using GallioRunnerLibrary.Runners;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    /*
     * "SpecificTests: path test test1 test2 test3"
     */
    public class SpecificTestsModule : OptionModule, IDeploymentOption
    {

        public SpecificTestsModule(Queue<string> args) : base(args) {}
        public SpecificTestsModule() : base() { }

        public void Run()
        {
            RunSingleRunnerWithTests();
        }

        public void DisplayHelpInfo()
        {
            const string message = "This option runs individual tests as apposed to a full run" +
                                   " Requires a path to the assembly followed by the names " +
                                   "of the desired tests to run.";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path )
        {
            Console.WriteLine("Please enter the names of the tests you like to run separated by a space");
            var tests = Console.ReadLine();
            var queue = new Queue<string>();
            queue.Enqueue(path);
            if (!string.IsNullOrEmpty(tests))
            {
                foreach (var test in tests.Split(' ')) { queue.Enqueue(test); }
            }
            return queue;
        }

        public GallioTestRun TestResults { get; set; }

        private void RunSingleRunnerWithTests()
        {
            var v1Runner = new SimpleGallioRunner(Path);
            v1Runner.LoadTests(ExecutionValues).RunLoadedTests();
            TestResults = v1Runner.TestRuns[0];
        }

    }
}
