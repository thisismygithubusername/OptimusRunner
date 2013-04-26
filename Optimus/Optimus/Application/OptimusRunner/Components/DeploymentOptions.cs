using System.Collections.Generic;
using System.Reflection;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options;

namespace Optimus.Application.OptimusRunner.Components
{
    public class DeploymentOptions
    {
        private readonly Queue<string> _args;

        public DeploymentOptions(Queue<string> args)
        {
            _args = args;
        }

        public CategoryModule Category()
        {
            //Todo not supported in runner yet
            return new CategoryModule(_args);
        }

        public FullRunModule FullRun()
        {
            return new FullRunModule(_args);
        }

        public GoogleModule GoogleSpreadSheet()
        {
            //Todo
            return new GoogleModule(_args);
        }

        public JenkinsModule Jenkins()
        {
            //Todo
            return new JenkinsModule(_args);
        }

        public RunFixturesModule RunFixtures()
        {
            //Todo
            return new RunFixturesModule(_args);
        }

        public SpecificTestsModule SpecificTests()
        {
            return new SpecificTestsModule(_args);
        }

        public IDeploymentOption RetrieveDeploymentModule(string deploymentKey)
        {
            MethodInfo info = GetType().GetMethod(deploymentKey);
            var testfile = info.Invoke(null, null);
            return testfile as IDeploymentOption;
        }

    }
}
