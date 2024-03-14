using System;
using Cosmos.Core;
using Sys = Cosmos.System;
using GrapeOS.Tasking;
using GrapeOS.Graphics;
using GrapeOS.Graphics.Apps;
using SVGAIITerminal;

namespace GrapeOS
{
    public sealed class Kernel : Sys.Kernel
    {
        public static Sys.FileSystem.CosmosVFS FS;

        protected override void BeforeRun()
        {
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Grape OS");
            Console.ResetColor();
            Console.WriteLine("!\n");

            try
            {
                FS = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS);
                FS.Initialize(true); 

                Resources.Generate(ResourceType.Priority);
                ProcessScheduler.AddProcess(WindowManager.Instance);
                LoadingDialogue.Instance = (LoadingDialogue)ProcessScheduler.AddProcess(new LoadingDialogue());
                ProcessScheduler.HandleRun();

                Resources.Generate(ResourceType.Normal);

                LoadingDialogue.Instance.Dispose();

                ProcessScheduler.AddProcess(new TestApp());

                ProcessScheduler.AddProcess(new Terminal());
            }
            catch (Exception ex)
            {
                WindowManager.Screen.IsEnabled = false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A fatal error occurred: " + ex.Message);
                Console.WriteLine("    at GrapeOS.Kernel.BeforeRun()");
                Console.WriteLine("    at Cosmos.System.Kernel.Start()");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to reboot...");
                Console.ReadKey(true);
                CPU.Reboot();
            }
        }

        protected override void Run()
        {
            try
            {
                ProcessScheduler.HandleRun();
            }
            catch (Exception ex)
            {
                WindowManager.Screen.IsEnabled = false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The process scheduler crashed!: " + ex.Message);
                Console.WriteLine("    at GrapeOS.Tasking.ProcessScheduler.HandleRun()");
                Console.WriteLine("    at GrapeOS.Kernel.Run()");
                Console.WriteLine("    at Cosmos.System.Kernel.Start()");

                Console.ResetColor();
                Console.WriteLine("\nPress any key to reboot...");
                Console.ReadKey(true);
                CPU.Reboot();
            }
        }
    }
}
