namespace Brainfuck_intrepreter.Instructions
{
    public class IncrementPointer : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.ProgramCounter++;
            if (state.ProgramCounter > Config.InterpreterMemorySize - 1)
            {
                state.ProgramCounter = 0;
            }
        }
    }
}
