using System;
using System.Collections;
using System.Collections.Generic;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options;

namespace Optimus.Application.OptimusRunner.Components
{
    public class CommandCenter
    {
        private string _mainKey;
        private Queue<string> ValidatedExecutionArgs { get; set; }
        private ConsoleColor _defaultColor; 

        public CommandCenter(string[] args)
        {
            ValidateArgs(args);
        }

        public OptimusPrime.OptimusPrimed VerifyDeploymentOption()
        {
            return new OptimusPrime.OptimusPrimed(new LoadedTestCannon(Option));
        }

        private IDeploymentOption Option
        {
            get { return new DeploymentOptions(ValidatedExecutionArgs).RetrieveDeploymentModule(_mainKey); }
        }

        private static bool IsValidDeploymentKey(string key)
        {
            return DeploymentKeyHandler.IsDeploymentOption(key);
        }

        private void ValidateArgs(string[] args)
        {
            if (args.Length < 1)
            {
                SetExecutionvalues();
            }
            else
            {
                if (IsValidDeploymentKey(args[0]))
                {
                    SetExecutionvalues(args);
                }
                else
                {
                    SetConsoleErrorColor().WriteError(args).TerminateExecution();
                }
            }
        }

        private CommandCenter SetConsoleErrorColor()
        {
            return SaveOldConsoleColor().ChangeConsoleColor(ConsoleColor.Red);
        }

        private CommandCenter SaveOldConsoleColor()
        {
            _defaultColor = Console.ForegroundColor;
            return this;
        }

        private CommandCenter WriteError(string[] args)
        {
            Console.WriteLine("Unsupported operation: " + args[0]);
            Console.ForegroundColor = _defaultColor;
            return this;
        }

        private CommandCenter ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            return this;
        }

        private void TerminateExecution()
        {
            Environment.Exit(0);
        }

        private void SetExecutionvalues(string[] args)
        {
            _mainKey = args[0];
            ValidatedExecutionArgs = LoadQueueofExectionArgs(args);
        }

        private void SetExecutionvalues()
        {
            var consoleInterpreter = new Interpreter();
            _mainKey = consoleInterpreter.GuidedSetup();
            ValidatedExecutionArgs = consoleInterpreter.BuiltDeploymentOptions;
        }

        private Queue<string> LoadQueueofExectionArgs(string[] args)
        {
            var queue = new Queue<string>();
            for (int i = 1; i < args.Length; i++)
            {
                queue.Enqueue(args[i]);
            }
            return queue;
        }
    }
}
