namespace Brainfuck_intrepreter.Instructions
{
    public class DecrementPointer : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.Pointer--;
            if (state.Pointer < 0)
            {
                state.Pointer = Config.InterpreterMemorySize - 1;
            }
        }
    }
}
