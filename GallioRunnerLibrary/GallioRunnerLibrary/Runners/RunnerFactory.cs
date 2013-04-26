using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallioRunnerLibrary.Models.AssemblyModels;

namespace GallioRunnerLibrary.Runners
{
    public class RunnerFactory
    {
        private readonly Dictionary<string, SimpleGallioRunner> _testRunners = new Dictionary<string, SimpleGallioRunner>();
        private readonly Queue<TestAssembly> _addedAssemblies = new Queue<TestAssembly>();
        private List<string> _runnerNames = new List<string>();
        private bool _runnersLoaded;

        public RunnerFactory(IEnumerable<string> assemblyPaths)
        {
            AddMultipleAssemblies(assemblyPaths);
            _runnersLoaded = false;
        }

        public RunnerFactory(string assemblyPath)
        {
            AddAssembly(assemblyPath);
        }

        public RunnerFactory() { }

        public void AddMultipleAssemblies(IEnumerable<string> paths)
        {
            foreach (var path in paths)
            {
                AddAssembly(path);
            }
        }

        public void AddAssembly(string path)
        {
            _addedAssemblies.Enqueue(new TestAssembly(path));
        }

        public Dictionary<string, SimpleGallioRunner> TestRunners
        {
            get
            {
                if (!_runnersLoaded)
                {
                    LoadAndInitializeRunners();
                    return _testRunners;
                }
                return _testRunners;
            }
        }

        public void LoadAndInitializeRunners()
        {
            while (_addedAssemblies.Count > 0)
            {
                AssignRunner(_addedAssemblies.Dequeue());
            }
            _runnersLoaded = true;
        }

        private void AssignRunner(TestAssembly assemblyinfo)
        {
            _testRunners[assemblyinfo.Name] = CreateRunner(assemblyinfo.Path);
        }

        private static SimpleGallioRunner CreateRunner(string path)
        {
            return new SimpleGallioRunner(path);
        }

    }
}
