using System;
using Optimus.Application.OptimusRunner;
using Optimus.Application.OptimusRunner.Components;

namespace Optimus.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMethod(args);
        }

        public static void StandardMethod(string[] args)
        {
            var results = new OptimusPrime(args).CommandControl.VerifyDeploymentOption().Transform().Fire();
            var morresults = results.Results;
            Console.WriteLine(morresults);
        }

        
    }
}
