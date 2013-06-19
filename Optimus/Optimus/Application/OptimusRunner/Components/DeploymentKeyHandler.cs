using System.Collections.Generic;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions;

namespace Optimus.Application.OptimusRunner.Components
{
    class DeploymentKeyHandler
    {
        private readonly List<string> _deployKeys = new List<string>();

        public DeploymentKeyHandler()
        {
            LoadKeys();
        }

        public bool HasKey(string key)
        {
            return _deployKeys.Contains(key);
        }

        public List<string> DeployKeys
        {
            get { return _deployKeys; }
        } 

        public static bool IsDeploymentOption(string key)
        {
            return new DeploymentKeyHandler().HasKey(key);
        }

        private void LoadKeys()
        {
            AddKey(DeploymentKeys.FullRun)
                .AddKey(DeploymentKeys.RunFixtures)
                .AddKey(DeploymentKeys.SpecificTests)
                .AddKey(DeploymentKeys.Category)
                .AddKey(DeploymentKeys.Jenkins)
                .AddKey(DeploymentKeys.GoogleSpreadSheet);
        }

        private DeploymentKeyHandler AddKey(string key)
        {
            _deployKeys.Add(key);
            return this;
        }
    }
}
