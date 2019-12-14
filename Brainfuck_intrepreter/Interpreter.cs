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
        //Consts
        private const int memoryAmount = 80000;
        //Vars
        private char[] memory = new char[memoryAmount];
        private char helpVariable = (char)0;
        private uint pointer = 0;
        private string code;
        private int programCounter = 0;

        private bool isDebug = false;
        private bool isBreak = true;
        private bool isFinished = false;
                
        private TextBox outputWindow;
        private Label labelHelp, labelIsBreak, labelIsDebug;
        

        public Interpreter(TextBox outputWindow, Label labelHelp, Label labelIsBreak, Label labelIsDebug)
        {
            this.labelHelp = labelHelp;
            this.labelIsBreak = labelIsBreak;
            this.labelIsDebug = labelIsDebug;
            this.outputWindow = outputWindow;
        }
        
        private void IncrementMemory()
        {
            memory[pointer]++;
            if(memory[pointer] > (char)255)
            {
                memory[pointer] = (char)0;
            }
        }
        private void DecrementMemory()
        {
            memory[pointer]--;
            if (memory[pointer] < (char)0)
            {
                memory[pointer] = (char)255;
            }
        }
        private void IncrementPointer()
        {
            pointer++;
            if (pointer > memoryAmount - 1)
            { 
                pointer = 0;
            }
        }
        private void DecrementPoitner()
        {
            pointer--;
            if (pointer < 0)
            { 
                pointer = memoryAmount - 1;
            }
        }
        private void Print()
        {
            outputWindow.Text = outputWindow.Text + memory[pointer]; 
        }
        private void SaveIntoHelp()
        {
            helpVariable = memory[pointer];
            labelHelp.Content = "Help variable value: " + (int)helpVariable; 
        }
        private void LoadFromHelp()
        {
            memory[pointer] = helpVariable;
        }


        private void GetInput()
        {
            char inputChar = (char)0;

            //Creates an input popup window
            var popup = new InputPopup();
            if (popup.ShowDialog() == true)
            {
                inputChar = popup.InputText[0];
            }

            memory[pointer] = inputChar;

        }

        /// <summary>
        /// Resets every variable needed for a correct runtime of a brainfuck program
        /// </summary>
        private void Reset()
        {
            for(int i = 0; i < memoryAmount; i++)
            {
                memory[i] = (char)0;
            }
            pointer = 0;
            programCounter = 0;
            helpVariable = (char)0;
            isDebug = false;
            isBreak = false;
            isFinished = false;

            outputWindow.Text = "OUTPUT:";
            labelHelp.Content = "Help variable value: 0";
            labelIsDebug.Content = "Is in debug: false";
            labelIsBreak.Content = "On breakpoint: false";
        }

        /// <summary>
        /// Starts excetuting the brainfuck code
        /// </summary>
        /// <param name="code">Gib code</param>
        public void Start(string code, bool isDebug)
        {
            Reset(); // Reset everything
            this.isDebug = isDebug;
            if (isDebug)
            {
                labelIsDebug.Content = "Is in debug: true";
            }

            RemoveShitFromCode(code);
            if (!IsCodeCorrect())
            {
                MessageBox.Show("Your code is incorect. Check while brackets");
            }
            else
            {
                MainLoop();
            }
        }

        private void RemoveShitFromCode(string code)
        {
            //Remove escape characters n shit from code
            this.code = code;
            this.code = code.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
        }

        public bool IsCodeCorrect()
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
        private void WhileStart()
        {
            //If current memory value is zero -> skip to the end of a cycle. It's kinda like an if statement
            if(memory[pointer] == (char) 0)
            {
                while(code[programCounter] != ']')
                {
                    programCounter++;
                }
            }            
        }

        /// <summary>
        /// Checks if the cycle should repeat or not and returns an index where the code should continue
        /// it doesn't actually execute any code. It just returns a position where
        /// the program should continue
        /// </summary>        
        /// <param name="code">Brainfuck code</param>
        private void WhileEnd()
        {
            if (memory[pointer] != 0)
            {
                int skipParenthesis = -1;
                
                //There could be more while cycles inside a while cycle
                //This makes sure to return to the correct while start
                while (!(skipParenthesis == 0 && code[programCounter] == '['))
                {
                    
                    if (code[programCounter] == ']')
                    {
                        skipParenthesis++;
                    }
                    if (code[programCounter] == '[')
                    {
                        skipParenthesis--;
                    }

                    programCounter--;
                }
            }
        }

        private void IncrementProgramCounter()
        {
            programCounter++;
            if (programCounter == code.Length)
            { 
                //programCounter--;
                isFinished = true;
            }
        }

        private void MainLoop()
        {
            while (programCounter < code.Length && !isFinished)
            {
                DecodeInstruction();
                IncrementProgramCounter();
                if(isBreak)
                {
                    break;
                }
            }
        }

        public void DoStep()
        {
            if (!isFinished)
            {
                DecodeInstruction();
                IncrementProgramCounter();
            }
        }

        public void Continue()
        {
            //IncrementProgramCounter();
            isBreak = false;
            labelIsBreak.Content = "On breakpoint: false";
            MainLoop();
        }
        /// <summary>
        /// itarates every instruction and executes it
        /// </summary>
        /// <param name="code"></param>
        private void DecodeInstruction()
        {           
                switch(code[programCounter])
                {
                    case '+':
                        IncrementMemory();
                        break;
                    case '-':
                        DecrementMemory();
                        break;
                    case '>':
                        IncrementPointer();
                        break;
                    case '<':
                        DecrementPoitner();
                        break;
                    case '.': 
                        Print();
                        break;
                    case ',':
                        GetInput();
                        break;
                    case '[':
                        WhileStart();
                        break;
                    case ']':
                        WhileEnd();
                        break;
                    case '$':
                        SaveIntoHelp();
                        break;
                    case '!':
                        LoadFromHelp();
                        break;
                    case '@': //Breakpoint symbol. Only used in a debug mode
                        if(isDebug)
                        {
                            isBreak = true;
                            labelIsBreak.Content = "On breakpoint: true";
                        }
                        break;
                    default: //Everything else is seen as a comment and is ignored
                        break;
                }
        }

      
}
}
