using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.Components
{
    public class Interpreter : ConsoleInterface
    {
        public Interpreter()
        {
            DeploymentHandler = new DeploymentKeyHandler();
            DisplayGreeting();
        }

        private DeploymentKeyHandler DeploymentHandler
        {
            get; set;
        }
        public string GuidedSetup()
        {
            var option = ReadValidInputOption();
            var assemPath = ReadBinaryLocation();
            BuiltDeploymentOptions = DeploymentOptions.RunGuidedSetup(option, assemPath);
            return option;
        }

        public Queue<string> BuiltDeploymentOptions
        {
            get; set;
        } 

        //Read a path to the binary to be run. 
        private string ReadBinaryLocation()
        {
            Console.WriteLine("Enter a valid path to the binary containing tests to run: ");
            var path = Console.ReadLine();
            Console.WriteLine();
            return VerifyPath(path) ? path : ReadBinaryLocation();
        } 

        //Todo checks to see whether the path is a valid path to a binary
        private bool VerifyPath(string path)
        {
            return true;
        }

        private string ReadValidInputOption(string option  = null, bool error = false)
        {
            PrintPossibleError(option, error);
            option = DisplyOptionQuestion().ReadRawInput();
            return DeploymentHandler.HasKey(option) ? option : ReadValidInputOption(option, true);
        }

        private Interpreter DisplyOptionQuestion()
        {
            Console.WriteLine("Please enter a valid option");
            return this;
        }

        private string ReadRawInput()
        {
            return Console.ReadLine();
        }

        private void PrintPossibleError(string option, bool error)
        {
            if (error)
            {
                this.SetConsoleErrorColor();
                Console.WriteLine("Unsupported Operation: " + option);
                this.SetConsoleDefaultColor();
            }
        }

        private void DisplayHelpMenu()
        {
            this.SetConsoleTaskColor();
            foreach (var option in DeploymentHandler.DeployKeys)
            {
                Console.WriteLine(option);
            }
            this.SetConsoleDefaultColor();
        }

        private void DisplayGreeting()
        {

            Console.WriteLine("Welcome to the Optimus TestRunner");
            Console.WriteLine("Here are a list of supported operations keys");
            DisplayHelpMenu();
        }
    }
}
