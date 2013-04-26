using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallioRunnerLibrary.Utils;

namespace GallioRunnerLibrary.Models.AssemblyModels
{
    public class TestAssembly
    {
        public TestAssembly(string assemblyPath)
        {
            Name = AssemblySniffer.AssemblyNameFromPath(assemblyPath);
            Path = assemblyPath;
        }

        public string Path
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
