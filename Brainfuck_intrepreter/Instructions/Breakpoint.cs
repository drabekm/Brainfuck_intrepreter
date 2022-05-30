namespace Brainfuck_intrepreter.Instructions
{
    internal class Breakpoint : IInstruction
    {
        public void Execute(InterpreterState state)
        {
            if (state.InDebugMode)
            {
                state.BreakpointTriggered = true;
            }
        }
    }
}
