namespace Brainfuck_intrepreter.Instructions
{
    public interface IInstruction
    {
        void Execute(InterpreterState state);
    }
}
