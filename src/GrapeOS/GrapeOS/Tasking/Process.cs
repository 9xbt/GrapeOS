using System;

namespace GrapeOS.Tasking
{
    internal class Process
    {
        internal string Name;
        internal int PID;
        internal Action HandleRun;

        internal Process(string name, Action handleRun)
        {
            Name = name;
            PID = new Random().Next(0, ushort.MaxValue);
            HandleRun = handleRun;
        }
    }
}
