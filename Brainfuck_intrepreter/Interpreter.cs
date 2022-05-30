using Brainfuck_intrepreter.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Brainfuck_intrepreter
{
    class Interpreter
    {
        InterpreterState state;
        Dictionary<char, IInstruction> instructionsByCode;

        string code;

        private TextBox outputWindow;
        private Label labelHelp, labelIsBreak, labelIsDebug;


        public Interpreter(TextBox outputWindow, Label labelHelp, Label labelIsBreak, Label labelIsDebug)
        {
            state = new InterpreterState();

            instructionsByCode = new Dictionary<char, IInstruction>();

            instructionsByCode.Add('+', new IncrementMemoryCell());
            instructionsByCode.Add('-', new DecrementMemoryCell());
            instructionsByCode.Add('>', new IncrementPointer());
            instructionsByCode.Add('<', new DecrementPointer());
            instructionsByCode.Add('$', new SaveToStorage());
            instructionsByCode.Add('!', new LoadToStorage());
            instructionsByCode.Add('@', new Breakpoint());
            instructionsByCode.Add(',', new ReadInput());
            instructionsByCode.Add('.', new Print());

            this.labelHelp = labelHelp;
            this.labelIsBreak = labelIsBreak;
            this.labelIsDebug = labelIsDebug;
            this.outputWindow = outputWindow;
        }

        private void Reset()
        {
            state = new InterpreterState();

            outputWindow.Text = "OUTPUT:";
            labelHelp.Content = "Help variable value: 0";
            labelIsDebug.Content = "Is in debug: false";
            labelIsBreak.Content = "On breakpoint: false";
        }

        public void Start(string code, bool isDebug)
        {
            Reset();

            state.InDebugMode = isDebug;
            if (isDebug)
            {
                labelIsDebug.Content = "Is in debug: true";
            }

            RemoveWhitespacesAndComments(code);
            if (!ValidateCode())
            {
                MessageBox.Show("Your code is incorect. Check while brackets");
            }
        }

        private void RemoveWhitespacesAndComments(string code)
        {
            code = code.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            this.code = string.Join(string.Empty, code.Select(x => Config.AllowedTokens.Contains(x) ? x.ToString() : string.Empty));
        }

        public bool ValidateCode()
        {
            int leftBracketCount = 0, rightBracketCount = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '[')
                {
                    leftBracketCount++;
                }
                else if (code[i] == ']')
                {
                    rightBracketCount++;
                }
            }

            if (leftBracketCount == rightBracketCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Checks if the current memory block is > 0. If so continues with the code.
        /// If the memory block is == 0, the it skips everything inside the cycle
        /// it doesn't actually execute any code. It just changes a position where
        /// the program should continue
        /// </summary>
        /// <param name="code">Brainfuck code</param>
        //private void WhileStart()
        //{
        //    //If current memory value is zero -> skip to the end of a cycle. It's kinda like an if statement
        //    if (memory[pointer] == (char)0)
        //    {
        //        while (code[programCounter] != ']')
        //        {
        //            programCounter++;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Checks if the cycle should repeat or not and returns an index where the code should continue
        ///// it doesn't actually execute any code. It just returns a position where
        ///// the program should continue
        ///// </summary>        
        ///// <param name="code">Brainfuck code</param>
        //private void WhileEnd()
        //{
        //    if (memory[pointer] != 0)
        //    {
        //        int skipParenthesis = -1;

        //        //There could be more while cycles inside a while cycle
        //        //This makes sure to return to the correct while start
        //        while (!(skipParenthesis == 0 && code[programCounter] == '['))
        //        {

        //            if (code[programCounter] == ']')
        //            {
        //                skipParenthesis++;
        //            }
        //            if (code[programCounter] == '[')
        //            {
        //                skipParenthesis--;
        //            }

        //            programCounter--;
        //        }
        //    }
        //}

        private void IncrementProgramCounter()
        {
            state.ProgramCounter++;
            if (state.ProgramCounter == code.Length)
            {
                state.Finished = true;
            }
        }

        //private void MainLoop()
        //{
        //    while (programCounter < code.Length && !isFinished)
        //    {
        //        DecodeInstruction();
        //        IncrementProgramCounter();
        //        if(isBreak)
        //        {
        //            break;
        //        }
        //    }
        //}

        public void DoStep()
        {
            if (!state.Finished)
            {
                DecodeInstruction();
                IncrementProgramCounter();
            }
        }

        //public void Continue()
        //{
        //    //IncrementProgramCounter();
        //    isBreak = false;
        //    labelIsBreak.Content = "On breakpoint: false";
        //    MainLoop();
        //}

        private void DecodeInstruction()
        {
            char instructionToken = code[(int)state.ProgramCounter];
            if (instructionsByCode.ContainsKey(instructionToken))
            {
                var currentInstruction = instructionsByCode[code[(int)state.ProgramCounter]];
                currentInstruction.Execute(state);
            }
            else
            {
                throw new Exception("Instruction not implemented");
            }
        }


    }
}
