using System;
using System.Collections.Generic;
using GrapeOS.Graphics;

namespace GrapeOS.Tasking
{
    internal static class ProcessScheduler
    {
        internal static List<Process> Processes = new List<Process>();

        internal static void AddProcess(Process process)
            => Processes.Add(process);

        internal static void KillProcess(Process process)
            => Processes.Remove(process);

        internal static void KillProcess(int PID)
        {
            foreach (Process p in Processes)
            {
                if (p.PID != PID) continue;

                Processes.Remove(p);
                return;
            }

            throw new ArgumentException("Process not found!");
        }

        internal static void HandleRun()
        {
            foreach (Process p in Processes)
            {
                try
                {
                    if (!p.Closing) p.HandleRun();
                    else KillProcess(p);
                }
                catch (Exception) { KillProcess(p); }
            }
        }
    }
}
