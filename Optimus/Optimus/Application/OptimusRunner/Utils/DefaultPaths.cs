using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.Utils
{
    public static class DefaultPaths
    {
        private static readonly string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static readonly string ApiTestPath = MyDocumentsPath + "/GitHub/mbregressiontests/CSharp/APITest.Library/bin/Debug/APITest.Library.dll";

        public static readonly string RegressionV1TestsPath = MyDocumentsPath + "/GitHub/mbregressiontests/CSharp/Regression.Tests/bin/Debug/Regression.Tests.dll";
    }
}
