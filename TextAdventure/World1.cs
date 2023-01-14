using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Pastel;
using Color = System.Drawing.Color;
using Figgle;
using System.Linq;
using System.Media;
using System.Diagnostics;
using System.IO;

namespace TextAdventure
{
        class World1
        {
            static Program Main = new Program();
            Inventory_system inventory = new Inventory_system();

        //this is the main description of the new world that gets called when you first start the game and make your way through the portal
            public void World1Start()
            {
                Music_SFX.World1Music();
                Main.PrintText("After stepping through the portal, you found yourself in a completely new world");
                Main.PrintText($"Around you appeared to be a lot of open land and nature");
                Main.PrintText($"The trees looked a lovely pale {"pink".Pastel("FD94BA")} swaying under the {"baby blue".Pastel("90D7FF")} sky!");
                Main.PrintText($"There also appeared to be a stunning {"harsh blue".Pastel("2660A4")} lake right in front of your feet");
                Main.PrintText($"You begin to cross the bridge over the lake and after walking in the same direction for about 5 minutes you came accross three path ways");
                Main.PrintText($"On your {"Left".Pastel(Color.Yellow)}, appears to be a bar of some kind. On your {"Right".Pastel(Color.Yellow)}, appears to be a giant castle and {"Forwards".Pastel(Color.Yellow)}, seems to be a long pathway that feels pretty endless.");
                W1Choice1();

            }

            //this is the first choice you are encountered with and essentially the main choice of the game - choosing the 3 pathways (you will come back to this 
            public static void W1Choice1()
            {
                Inventory_system inventory = new Inventory_system();
                SaveVariables.lastClass = 11;
                Main.RandomChance();
                Main.PrintText($"Where would you like to go? {"Left".Pastel(Color.Yellow)}, {"Right".Pastel(Color.Yellow)} or {"Forward".Pastel(Color.Yellow)}");
                Main.PrintText($"(you can also open your {"Inventory".Pastel(Color.Yellow)}, {"Save".Pastel(Color.Yellow)}, {"Load".Pastel(Color.Yellow)} your last save or {"Exit".Pastel(Color.Yellow)} the game)");
                Main.playerResponse = ReadLine().ToLower();

            //using a case for playerresponse so if the player types something similar such as forwards instead of forward it still does the same output
            switch (Main.playerResponse)
                {
                    case "forward":
                    case "forwards":
                    case "up":
                    case "straight":
                    case "straight ahead":
                        {
                            Forward forwardClass = new Forward();
                            forwardClass.Forward1();
                            break;
                        }
                    case "left":
                        {
                            Left leftClass = new Left();
                            leftClass.Left1();
                            break;
                        }
                    case "right":
                        {
                            Right rightClass = new Right();
                            rightClass.Right1();
                            break;
                        }
                    case "open inventory":
                    case "inventory":
                    case "inven":
                        {
                            inventory.InventoryMain();
                            W1Choice1();
                            break;
                        }
                    case "save":
                        Main.SaveGame(SaveVariables.Conditions, SaveVariables.itemVal, SaveVariables.Description, SaveVariables.deaths, SaveVariables.playerName, SaveVariables.playerHealth, SaveVariables.lastClass, SaveVariables.currentWeapon, SaveVariables.weaponVal, SaveVariables.currentArmour, SaveVariables.armourVal, SaveVariables.money, SaveVariables.healingItems, SaveVariables.itemsObtained, SaveVariables.allWeapons, SaveVariables.allArmour, SaveVariables.healVal, SaveVariables.itemAmount);
                        Main.PrintText("The game is now saved!".Pastel(Color.Green));
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        W1Choice1();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case "load":
                    if (SaveVariables.lastClass == 0)
                    {
                        Main.PrintText("You have no current save!");
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        W1Choice1();
                    }
                    else
                    {
                        Main.PrintText("Loading last area...".Pastel(Color.Green));
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        Main.LoadGame();
                    }
                        break;
                    default:
                        Main.ComputerResponse();
                        W1Choice1();
                        break;
                }
            }

        //this class holds all the outcomes of taking the forward route.
            public class Forward
            {
                Program Main = new Program();
                Inventory_system inventory = new Inventory_system();
                Random random = new System.Random();

