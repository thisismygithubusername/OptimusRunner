using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Model.Filters;
using Gallio.Runner;
using Gallio.Runtime;
using Gallio.Runtime.ConsoleSupport;
using Gallio.Runtime.Logging;
using Gallio.Runtime.ProgressMonitoring;
using GallioRunnerLibrary.Models.TestModels;
using GallioRunnerLibrary.Utils.FilterGenerators;

namespace GallioRunnerLibrary.Runners
{
    public class SimpleGallioRunner
    {
        private const string GallioDirectory = @"C:\Program Files\Gallio\bin\";
        private RuntimeSetup Setup { get; set; }
        private ILogger Logger { get; set; }
        private TextLogger TextLogger { get; set; }
        private readonly List<string> _tests = new List<string>();
        private readonly GallioFilterGenerator _filterGenerator = new GallioFilterGenerator();
        private readonly List<GallioTestRun> _testRuns = new List<GallioTestRun>();
        private readonly List<TestRun> _testsRan = new List<TestRun>();
        private TextWriter ExceptionLogs { get; set; }

        public SimpleGallioRunner(string assemblyLocation)
        {
            AssemblyLocation = assemblyLocation;
            InitRunner();
        }

        public TestLauncher Launcher
        {
            get;
            set;
        }

        public List<GallioTestRun> TestRuns
        {
            get { return _testRuns; }
        }

        public List<TestRun> TestsRan
        {
            get { return _testsRan; }
        }

        public string AssemblyLocation
        {
            get;
            private set;
        }

        public void RunSingleTest(string testName)
        {
            RunDatTest(testName);
        }

        public SimpleGallioRunner LoadTests(string testName)
        {
            return AddTests(testName);
        }

        public SimpleGallioRunner LoadTests(List<string> testNames)
        {
            return AddTests(testNames);
        }

        public SimpleGallioRunner RunLoadedTests()
        {
            return RunLaucher();
        }

        private void RunDatTest(string testName)
        {
            AddTests(testName);
            RunLaucher();
        }

        private SimpleGallioRunner AddTests(IEnumerable<string> tests)
        {
            foreach (var test in tests)
            {
                AddTests(test);
            }
            return this;
        }

        private SimpleGallioRunner AddTests(string testName)
        {
            _tests.Add(testName);
            return this;
        }

        private SimpleGallioRunner RunLaucher()
        {
            return AddTestRun(this.ExecuteRun()).ClearTestFilters();
        }

        private SimpleGallioRunner ClearTestFilters()
        {
            Launcher.TestProject.ClearTestFilters();
            _tests.Clear();
            return this;
        }

        private SimpleGallioRunner AddTestRun(GallioTestRun testRun)
        {
            _testRuns.Add(testRun);
            return this;
        }

        private GallioTestRun ExecuteRun()
        {
            FormatFitlersForLauncher();
            var datetime = DateTime.Now;
            var results = Launcher.Run();
            return new GallioTestRun(results, datetime);
        }

        private void FormatFitlersForLauncher()
        {
            if (_tests.Count <= 0) return;
            Launcher.TestExecutionOptions.FilterSet =
                FilterUtils.ParseTestFilterSet(_filterGenerator.GenerateSpecificTestsFilter(_tests));
            _tests.Clear();
        }

        private void InitRunner()
        {
            LoadLauncherSetup().SetupLogger().CreateLauncher().AddAssemblyLocationToLauncher().InitializeRuntimeBootStrap();
        }

        private SimpleGallioRunner LoadLauncherSetup()
        {
            Setup = new RuntimeSetup();
            Setup.AddPluginDirectory(GallioDirectory);
            return this;
        }

        private SimpleGallioRunner SetupLogger()
        {
            //Logger = (ILogger)new RichConsoleLogger(NativeConsole.Instance);
            ExceptionLogs = new StringWriter();
            TextLogger = new TextLogger(ExceptionLogs);
            return this;
        }

        private SimpleGallioRunner CreateLauncher()
        {
            Launcher = new TestLauncher
            {
                //Logger = Logger,
                Logger = TextLogger,
                ProgressMonitorProvider = NullProgressMonitorProvider.Instance,
                RuntimeSetup = Setup,
                TestProject = { TestRunnerFactoryName = StandardTestRunnerFactoryNames.Local }
            };
            return this;
        }

        private SimpleGallioRunner AddAssemblyLocationToLauncher()
        {
            Launcher.AddFilePattern(AssemblyLocation);
            Launcher.ShowReports = true;
            Launcher.
            return this;
        }

        private void InitializeRuntimeBootStrap()
        {
            RuntimeBootstrap.Initialize(Setup, Logger);
        }
        //alternate runner implementation 
        private ITestRunner CreateRunner()
        {
            return TestRunnerUtils.CreateTestRunnerByName(StandardTestRunnerFactoryNames.IsolatedAppDomain);
        }

    }
}
