using Optimus.Application.OptimusRunner.Components;

namespace Optimus.Application.OptimusRunner
{
    public class OptimusPrime
    {
        public OptimusPrime(string[] args)
        {
            InitArgs = args;
        }

        private string[] InitArgs
        {
            get; set;
        }

        public CommandCenter CommandControl
        {
            get { return new CommandCenter(InitArgs); }
        }

        public class OptimusPrimed
        {
            private LoadedTestCannon TestCannon { get; set; }
            
            public OptimusPrimed(LoadedTestCannon testCannon)
            {
                TestCannon = testCannon;
            }

            public LoadedTestCannon Transform()
            {
                return TestCannon;
            }

        }
    }
}
