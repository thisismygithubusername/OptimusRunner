using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.Utils.DataBuilders
{
    //Todo 
    public class OptimusArgBuilder
    {
        private string Path { get; set; }
        private string RunKey { get; set; }
        private const string Space = " ";
        private string GeneratedTestRunArgs { get; set; }
        private List<string> TestRunValues { get; set; }

        public OptimusArgBuilder(string path, string runKey)
        {
            Path = path;
            RunKey = runKey;
            GeneratedTestRunArgs = "";
            TestRunValues = new List<string>();
        }
        
        public string GetCommanLineArgs()
        {
            return "key " + "Path " + GeneratedTestRunArgs;
        }

        public static string ConvertsListToString(IEnumerable<string> list )
        {
            
        }

        private static string ListToSingleArgString(IEnumerable<string> list )
        {
            var argsString = "";
            foreach (var arg in list)
            {
                //if()
                argsString = arg + Space;
            }
            return argsString;
        }
 
        private string AddSpace(string toAddTo)
        {
            return toAddTo + Space;
        }
    }
}
