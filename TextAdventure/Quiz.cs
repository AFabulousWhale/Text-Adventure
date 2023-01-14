using System;
using System.Collections.Generic;
using System.Text;
using Pastel;
using Color = System.Drawing.Color;
using System.IO;
using static System.Console;
using System.Linq;
using System.Reflection;

namespace TextAdventure
{
    class Quiz
    {
        public static int questionNumber = 1;
        public static Program Main = new Program();
        public static int[] questionAsked = { };
        public static int question;

        public static void QuizMain(string prompt)
        {
            Program Main = new Program();

            Music_SFX.QuizMusic();
            Console.WriteLine(prompt);
            Main.PrintText($"“Hello and welcome to my quiz show!”");
            System.Threading.Thread.Sleep(1000);
            Main.PrintText($"“You will have a series of 5 questions to answer about your journey today - get one wrong and you shall have to start again!”");
            System.Threading.Thread.Sleep(1000);
            Main.PrintText($"“If you complete the quiz correctly you will recieve the {"Horn of Doom".Pastel(Color.Yellow)} and access to the castle!!”");
            Questions(prompt);
        }

        //each question, every time this is called the question number goes up until it is 5
        public static void Questions(string prompt)
        {
            Clear();
            if (questionNumber <= 5)
            {
                WriteLine(prompt);
                Main.PrintText($"“Question {questionNumber}:”");
                questionNumber++;
                RandomQuestions(prompt);
            }
            else
            {
                //if you got the 5th question correct then you get the last item and can enter the castle
                SaveVariables.Conditions = SaveVariables.Conditions.Append("Quiz").ToArray();
                Main.SaveGame(SaveVariables.Conditions, SaveVariables.itemVal, SaveVariables.Description, SaveVariables.deaths, SaveVariables.playerName, SaveVariables.playerHealth, SaveVariables.lastClass, SaveVariables.currentWeapon, SaveVariables.weaponVal, SaveVariables.currentArmour, SaveVariables.armourVal, SaveVariables.money, SaveVariables.healingItems, SaveVariables.itemsObtained, SaveVariables.allWeapons, SaveVariables.allArmour, SaveVariables.healVal, SaveVariables.itemAmount);
                WriteLine(prompt);
                Main.PrintText($"“Congrats {SaveVariables.playerName.Pastel(Color.Cyan)}! You got every question correct! :D”");
                Main.PrintText($"“Here take the {"Horn of Doom".Pastel(Color.Yellow)} and be on your way!!”");
                SaveVariables.itemAmount++;
                Main.PrintText($"YOU NOW HAVE {SaveVariables.itemAmount}/3 ITEMS FROM GOTHESEME'S LIST".Pastel(Color.HotPink));
                SaveVariables.itemsObtained = SaveVariables.itemsObtained.Append("Horn of Doom").ToArray();
                Clear();
                Castle.CastleStart();
            }
        }

        //every time a question is wrong you have to restart the quiz
        public static void Wrong(string prompt)
        {
            questionAsked = questionAsked.Append(question).ToArray();
            Clear();
            WriteLine(prompt);
            Main.PrintText($"“Oops sorry {SaveVariables.playerName.Pastel(Color.Cyan)}, You got it wrong! Come back and try again! :)”");
            Array.Clear(questionAsked, 0, questionAsked.Length);
            System.Threading.Thread.Sleep(1000);
            Clear();
            string prompt2 = "What would you like to do?";
            string[] options = { "Try again!", "Go back!" };
            Menu mainMenu = new Menu(prompt2, options);
            int selectedIndex = mainMenu.PlayerInput();

            switch (selectedIndex)
            {
                case 0:
                    Main.PrintText("You decided to give the quiz another shot!");
                    System.Threading.Thread.Sleep(1000);
                    questionNumber = 1;
                    Questions(prompt);
                    break;
                case 1:
                    Main.PrintText("You decided to head back to the three pathways!");
                    System.Threading.Thread.Sleep(1000);
                    questionNumber = 1;
                    Clear();
                    LoadArea.load();
                    break;
            }
        }

        //if the question is correct then you progress to the next one
        public static void Right(string prompt)
        {
            questionAsked = questionAsked.Append(question).ToArray(); //adds that question to the array so it can't be asked again
            Main.PrintText($"“Wow {SaveVariables.playerName.Pastel(Color.Cyan)} You got that correct! Good job!! :D”");
            System.Threading.Thread.Sleep(1000);
            Questions(prompt);
        }

        //picks a random number between 1 and 8 and if it hasn't already been asked then it is asked
        public static void RandomQuestions(string prompt)
        {
            Random random = new System.Random();
            question = random.Next(1, 9);
            if (question == 1 && !questionAsked.Contains(1))
            {
                Main.PrintText("“What is the Name of the Shop Cat?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Rezelle", "Rolo", "Resell", "Marshmallow" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Right(prompt);
                        break;
                    case 1:
                        Wrong(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }
            }
            if (question == 2 && !questionAsked.Contains(2))
            {
                Main.PrintText("“What animal is not at the bar?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Bear", "Cow", "Rabbit", "Horse" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wrong(prompt);
                        break;
                    case 1:
                        Wrong(prompt);
                        break;
                    case 2:
                        Right(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }
            }
            if (question == 3 && !questionAsked.Contains(3))
            {
                Main.PrintText("“What is not an item on Gothesme's list?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Horn of Doom", "Shield of Death", "Thunder Gauntlet", "Fate's Lamp" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wrong(prompt);
                        break;
                    case 1:
                        Right(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }
            }

            if (question == 4 && !questionAsked.Contains(4))
            {
                Main.PrintText("“What item does the cow give you?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "The Dead Dragon's Shield", "Hammer of Swiftness", "Unravel Ice Ring", "Chestplate of Distress" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wrong(prompt);
                        break;
                    case 1:
                        Wrong(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Right(prompt);
                        break;
                }
            }
            if (question == 5 && !questionAsked.Contains(5))
            {
                Main.PrintText("“What item do you need for your final potion?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Cylinder of Rebirth", "Spear of Respiration", "Gloves of Peace", "Pegasus Gingerbread" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Right(prompt);
                        break;
                    case 1:
                        Wrong(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }
            }
            if (question == 6 && !questionAsked.Contains(6))
            {
                Main.PrintText("“How did you get to this world?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Portal", "World Travelling Wand", "Car", "No idea" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wrong(prompt);
                        break;
                    case 1:
                        Right(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }
            }
            if (question == 7 && !questionAsked.Contains(7))
            {
                Main.PrintText("“What is not a dog name”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Blade", "Bee", "Beau" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wrong(prompt);
                        break;
                    case 1:
                        Right(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                }
            }
            if (question == 8 && !questionAsked.Contains(8))
            {
                Main.PrintText("“Where do you find the elephant?”");
                System.Threading.Thread.Sleep(3000);
                string[] options = { "Bar", "Shop", "House", "Dungeon" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Right(prompt);
                        break;
                    case 1:
                        Wrong(prompt);
                        break;
                    case 2:
                        Wrong(prompt);
                        break;
                    case 3:
                        Wrong(prompt);
                        break;
                }

            }

        }
    }
}
