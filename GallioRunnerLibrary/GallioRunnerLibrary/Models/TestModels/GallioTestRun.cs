﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Runner;

namespace GallioRunnerLibrary.Models.TestModels
{
    public class GallioTestRun
    {
        public GallioTestRun(TestLauncherResult result, DateTime time)
        {
            Result = result;
            StartTime = time;
        }

        public DateTime StartTime { get; set; }

        public TestLauncherResult Result { get; set; }

        public void DumpRun()
        {
            Console.WriteLine(Result.Report.ToString());
        }

    }
}
