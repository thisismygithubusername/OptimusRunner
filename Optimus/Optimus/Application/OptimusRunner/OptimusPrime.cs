using Optimus.Application.OptimusRunner.Components;

namespace Optimus.Application.OptimusRunner
{
    public class OptimusPrime
    {
        public OptimusPrime(string[] args)
        {
            InitArgs = args;
            //Transform();
        }

        private string[] InitArgs
        {
            get; set;
        }

        public CommandCenter CommandControl
        {
            get { return new CommandCenter(InitArgs);}
        }
        
        /*
         * Setups up Optimus for commands / inits tests
         */
        /*
        public LoadedTestCannon Transform()
        {
            return AssembleTestTargets();
        }
         * */
        
        /*
         * find tests wtih bases on options. 
         */
        /*
        private LoadedTestCannon AssembleTestTargets()
        {
            //Todo
            return new LoadedTestCannon();
        }
         * */
        


    }
}
