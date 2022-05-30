namespace Brainfuck_intrepreter.Instructions
{
    internal class LoadToStorage : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.Memory[state.Pointer] = state.HelpStorage;
        }
    }
}
