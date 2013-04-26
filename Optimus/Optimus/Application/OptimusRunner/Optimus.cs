using Optimus.Application.OptimusRunner.Components;

namespace Optimus.Application.OptimusRunner
{
    public class Optimus
    {
        public Optimus()
        {
            Transform();
        }

        /*
         * Setups up Optimus for commands / inits tests
         */
        public LoadedTestCannon Transform()
        {
            return AssembleTestTargets();
        }

        /*
         * find tests wtih bases on options. 
         */
        private LoadedTestCannon AssembleTestTargets()
        {
            //Todo
            return new LoadedTestCannon();
        }


    }
}
