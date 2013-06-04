using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptimusRunnerSite.Models
{
    public class TestingModels
    {

        public class RunningTestModel 
        {
            public String Name;
            public String Class;
            public String Project;
            public String SiteID;
            public String Settings;
        }

        public class FailedTestModel : RunningTestModel
        {
            public String Failure;
        }

    }
}