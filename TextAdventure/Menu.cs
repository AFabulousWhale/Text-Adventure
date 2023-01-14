using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Media;
using System.IO;
using System.Linq;


namespace TextAdventure
{
    class Menu
    {
        private int selectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            selectedIndex = 0;
        }

        //print out current options for the menu that are in the array
        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                //for each selected option make it green
                if (i == selectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.Gray;
                }
                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        public int PlayerInput()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey();
                keyPressed = keyInfo.Key;

                // Update SelectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if(selectedIndex == -1)
                    {
                        selectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == Options.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }


    }


}
