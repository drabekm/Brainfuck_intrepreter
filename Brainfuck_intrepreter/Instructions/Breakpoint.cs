using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    internal class Breakpoint : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            if (state.InDebugMode)
            {
                state.BreakpointTriggered = true;
            }
        }
    }
}
