using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    internal class SaveToStorage : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.HelpStorage = state.Memory[state.Pointer];
        }
    }
}
