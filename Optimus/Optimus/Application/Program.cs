using Optimus.Application.OptimusRunner;

namespace Optimus.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var optimus = new OptimusPrime(args);
            optimus.CommandControl.VerifyDeploymentOption().Transform().Fire();
        }
    }
}
