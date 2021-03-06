﻿using System;
using System.Collections.Generic;
using GallioRunnerLibrary.Models.TestModels;

namespace Optimus.Application.OptimusRunner.Components.ExecutionOptions.Options
{
    //Todo
    public class CategoryModule : OptionModule, IDeploymentOption
    {
        public CategoryModule(Queue<string> args) : base(args)
        {

        }

        public CategoryModule()
            : base()
        {

        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelpInfo()
        {
            const string message = "This option runs tests based on support gallio Category name" +
                                   " Requires a path to the assembly followed by a string " +
                                   "correspinding to the name of the category";
            Console.WriteLine(message);
        }

        public Queue<string> GuidedArgSetup(string path)
        {
            throw new NotImplementedException();
        }

        public GallioTestRun TestResults { get; set; }
    }
}
