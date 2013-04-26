using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GallioRunnerLibrary.Utils
{
    public class AssemblySniffer
    {
        private const string Dll = ".dll";
        private string AssemblyPath { get; set; }

        public AssemblySniffer(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
            GenerateAssemblyDirectoryPath();
        }

        public AppDomain CurrentAppDomain { get; set; }

        public void Sniff()
        {
            FindDllsInDirectory();
        }

        public void LoadSniffedDlls()
        {
            Load();
        }

        public void UnloadDependencies()
        {
            Unload();
        }

        public List<string> FoundDependencies
        {
            get;
            set;
        }

        public string DirectoryPath
        {
            get;
            set;
        }

        public string MainAssemblyDll
        {
            get;
            set;
        }

        public string MainAssemblyName
        {
            get { return GetMainAssemblyName(); }
        }

        public static string AssemblyNameFromPath(string path)
        {
            return GetAssemblyName(path);
        }

        private string GetMainAssemblyName()
        {
            var split = MainAssemblyDll.Split('.');
            var name = "";

            for (var i = 0; i < split.Count() - 1; i++)
            {
                name += split[i];
            }
            return name;
        }

        public Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly[] currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var resolutionPath = DirectoryPath;
            foreach (Assembly assembly in currentAssemblies)
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }

            return FindAssembliesInDirectory(args.Name, resolutionPath);
        }

        private void GenerateAssemblyDirectoryPath()
        {
            var spiltPath = AssemblyPath.Split('/');
            MainAssemblyDll = spiltPath[spiltPath.Count() - 1];
            DirectoryPath = GenerateDirectoryPath(spiltPath);
        }

        private static string GetAssemblyName(string assemblyPath)
        {
            var spiltPath = assemblyPath.Split('/');
            var thing = GenerateDirectoryPath(spiltPath);
            return spiltPath[spiltPath.Count() - 1];
        }

        private static string GenerateDirectoryPath(string[] splitPath)
        {
            var path = "";
            for (int i = 0; i < splitPath.Length - 1; i++)
            {
                path += splitPath[i] + "/";
            }
            return path;
        }

        private void Load()
        {
            foreach (var foundDependency in FoundDependencies)
            {
                Console.WriteLine(DirectoryPath + foundDependency);
                try
                {
                    var assembly = Assembly.LoadFrom(DirectoryPath + foundDependency);
                    AppDomain.CurrentDomain.Load(assembly.GetName());
                    AppDomain.CurrentDomain.ExecuteAssembly(assembly.FullName);
                }
                catch (Exception)
                {
                    Console.WriteLine("CouldNotLoad( " + foundDependency + " )");
                }
            }

            PrintAssemblies(CurrentAppDomain);
        }

        private void Unload()
        {

        }

        public void FindDllsInDirectory()
        {
            var allFilenames = Directory.EnumerateFiles(DirectoryPath).Select(Path.GetFileName);
            FoundDependencies = allFilenames.Where(fn => Path.GetExtension(fn) == Dll).ToList();
            //foreach (var file in FoundDependencies) { Console.WriteLine(file); }
        }

        private static Assembly FindAssembliesInDirectory(string assemblyName, string directory)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                Assembly assembly;

                if (TryLoadAssemblyFromFile(file, assemblyName, out assembly))
                    return assembly;
            }

            return null;
        }

        private static bool TryLoadAssemblyFromFile(string file, string assemblyName, out Assembly assembly)
        {
            try
            {
                // Convert the filename into an absolute file name for 
                // use with LoadFile. 
                file = new FileInfo(file).FullName;

                if (AssemblyName.GetAssemblyName(file).FullName == assemblyName)
                {
                    assembly = Assembly.LoadFile(file);
                    return true;
                }
            }
            catch
            {
                /* Do Nothing */
            }
            assembly = null;
            return false;
        }

        private static void PrintAssemblies(AppDomain appDomain)
        {
            Console.WriteLine("*************************************");
            foreach (var assembly in appDomain.GetAssemblies())
            {
                Console.WriteLine(assembly.FullName);
                Console.WriteLine();
            }
        }

    }
}
