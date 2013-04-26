using System.Collections.Generic;

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
            return _deployKeys.Contains("key");
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

        internal static class DeploymentKeys
        {
            public const string FullRun = "FullRun";
            public const string RunFixtures = "RunFixtures";
            public const string SpecificTests = "SpecificTests";
            public const string Category = "Category";
            public const string Jenkins = "Jenkins";
            public const string GoogleSpreadSheet = "GoogleSpreadSheet"; 
        }
    }
}