            //this is the main forwards class - doing the descriptions when you decide to go this way
            public void Forward1()
            {
                Clear();
                Character_Dialoge.Rezelle rezelle = new Character_Dialoge.Rezelle();
                //detects if the array conntails "World1Forwards" to see if you've already been this way once so it doesn't do the full description every time
                if(SaveVariables.Conditions.Contains("W1F"))
                {
                    Main.PrintText("You decide that heading back to Rezelle's store was the best way to go");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    World1.Forward.F1Choice1();
                }
                if (!SaveVariables.Conditions.Contains("W1F"))
                {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("W1F").ToArray();
                    Main.PrintText("You decide that going forward would be the best option; as you have been going that way for a while now.");
                    Main.PrintText("As you continue walking the area around you started to become, almost spooky like");
                    Main.PrintText("The air became foggy, and you could barely see where you were going");
                    Main.PrintText("After a while you spot a bright light shining in the distance and decided to head towards it!");
                    Main.PrintText("As you walk closer to the light, the fog begins to fade and around you appears to be many stalls of different kinds, however, there seems to be no-one around");
                    Main.PrintText("All excpet one stall, the stall with the light - There appears to be a cat sitting behind it...");
                    Console.WriteLine("Press any key to continue...");
                    SaveVariables.lastClass = 12;
                    Console.ReadKey(true);
                    rezelle.RezelleStart();
                }

            }

