namespace Brainfuck_intrepreter.Instructions
{
    public class DecrementPointer : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.ProgramCounter--;
            if (state.ProgramCounter < 0)
            {
                state.ProgramCounter = Config.InterpreterMemorySize - 1;
            }
        }
    }
}
