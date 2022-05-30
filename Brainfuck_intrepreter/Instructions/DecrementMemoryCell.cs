using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    public class DecrementMemoryCell : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.Memory[state.Pointer]--;
            if (state.Memory[state.Pointer] > (char)0)
            {
                state.Memory[state.Pointer] = (char)255;
            }
        }
    }
}
