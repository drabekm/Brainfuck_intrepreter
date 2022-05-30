using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter.Instructions
{
    public interface IInstruction
    {
        void Execute(InterpreterState state);
    }
}
