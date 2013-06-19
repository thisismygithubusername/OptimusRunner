using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options;

namespace Optimus.Application.OptimusRunner.Components
{
    public class DeploymentOptions
    {
        private readonly Queue<string> _args;

        public static Type[] DeploymentTypes
        {
            get
            {
                return new[]
                    {
                        typeof (CategoryModule), typeof (FullRunModule), typeof (GoogleModule), typeof (JenkinsModule),
                        typeof (PresetModule), typeof (RunFixturesModule), typeof (AttributeModule), typeof(SpecificTestsModule)
                    };
            }
        }
        public DeploymentOptions()
        {
            
        }
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
            var testfile = info.Invoke(this, null);
            return testfile as IDeploymentOption;
        }


        public List<IDeploymentOption> RetrieveAllDeploymentOptions()
        {
            var options = new DeploymentKeyHandler().DeployKeys;
            return options.Select(RetrieveDeploymentModule).ToList();
        } 

        public static Queue<string> RunGuidedSetup(string moduleName, string path)
        {
            Type desiredModuleType = DeploymentTypes.First(type => type.Name.Equals(moduleName+"Module"));
            Console.WriteLine(desiredModuleType.Name);
            var deploymod = (IDeploymentOption) Activator.CreateInstance(desiredModuleType);
            return deploymod.GuidedArgSetup(path);
        }
    }
}
