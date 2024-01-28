using System;

namespace GrapeOS.Tasking
{
    internal abstract class Process
    {
        internal string Name;
        internal bool Closing;
        internal int PID;

        internal Process(string name)
        {
            Name = name;
            PID = new Random().Next(0, ushort.MaxValue);
        }

        internal abstract void HandleRun();

        internal virtual void Dispose() => Closing = true;
    }
}
