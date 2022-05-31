namespace Brainfuck_intrepreter.Instructions
{
    public class IncrementPointer : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.Pointer++;
            if (state.Pointer > Config.InterpreterMemorySize - 1)
            {
                state.Pointer = 0;
            }
        }
    }
}