            //after leaving the first shop (so you get an idea of what you can do there) you are brought here:
            //this is the main choice area from going forwards
            public static void F1Choice1()
            {
                Character_Dialoge.Rezelle rezelle = new Character_Dialoge.Rezelle();
                Program Main = new Program();
                Inventory_system inventory = new Inventory_system();
                Battle_System battle = new Battle_System();
                SaveVariables.lastClass = 12;
                Main.RandomChance();
                Main.PrintText($"“I can either, investigate the other {"stalls".Pastel(Color.Yellow)}, go back inside the {"shop".Pastel(Color.Yellow)}, continue going {"forwards".Pastel(Color.Yellow)} or go {"back".Pastel(Color.Yellow)} the way I came”");
                Main.PrintText($"(you can also open your {"Inventory".Pastel(Color.Yellow)}, {"Save".Pastel(Color.Yellow)}, {"Load".Pastel(Color.Yellow)} your last save or {"Exit".Pastel(Color.Yellow)} the game)");
                Main.PrintText("What would you like to do?");
                Main.playerResponse = ReadLine().ToLower();

                switch (Main.playerResponse)
                {
                    case "investigate":
                    case "investigate stalls":
                    case "investigate the stalls":
                    case "stalls":
                    case "the stalls":
                        {
                            if (!SaveVariables.Conditions.Contains("stalls"))
                            {
                                Main.PrintText("You decice to investigate the other stalls near by as they seem pretty abandoned.");
                                Main.PrintText("As you came closer to a nearby stall you notice a tiny abandoned kitten, who appears to be scared");
                                WriteLine("Press any key to continue...");
                                ReadKey(true);
                                Music_SFX.BattleMusic();
                                Clear();
                                battle.BattleMain("A scared kitten", 100, @"                  ████████████████                            
              ████░░░░░░░░░░░░░░░░████                        
██████████████░░░░░░░░░░░░░░░░░░░░░░░░████████████            
██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            
██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            
  ██▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓██              
  ██▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓██              
    ██▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓██                
      ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                  
      ██░░░░░░████░░░░░░░░░░░░░░████░░░░░░██                  
      ██░░░░██  ▒▒██░░░░░░░░░░██  ▒▒██░░░░██                  
      ██░░░░██▒▒▒▒██░░░░░░░░░░██▒▒▒▒██░░░░██                  
        ██░░░░████░░░░░░░░░░░░░░████░░░░██                    
        ██░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░██                    
    ▓▓▓▓▓▓██░░░░▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓░░░░██                      
  ▓▓▒▒▒▒▒▒▓▓██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██                        
  ▓▓▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▒▒▓▓██                      
    ▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓██                    
  ▓▓▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▒▒▓▓░░░░██        ██████    
  ▓▓▒▒▒▒▒▒▓▓  ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓░░░░░░██        ██▓▓▓▓██  
    ▓▓▓▓▓▓    ██▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓░░░░░░░░░░██        ██▓▓▓▓██
              ██░░░░▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░██        ██▓▓▓▓██
                ██░░░░░░░░░░░░░░██░░░░░░░░░░██        ██░░▓▓██
                ██░░░░░░██░░░░░░██░░░░░░░░░░██      ██░░░░░░██
                ██░░░░░░██░░░░░░██░░░░░░░░░░██      ██░░░░██  
                ██░░░░░░██░░░░░░██░░░░░░░░░░██    ██░░░░░░██  
                  ██░░░░██░░░░██░░░░░░░░░░░░██████░░░░░░██    
                  ██░░░░██░░░░██░░░░░░░░░░░░░░░░░░░░████      
                  ██░░░░██░░░░██░░░░░░░░░░░░████████          
                    ████  ██████████████████                  
Scared Cat:");
                            }
                            if (SaveVariables.Conditions.Contains("stalls"))
                            {
                                if(SaveVariables.Conditions.Contains("stallKill"))
                                {
                                    Clear();
                                    Main.PrintText("There is nothing else here...");
                                    System.Threading.Thread.Sleep(2000);
                                    Clear();
                                    F1Choice1();
                                }
                                else if (SaveVariables.Conditions.Contains("stallFlee"))
                                {
                                    Clear();
                                    WriteLine(@"                  ████████████████                            
              ████░░░░░░░░░░░░░░░░████                        
██████████████░░░░░░░░░░░░░░░░░░░░░░░░████████████            
██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            
██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            
  ██▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓██              
  ██▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓██              
    ██▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓██                
      ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██                  
      ██░░░░░░████░░░░░░░░░░░░░░████░░░░░░██                  
      ██░░░░██  ▒▒██░░░░░░░░░░██  ▒▒██░░░░██                  
      ██░░░░██▒▒▒▒██░░░░░░░░░░██▒▒▒▒██░░░░██                  
        ██░░░░████░░░░░░░░░░░░░░████░░░░██                    
        ██░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░██                    
    ▓▓▓▓▓▓██░░░░▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓░░░░██                      
  ▓▓▒▒▒▒▒▒▓▓██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██                        
  ▓▓▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▒▒▓▓██                      
    ▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓██                    
  ▓▓▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▒▒▓▓░░░░██        ██████    
  ▓▓▒▒▒▒▒▒▓▓  ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓░░░░░░██        ██▓▓▓▓██  
    ▓▓▓▓▓▓    ██▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓░░░░░░░░░░██        ██▓▓▓▓██
              ██░░░░▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░██        ██▓▓▓▓██
                ██░░░░░░░░░░░░░░██░░░░░░░░░░██        ██░░▓▓██
                ██░░░░░░██░░░░░░██░░░░░░░░░░██      ██░░░░░░██
                ██░░░░░░██░░░░░░██░░░░░░░░░░██      ██░░░░██  
                ██░░░░░░██░░░░░░██░░░░░░░░░░██    ██░░░░░░██  
                  ██░░░░██░░░░██░░░░░░░░░░░░██████░░░░░░██    
                  ██░░░░██░░░░██░░░░░░░░░░░░░░░░░░░░████      
                  ██░░░░██░░░░██░░░░░░░░░░░░████████          
                    ████  ██████████████████                  
Scared Cat:");
                                    Main.PrintText("Thank you for not hurting me, you're the best!!");
                                    System.Threading.Thread.Sleep(2000);
                                    Clear();
                                    F1Choice1();
                                }
                            }
                            break;
                        }
                    case "shop":
                    case "inside":
                    case "back inside shop":
                    case "go back inside the shop":
                    case "back inside":
                    case "go back in":
                    case "go back inside":
                        {
                            Shop shop = new Shop();
                            Main.PrintText("You decided to go back inside to see Rezelle again!");
                            WriteLine("Press any key to continue...");
                            ReadKey(true);
                            rezelle.RezelleStart();
                            F1Choice1();
                            break;
                        }
                    case "forward":
                    case "forwards":
                    case "up":
                    case "straight":
                    case "straight ahead":
                        {
                            if (!SaveVariables.Conditions.Contains("dogs"))
                            {
                                Character_Dialoge.Dogs dogs = new Character_Dialoge.Dogs();
                                Main.PrintText("You decide that continuting to go forwards was the best option as you wanted to fully explore this pathway.");
                                Main.PrintText("After heading that direction for a while you come accross a dead end, however as you turn around two dogs approach you");
                                WriteLine("Press any key to continue...");
                                ReadKey(true);
                                dogs.DogMain();
                            }
                            else if (SaveVariables.Conditions.Contains("dogs"))
                            {
                                Character_Dialoge.Dogs dogs = new Character_Dialoge.Dogs();
                                if (SaveVariables.Conditions.Contains("dogsKill"))
                                {
                                    Main.PrintText("You decide to head back to where the dogs once where...");
                                    Main.PrintText("This place is now eerily quiet... after what you did...");
                                    Main.PrintText("All that is left is the dead end...");
                                }
                                else if (!SaveVariables.Conditions.Contains("dogsFlee"))
                                {
                                    Main.PrintText("You decide to head back to see Blade and Beau again!");
                                    Main.PrintText("As you walk past them to the dead end, you see them both happily playing together!");
                                }

                                if (!SaveVariables.Conditions.Contains("hole"))
                                {
                                    Main.PrintText("After further inspection of the dead end, you notice a small hole");
                                    WriteLine($"Investigate? {"Y/N".Pastel(Color.Yellow)}");
                                    Main.playerResponse = ReadLine().ToLower();
                                    switch (Main.playerResponse)
                                    {
                                        case "y":
                                            Random random = new System.Random();
                                            int moneyFound = random.Next(5, 15);
                                            SaveVariables.money += moneyFound;
                                            Main.PrintText($"You decided to investiagte the hole and happened to find {"$".Pastel(Color.Yellow) + moneyFound.ToString().Pastel(Color.Yellow)} - you now have {"$".Pastel(Color.Yellow) + SaveVariables.money.ToString().Pastel(Color.Yellow)}");
                                            break;
                                        case "n":
                                            Main.PrintText($"You decided to not investigate the hole as it appeared unnecessary");
                                            break;
                                    }
                                    SaveVariables.Conditions = SaveVariables.Conditions.Append("hole").ToArray();
                                }
        
                            }
                            Main.PrintText("As all that's left is the dead end, you decided to head back to Rezelle's shop to continue your journey...");
                            WriteLine("Press any key to continue...");
                            ReadKey(true);
                            Clear();
                            F1Choice1();
                            break;

                        }
                    case "go back":
                    case "backwards":
                    case "go back the way i came":
                    case "back":
                        {
                            Main.PrintText("You decided it was best to check the other routes, so you turned around and went back the way you came");
                            Main.PrintText("After a while you come back to the three pathways again and thought about which route to take next");
                            WriteLine("Press any key to continue...");
                            ReadKey(true);
                            Clear();
                            World1.W1Choice1();
                            break;
                        }
                    case "open inventory":
                    case "inventory":
                    case "inven":
                        {
                            inventory.InventoryMain();
                            F1Choice1();
                            break;
                        }
                    case "save":
                        Main.SaveGame(SaveVariables.Conditions, SaveVariables.itemVal, SaveVariables.Description, SaveVariables.deaths, SaveVariables.playerName, SaveVariables.playerHealth, SaveVariables.lastClass, SaveVariables.currentWeapon, SaveVariables.weaponVal, SaveVariables.currentArmour, SaveVariables.armourVal, SaveVariables.money, SaveVariables.healingItems, SaveVariables.itemsObtained, SaveVariables.allWeapons, SaveVariables.allArmour, SaveVariables.healVal, SaveVariables.itemAmount);
                        Main.PrintText("The game is now saved!".Pastel(Color.Green));
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        F1Choice1();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case "load":
                        if (SaveVariables.lastClass == 0)
                        {
                            Main.PrintText("You have no current save!");
                            System.Threading.Thread.Sleep(2000);
                            Clear();
                            F1Choice1();
                        }
                        else
                        {
                            Main.PrintText("Loading last area...".Pastel(Color.Green));
                            System.Threading.Thread.Sleep(2000);
                            Clear();
                            Main.LoadGame();
                        }
                        break;
                    default:
                        Main.ComputerResponse();
                        F1Choice1();
                        break;
                }
            }
        }


            public class Left
            {
            //if you decide to go left, to the bar
                Random random = new System.Random();
                public void Left1()
                {
                SaveVariables.lastClass = 13;
                Clear();
                if (SaveVariables.Conditions.Contains("W1L"))
                {
                    Main.PrintText("You decided to head back to the bar to see if there was anything that you had missed");
                }
                if (!SaveVariables.Conditions.Contains("W1L"))
                {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("W1L").ToArray();
                    Main.PrintText("You decided to head towards the bar looking place on your left");
                    Main.PrintText("As you start heading that direction you being to notice a lot of animals outside, they all appear to be socialising with each other and having a good time");
                    Main.PrintText("You decide to head inside the bar to see what was there, you were starting to feel a bit hungry.");
                    Main.PrintText($"As you swing the doors open to the bar you notice a {"bear".Pastel(Color.Yellow)} sitting alone eating some honey, a {"cow".Pastel(Color.Yellow)} who appears to be smoking in the corner, an {"elephant".Pastel(Color.Yellow)} who appears to be enjoying themselves and a {"horse".Pastel(Color.Yellow)} behind the counter");

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Music_SFX.BarMusic();
                Clear();
                LeftChoice1();
                }

            //the choice loop for when deciding who to speak too (bear, cow, elephant, horse)
                public static void LeftChoice1()
                {
                Inventory_system inventory = new Inventory_system();
                Character_Dialoge.Bar bar = new Character_Dialoge.Bar();
                LoadArea loadArea = new LoadArea();
                Main.RandomChance();
                Main.PrintText($"Who would you like to talk to? The {"bear".Pastel(Color.Yellow)}, the {"cow".Pastel(Color.Yellow)}, the {"elephant".Pastel(Color.Yellow)}, or the {"horse".Pastel(Color.Yellow)}? Or do you wish to go back {"outside".Pastel(Color.Yellow)}?");
                Main.PrintText($"(you can also open your {"Inventory".Pastel(Color.Yellow)}, {"Save".Pastel(Color.Yellow)}, {"Load".Pastel(Color.Yellow)} your last save or {"Exit".Pastel(Color.Yellow)} the game)");
                Main.playerResponse = ReadLine().ToLower();

                //I used a case for the player response as it saves lines than using an if statement for every outcome - I also converted the string to lower case so YOU CAN WRITE IN ALL CAPS IF YOU LIKE and it'll still detect the same thing
                switch (Main.playerResponse)
                {
                    case "bear":
                        Main.PrintText("You decided to head over to the bear");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Clear();
                        Character_Dialoge.Bar.Bear.BearMain();
                        break;
                    case "cow":
                        Main.PrintText("You decided to head over to the cow");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Clear();
                        Character_Dialoge.Bar.Cow.CowMain();
                        break;
                    case "elephant":
                        Main.PrintText("You decided to head over to the elephant");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Clear();
                        Character_Dialoge.Bar.Elephant.ElephantMain();
                        break;
                    case "horse":
                        Main.PrintText("You decided to head over to the counter to see the horse");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Clear();
                        bar.HorseMain();
                        break;
                    case "open inventory":
                    case "inventory":
                    case "inven":
                        {
                            inventory.InventoryMain();
                            LeftChoice1();
                            break;
                        }
                    case "outside":
                        {
                            Main.PrintText("You decided that there was nothing important left in the bar and went back outside towards the three pathways.");
                            WriteLine("Press any key to continue...");
                            ReadKey(true);
                            Clear();
                            Music_SFX.World1Music();
                            World1.W1Choice1();
                            break;
                        }
                    case "save":
                        Main.SaveGame(SaveVariables.Conditions, SaveVariables.itemVal, SaveVariables.Description, SaveVariables.deaths, SaveVariables.playerName, SaveVariables.playerHealth, SaveVariables.lastClass, SaveVariables.currentWeapon, SaveVariables.weaponVal, SaveVariables.currentArmour, SaveVariables.armourVal, SaveVariables.money, SaveVariables.healingItems, SaveVariables.itemsObtained, SaveVariables.allWeapons, SaveVariables.allArmour, SaveVariables.healVal, SaveVariables.itemAmount);
                        Main.PrintText("The game is now saved!".Pastel(Color.Green));
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                        LeftChoice1();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case "load":
                        if (SaveVariables.lastClass == 0)
                        {
                            Main.PrintText("You have no current save!");
                            System.Threading.Thread.Sleep(2000);
                            Clear();
                            LeftChoice1();
                        }
                        else
                        {
                            Main.PrintText("Loading last area...".Pastel(Color.Green));
                            System.Threading.Thread.Sleep(2000);
                            Clear();
                            Main.LoadGame();
                        }
                        break;
                    default:
                        Main.ComputerResponse();
                        LeftChoice1();
                        break;
                }


                }
            }

        //going to the castle
            public class Right
            {
                Program Main = new Program();
                Inventory_system inventory = new Inventory_system();
                Character_Dialoge.Guard frog = new Character_Dialoge.Guard();
                Random random = new System.Random();
                public void Right1()
                {
                //if you have already been to the castle, so you can skip the dialogue
                if (SaveVariables.Conditions.Contains("Castle"))
                {
                    Main.PrintText("You decided to make your way back towards the castle");
                }
                if (!SaveVariables.Conditions.Contains("Castle"))
                    {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("Castle").ToArray();
                    Main.PrintText("You decided to make your way over to the huge looking castle in the distance");
                    Main.PrintText("On your way, you see a lot of worried animals and multiple signs saying to turn back, yet you ignore every single one");
                    Main.PrintText("As you came closer to the entrance to the castle you notice a Frog who appears to be guarding the door");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    frog.GuardMain();
                }
            }
        }
    
}
