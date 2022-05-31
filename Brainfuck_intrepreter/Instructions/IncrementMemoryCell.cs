namespace Brainfuck_intrepreter.Instructions
{
    public class IncrementMemoryCell : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            var value = state.Memory[state.Pointer];
            if (state.Memory[state.Pointer] > (char)255)
            {
                state.Memory[state.Pointer] = (char)0;
            }
        }
    }
}
