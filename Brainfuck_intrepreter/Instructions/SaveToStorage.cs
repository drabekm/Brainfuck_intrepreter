namespace Brainfuck_intrepreter.Instructions
{
    internal class SaveToStorage : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.HelpStorage = state.Memory[state.Pointer];
        }
    }
}
