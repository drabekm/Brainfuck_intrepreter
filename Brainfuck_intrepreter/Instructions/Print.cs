namespace Brainfuck_intrepreter.Instructions
{
    internal class Print : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            state.OutputBuffer += state.Memory[state.Pointer].ToString();
        }
    }
}
