using System;
using System.Collections;
using System.Collections.Generic;
using Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options;

namespace Optimus.Application.OptimusRunner.Components
{
    public class CommandCenter
    {
        private string _mainKey; 
        public CommandCenter(string[] args)
        {
            ValidateArgs(args);
        }

        private void ValidateArgs(string[] args)
        {
            if (IsValidDeploymentKey(args[0]))
            {
                SetExecutionvaluesFromArgs(args);
            }
            else
            {
                throw new InvalidOperationException("Not supported operation:" + args[0]);
            }
        }

        private Queue<string> ValidatedExecutionArgs { get; set; }

        public IDeploymentOption VerifiedDeploymentOption()
        {
            return new DeploymentOptions(ValidatedExecutionArgs).RetrieveDeploymentModule(_mainKey);
        }

        private bool IsValidDeploymentKey(string key)
        {
            return new DeploymentKeyHandler().HasKey(key);
        }

        private void SetExecutionvaluesFromArgs(string[] args)
        {
            var queue = new Queue<string>();
            _mainKey = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                queue.Enqueue(args[i]);    
            }
            ValidatedExecutionArgs = queue;
        }

         

    }
}
