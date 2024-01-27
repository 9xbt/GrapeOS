using System;
using System.Collections.Generic;

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
            foreach (Process i in Processes)
            {
                if (i.PID != PID) continue;

                Processes.Remove(i);
                return;
            }

            throw new ArgumentException("Process not found!");
        }

        internal static void HandleRun()
        {
            foreach (Process i in Processes)
            {
                if (!i.Closing) i.HandleRun();
                else KillProcess(i);
            }
        }
    }
}
