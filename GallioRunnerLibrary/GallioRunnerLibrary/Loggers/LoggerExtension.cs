using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Runner.Events;
using Gallio.Runner.Extensions;
using Gallio.Runtime.Logging;

namespace GallioRunnerLibrary.Loggers
{
    public class LoggerExtension : ITestRunnerExtension 
    {
        public void Install(ITestRunnerEvents events, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public string Parameters { get; set; }

        public TestRunnerExtension Extension { get { return new LogExtension(); } }

        public void DOshit()
        {
            Extension.Events.TestStepFinished += (sender, args) => {};
        }

        
        
    }
}
