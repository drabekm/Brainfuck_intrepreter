using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    internal class Print : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.OutputBuffer += state.Memory[state.Pointer].ToString();
        }
    }
}
