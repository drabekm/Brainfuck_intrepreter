using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter
{
    public class InterpreterState
    {
        public char[] Memory { get; set; } = new char[Config.InterpreterMemorySize];
        public char HelpStorage { get; set; }
        public uint Pointer { get; set; }
        public uint ProgramCounter { get; set; }

        public List<uint> CallStack { get; set; } = new List<uint> { };

        public bool InDebugMode { get; set; }
        public bool BreakpointTriggered { get; set; }
        public bool Finished { get; set; }
        public bool WaitingForInput { get; set; }

        public string OutputBuffer { get; set; }
    }
}
