using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions
{
    public interface IDeploymentOption
    {
        void Run();
        void DisplayHelpInfo();
        Queue<string> GuidedArgSetup(string path);
        GallioTestRun TestResults { get; set; }
    }
}
