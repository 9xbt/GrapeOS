using System;

namespace GrapeOS.Tasking
{
    internal abstract class Process
    {
        internal string Name;
        internal bool Closing;
        internal ushort PID;

        internal Process(string name)
        {
            Name = name;
            PID = (ushort)new Random().Next(ushort.MinValue, ushort.MaxValue);
        }

        internal abstract void HandleRun();

        internal virtual void Dispose() => Closing = true;
    }
}
