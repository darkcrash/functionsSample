﻿using System;
using System.IO;
using Microsoft.Azure.WebJobs.Script;
using Microsoft.Azure.WebJobs.Script.Config;

namespace WebJobScript
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the full path to the functions directory
            string functionsPath = Path.Combine(Environment.CurrentDirectory, "Functions");

            // When deployed as a WebJob, the WebJobs infrastructure handles
            // watching for script changes and restarting the host, so we
            // need to disable ScriptHost's inbuilt file watching.
            ScriptHostConfiguration config = new ScriptHostConfiguration()
            {
                RootScriptPath = functionsPath,
                FileWatchingEnabled = true
            };

            // start the ScriptHost
            ScriptHost scriptHost = ScriptHost.Create(config);
            scriptHost.RunAndBlock();
        }
    }
}
