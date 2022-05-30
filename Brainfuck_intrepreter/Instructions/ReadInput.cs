namespace Brainfuck_intrepreter.Instructions
{
    internal class ReadInput : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.WaitingForInput = true;
        }
    }
}
