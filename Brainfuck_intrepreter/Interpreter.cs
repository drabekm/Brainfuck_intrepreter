using Brainfuck_intrepreter.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            instructionsByCode.Add('[', new WhileStart());
            instructionsByCode.Add(']', new WhileEnd());
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

        
        /// <summary>
        /// Since brainfuck is supposed to ignore anything that isn't one of the brainfuck opcodes
        /// this just checks if all while loop brackets are closed
        /// </summary>
        /// <returns></returns>
        public bool ValidateCode()
        {
            bool isCodeValid = true;

            //Regex to separate angle brackets from rest of the code
            string bracketValidationCode = Regex.Replace(code, "[+-<>\\w]+", string.Empty);

            int leftBracketCount = 0, rightBracketCount = 0;
            foreach(var bracket in bracketValidationCode)
            {
                if (bracket == '[')
                {
                    leftBracketCount++;
                }
                else if (bracket == ']')
                {
                    rightBracketCount++;
                }

                if (rightBracketCount > leftBracketCount)
                {
                    isCodeValid = false;
                    break;
                }
            }

            if (leftBracketCount != rightBracketCount)
            {
                isCodeValid = false;
            }

            return isCodeValid;
        }

        private void IncrementProgramCounter()
        {
            state.ProgramCounter++;
            if (state.ProgramCounter == code.Length)
            {
                state.Finished = true;
            }
        }

        public void DoStep()
        {
            if (!state.Finished)
            {
                DecodeInstruction();
                IncrementProgramCounter();
            }
        }

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
