using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    public class WhileStart : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.CallStack.Add(state.ProgramCounter);
        }
    }
}
