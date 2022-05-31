using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    public class WhileEnd : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            if (state.Memory[state.Pointer] != 0)
            {
                state.ProgramCounter = state.CallStack.Last();
            }
            else
            {
                state.CallStack.RemoveAt(state.CallStack.Count - 1);
            }
        }
    }
}
