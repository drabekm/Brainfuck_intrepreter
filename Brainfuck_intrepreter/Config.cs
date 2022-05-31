using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck_intrepreter
{
    public class Config
    {
        public const int InterpreterMemorySize = 80000; //size in bytes
        public const string AllowedTokens = "<>+-.,[]@$!";
    }
}
