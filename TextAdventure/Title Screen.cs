using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Drawing;
using static System.Console;
using Figgle;
using Pastel;
using Color = System.Drawing.Color;
using System.Media;

namespace TextAdventure
{
    class Title_Screen
    {
        Program Main = new Program();
        Intro intro = new Intro();

        string previousName;

        public static int titleScreen;

        //displays the options for the title screen
        public void LoadMainMenu()
        {
            SaveVariables.SeperateList(null);
            string prompt = @"         _____                    _____                _____                    _____                    _____                    _____                    _____                _____          
         /\    \                  /\    \              /\    \                  /\    \                  /\    \                  /\    \                  /\    \              /\    \         
        /::\    \                /::\    \            /::\    \                /::\    \                /::\    \                /::\    \                /::\    \            /::\    \        
       /::::\    \              /::::\    \           \:::\    \              /::::\    \              /::::\    \              /::::\    \              /::::\    \           \:::\    \       
      /::::::\    \            /::::::\    \           \:::\    \            /::::::\    \            /::::::\    \            /::::::\    \            /::::::\    \           \:::\    \      
     /:::/\:::\    \          /:::/\:::\    \           \:::\    \          /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \           \:::\    \     
    /:::/__\:::\    \        /:::/__\:::\    \           \:::\    \        /:::/__\:::\    \        /:::/__\:::\    \        /:::/__\:::\    \        /:::/  \:::\    \           \:::\    \    
   /::::\   \:::\    \      /::::\   \:::\    \          /::::\    \      /::::\   \:::\    \      /::::\   \:::\    \      /::::\   \:::\    \      /:::/    \:::\    \          /::::\    \   
  /::::::\   \:::\    \    /::::::\   \:::\    \        /::::::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \    /:::/    / \:::\    \        /::::::\    \  
 /:::/\:::\   \:::\    \  /:::/\:::\   \:::\____\      /:::/\:::\    \  /:::/\:::\   \:::\    \  /:::/\:::\   \:::\    \  /:::/\:::\   \:::\    \  /:::/    /   \:::\    \      /:::/\:::\    \ 
/:::/  \:::\   \:::\____\/:::/  \:::\   \:::|    |    /:::/  \:::\____\/:::/__\:::\   \:::\____\/:::/  \:::\   \:::\____\/:::/  \:::\   \:::\____\/:::/____/     \:::\____\    /:::/  \:::\____\
\::/    \:::\  /:::/    /\::/   |::::\  /:::|____|   /:::/    \::/    /\:::\   \:::\   \::/    /\::/    \:::\   \::/    /\::/    \:::\  /:::/    /\:::\    \      \::/    /   /:::/    \::/    /
 \/____/ \:::\/:::/    /  \/____|:::::\/:::/    /   /:::/    / \/____/  \:::\   \:::\   \/____/  \/____/ \:::\   \/____/  \/____/ \:::\/:::/    /  \:::\    \      \/____/   /:::/    / \/____/ 
          \::::::/    /         |:::::::::/    /   /:::/    /            \:::\   \:::\    \               \:::\    \               \::::::/    /    \:::\    \              /:::/    /          
           \::::/    /          |::|\::::/    /   /:::/    /              \:::\   \:::\____\               \:::\____\               \::::/    /      \:::\    \            /:::/    /           
           /:::/    /           |::| \::/____/    \::/    /                \:::\   \::/    /                \::/    /               /:::/    /        \:::\    \           \::/    /            
          /:::/    /            |::|  ~|           \/____/                  \:::\   \/____/                  \/____/               /:::/    /          \:::\    \           \/____/             
         /:::/    /             |::|   |                                     \:::\    \                                           /:::/    /            \:::\    \                              
        /:::/    /              \::|   |                                      \:::\____\                                         /:::/    /              \:::\____\                             
        \::/    /                \:|   |                                       \::/    /                                         \::/    /                \::/    /                             
         \/____/                  \|___|                                        \/____/                                           \/____/                  \/____/                              
                                                                                                                                                                                                
Welcome to Artefact! What would you like to do?
(Use arrow keys to cycle through the options and enter to select an option)";
            string[] options = { "Start Game", "Load Game", "Exit" };
            Menu Menu = new Menu(prompt, options);
            int selectedIndex = Menu.PlayerInput();

            //depending on your selected index for the main menu will depend on what output happens: 1 - start game, 2 - load game, 3 - exit game
            switch (selectedIndex)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    LoadGame();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        //start game but asks if you wish to delete save file if you already have one
        public void StartGame()
        {
            if (new FileInfo("SavedGame.txt").Length == 0) //if you don't have a save file already
            {
                Console.Clear();
                titleScreen = 1;
                previousName = Environment.UserName;
                SaveVariables.playerHealth = 100;
                intro.Start(previousName);
            }
            else if (new FileInfo("SavedGame.txt").Length != 0) //if you have a sace file
            {
               string prompt = ($@"Are you sure you would like to {"DELETE".Pastel(Color.Red)} your save file?");
                string[] options = { "Yes","No" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0: //if yes, clears every text file save
                        Console.WriteLine(FiggleFonts.Chunky.Render("DELETING SAVE").Pastel(Color.Red));
                        previousName = File.ReadLines("SavedGame.txt").Skip(3).First();
                        File.Create("Conditions.txt").Close();
                        Array.Clear(SaveVariables.Conditions, 0, SaveVariables.Conditions.Length);
                        File.Create("HealingItems.txt").Close();
                        Array.Clear(SaveVariables.healingItems, 0, SaveVariables.healingItems.Length);
                        File.Create("ObtainedItems.txt").Close();
                        Array.Clear(SaveVariables.itemsObtained, 0, SaveVariables.itemsObtained.Length);
                        File.Create("AllWeapons.txt").Close();
                        Array.Clear(SaveVariables.allWeapons, 0, SaveVariables.allWeapons.Length);
                        File.Create("AllArmour.txt").Close();
                        Array.Clear(SaveVariables.allArmour, 0, SaveVariables.allArmour.Length);
                        SaveVariables.currentArmour = null;
                        SaveVariables.currentWeapon = null;
                        SaveVariables.lastClass = 0;
                        SaveVariables.playerHealth = 100;
                        File.Create("SavedGame.txt").Close();
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        ResetColor();
                        titleScreen = 1;
                        intro.Start(previousName);
                        break;
                    case 1:
                        Clear();
                        LoadMainMenu();
                        break;
                }
            }
        }

        public void LoadGame()
        {
            if (new FileInfo("SavedGame.txt").Length != 0) //if you have a save already
            {
                Clear();
                Console.WriteLine(FiggleFonts.Chunky.Render("LOADING SAVE").Pastel(Color.Green));
                System.Threading.Thread.Sleep(2000);
                titleScreen = 0;
                Main.LoadGame();
            }
            else if (new FileInfo("SavedGame.txt").Length == 0) //if you don't have a save it sends you back to main menu
            {
                Clear();
                Console.WriteLine($"Looks like you don't have a {"SAVE FILE".Pastel(Color.Green)}");
                ResetColor();
                Console.WriteLine("Press Any key to return to the main menu...");
                Console.ReadKey(true);
                LoadMainMenu();

            }
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
