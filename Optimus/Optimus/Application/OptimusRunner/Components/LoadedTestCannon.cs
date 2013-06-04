using Optimus.Application.OptimusRunner.Components.ExecutionOptions;

namespace Optimus.Application.OptimusRunner.Components
{
    public class LoadedTestCannon
    {
        private readonly IDeploymentOption _deployer; 

        public LoadedTestCannon(IDeploymentOption deployModule)
        {
            _deployer = deployModule;
        }

        public void Fire()
        {
            _deployer.Run();
        }
    }
}
