using System;
using System.Linq;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using static System.Console;
using System.Media;
using Pastel;
using Figgle;
using Color = System.Drawing.Color;
namespace TextAdventure
{
    class Program 
    {
        public int enemyHealth = 100;

        public string enemyType;

        public string playerResponse;
        public int randomResponse;
        public int randomEnemy;
        public int randomItem;
        public string itemToAdd;

        public Random random = new System.Random();

        //important info is in yellow

        //start description

        public static void Main(string[] args)
        {
            Music_SFX.MenuMusic();
            Console.SetWindowSize(LargestWindowWidth, LargestWindowHeight);
            Title_Screen mainMenu = new Title_Screen();
            Title = "Artefact";
            mainMenu.LoadMainMenu();
        }


        public void Death()
        {
            LoadArea loadArea = new LoadArea();
            Title_Screen menu = new Title_Screen();

            Music_SFX.DeathMusic();

            Console.WriteLine(FiggleFonts.FireFontK.Render("YOU DIED").Pastel(Color.Red));
            System.Threading.Thread.Sleep(3000);
            if (SaveVariables.lastClass == 14)
                SaveVariables.deaths++;

            string prompt = "Continue?";
            string[] options = { "Yes", "No" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            switch (selectedIndex)
            {
                case 0:
                    PrintText("Your head begins to hurt, as if something bad just happened, however you feel completely fine - apart from the over hanging feeling of Deja vu.");
                    PrintText("YOU WOKE UP AT YOUR LAST SAVE!".Pastel(Color.Yellow));
                    LoadGame();
                    break;
                case 1:
                    PrintText("You died, but did not wake up");
                    PrintText("YOU RETURNED TO THE MAIN MENU".Pastel(Color.Yellow));
                    Music_SFX.MenuMusic();
                    menu.LoadMainMenu();
                    break;
            }
        }

        //saves in order  deaths, name, health, lastclass, lastroom, weapon, weaponvalue, armour, armour value, money, healing items, items obtained, roomitems, all weapons, all armour
        public void SaveGame(string[] Conditions, int itemVal, string Description, int deaths, string playerName, int playerHealth, int lastClass, string weapon, int weaponVal, string armour, int armourVal, int money, string[] healingItems, string[] itemsObtained, string[] allWeapons, string[] allArmour, int healVal, int itemAmount)
        {
            TextWriter tw = new StreamWriter("SavedGame.txt");
            tw.WriteLine(itemVal);
            tw.WriteLine(Description);
            tw.WriteLine(deaths);
            tw.WriteLine(playerName);
            tw.WriteLine(playerHealth);
            tw.WriteLine(lastClass);
            tw.WriteLine(weapon);
            tw.WriteLine(weaponVal);
            tw.WriteLine(armour);
            tw.WriteLine(armourVal);
            tw.WriteLine(money);
            tw.WriteLine(itemAmount);

            if (Conditions != null)
                File.WriteAllLines("Conditions.txt", Conditions);
            if (healingItems != null)
                File.WriteAllLines("HealingItems.txt", healingItems);
            if (itemsObtained != null)
                File.WriteAllLines("ObtainedItems.txt", itemsObtained);
            if (allWeapons != null)
                File.WriteAllLines("AllWeapons.txt", allWeapons);
            if (allArmour != null)
                File.WriteAllLines("AllArmour.txt", allArmour);
            tw.Close();
        }

        //loads strings and converts them to correct variables as each thing in the text file is a string
        public void LoadGame()
        { 
            TextReader tr = new StreamReader("SavedGame.txt");

            string itemString = tr.ReadLine();
            SaveVariables.itemVal = Convert.ToInt32(itemString);

            SaveVariables.Description = tr.ReadLine();

            string deathString = tr.ReadLine();
            SaveVariables.deaths = Convert.ToInt32(deathString);

            SaveVariables.playerName = tr.ReadLine();

            string healthString = tr.ReadLine();
            SaveVariables.playerHealth = Convert.ToInt32(healthString);

            string classString = tr.ReadLine();
            SaveVariables.lastClass = Convert.ToInt32(classString);

            SaveVariables.currentWeapon = tr.ReadLine();

            string weaponString = tr.ReadLine();
            SaveVariables.weaponVal = Convert.ToInt32(weaponString);

            SaveVariables.currentArmour = tr.ReadLine();

            string armourString = tr.ReadLine();
            SaveVariables.armourVal = Convert.ToInt32(armourString);

            string moneyString = tr.ReadLine();
            SaveVariables.money = Convert.ToInt32(moneyString);

            string itemAString = tr.ReadLine();
            SaveVariables.itemAmount = Convert.ToInt32(itemAString);

            //for the arrays it gets the whole specific text file
            SaveVariables.Conditions = File.ReadAllLines("Conditions.txt");
            SaveVariables.healingItems = File.ReadAllLines("HealingItems.txt");
            SaveVariables.itemsObtained = File.ReadAllLines("ObtainedItems.txt");
            SaveVariables.allWeapons = File.ReadAllLines("AllWeapons.txt");
            SaveVariables.allArmour = File.ReadAllLines("AllArmour.txt");
            tr.Close();

            //if you load the game from the title screen it says this - so it doesn't do it every time you load within the game
           if(Title_Screen.titleScreen == 0)
            {
                Console.Clear();
                PrintText($"Welcome back {SaveVariables.playerName.Pastel(Color.Cyan)}! I hope you have a great time! :D ");
                Title_Screen.titleScreen++;
            }
            Console.Clear();
            Clear();
            LoadArea.load();
        }

        //this is called every time text is written within the artefact so that it prints out 1 character at a time
        public void PrintText(string text, int speed = 1)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);              
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);
        }

        //computer responses if player response doesn't match to what is expected
        public void ComputerResponse()
        {
            //generate a random response if you don't interact with said objects
            randomResponse = random.Next(1, 6);
            if (randomResponse == 1)
            {
                PrintText("You got distracted by your own feet and forgot what you were going to do.");
            }
            else if (randomResponse == 2)
            {
                PrintText("You felt your eyes droop shut and completely forgot what you thought about doing.");
            }
            else if (randomResponse == 3)
            {
                PrintText("Amazed by the area around you, you forgot what you were just thinking about.");
            }
            else if (randomResponse == 4)
            {
                PrintText("“Huh? I don’t understand, what does “" + playerResponse + "” mean???”");
            }
            else if (randomResponse == 5)
            {
                PrintText(playerResponse + "“ that sounds interesting, but I don't think it will help me here!”");
            }
        }

        //at each pathway there is a chance for you to find a random weapon, armour, healing item, money or to fight a random enemy
        public void RandomChance()
        {
            randomItem = random.Next(1,21);
            switch (randomItem)
            {
                case 1:
                    RandomEnemy();
                    break;
                case 2:
                    RandomItem("Weapon");
                    break;
                case 3:
                    RandomItem("Food");
                    break;
                case 4:
                    RandomItem("Armour");
                    break;
                case 5:
                    RandomItem("Money");
                    break;
            }
        }

        //picks a random enemy for you to fight
        public void RandomEnemy()
        {
            Battle_System battle = new Battle_System();
            randomEnemy = random.Next(1, 6);

            switch(randomEnemy)
            {
                case 1:
                    Music_SFX.BattleMusic();
                    battle.BattleMain("A Platypus", 100, @"
            _.- ~~^^^'~- _ __ .,.- ~ ~ ~  ~  -. _
 ________,'       ::.                       _,-  ~ -.
((      ~_\   -s-  ::                     ,'          ;,
 \\       <.._ .;;;`                     ;           }  `',
  ``======='    _ _- _ (   }             `,          ,'\,  `,
               ((/ _ _,i   ! _ ~ - -- - _ _'_-_,_,,,'    \,  ;
                ((((____/            (,(,(, ____>        \,'
A Platypus:");
                    break;
                case 2:
                    Music_SFX.BattleMusic();
                    battle.BattleMain("An Armadillo", 100, @"
       ,.-----__    
          ,:::://///,:::-. 
         /:''/////// ``:::`;/|/
        /'   ||||||     :://'`\
      .' ,   ||||||     `/(  e \
-===~__-'\__X_`````\_____/~`-._ `.
            ~~        ~~       `~-'
An Armadillo:");
                    break;
                case 3:
                    Music_SFX.BattleMusic();
                    battle.BattleMain("A Hippo", 100, @"
       c~~p ,---------. 
 ,---'oo  )           \
( O O                  )/
 `=^='                 /
       \    ,     .   /
       \\  |-----'|  /
       ||__|    |_|__|
A Hippo:");
                    break;
                case 4:
                    Music_SFX.BattleMusic();
                    battle.BattleMain("A Fox", 100, @"
   /|_/|
  / ^ ^(_o
 /    __.'
 /     \
(_) (_) '._
  '.__     '. .-''-'.
     ( '.   ('.____.''
     _) )'_, )mrf
    (__/ (__/
A Fox:");
                    break;
                case 5:
                    Music_SFX.BattleMusic();
                    battle.BattleMain("A Hamster", 100, @"
     (>\---/<)
     ,'     `.
    /  q   p  \
   (  >(_Y_)<  )
    >-' `-' `-<-.
   /  _.== ,=.,- \
  /,    )`  '(    )
 ; `._.'      `--<
:     \        |  )
\      )       ;_/ 
 `._ _/_  ___.'-\\\
    `--\\\
A Hamster:");
                    break;
            }
        }

        //gets the array which contains every item possible and selects a random one to display and add to the players inventory
        public void RandomItem(string itemType)
        {

            if(itemType == "Weapon")
            {
                if (SaveVariables.allWeapons.Contains(itemToAdd) && SaveVariables.weaponsToBuy.Contains(itemToAdd))
                {
                    itemToAdd = SaveVariables.everyWeapon[random.Next(0, SaveVariables.everyWeapon.Length + 1)];
                    ItemCollection(itemToAdd, itemType);
                }
            }
            else if (itemType == "Food")
            {
                itemToAdd = SaveVariables.everyHeal[random.Next(0, SaveVariables.everyHeal.Length + 1)];
                ItemCollection(itemToAdd, itemType);
                
            }
            else if (itemType == "Armour")
            {
                if (SaveVariables.allArmour.Contains(itemToAdd) && SaveVariables.armourToBuy.Contains(itemToAdd))
                {
                    itemToAdd = SaveVariables.everyArmour[random.Next(0, SaveVariables.everyArmour.Length + 1)];
                    ItemCollection(itemToAdd, itemType);
                }
            }
            else if (itemType == "Money")
            {
                int randomMoney = random.Next(15, 30);
                PrintText($"Wow you happened to find ${randomMoney}! :o");
                SaveVariables.money += randomMoney;
                PrintText($"You now have ${SaveVariables.money}".Pastel(Color.Yellow));
            }
        }

        //adds picked up item to selected array
        public void ItemCollection(string itemToAdd, string itemType)
        {
            if (itemType == "Weapon")
                SaveVariables.allWeapons = SaveVariables.allWeapons.Append(itemToAdd).ToArray();
            else if (itemType == "Food")
                SaveVariables.healingItems = SaveVariables.healingItems.Append(itemToAdd).ToArray();
            else if (itemType == "Armour")
                SaveVariables.allArmour = SaveVariables.allArmour.Append(itemToAdd).ToArray();
            PrintText($"Wow! You happened to find a {itemToAdd.Pastel(Color.Yellow)} - (It appears to be {itemType.Pastel(Color.Yellow)}) lying on the ground, you decided to pick it up and add it to your backpack");
            
        }

        public void Credits()
        {
            Clear();
            Music_SFX.CreditsMusic();
            PrintText($"Coding by {"Mary Montgomery".Pastel(Color.Cyan)}");
            PrintText($"Bear Ascii art: {"Bear with a honey pot by Morfina".Pastel(Color.Cyan)} {"(https://www.asciiart.eu/animals/bears)".Pastel(Color.Green)}");
            PrintText($"Horse Ascii art: {"(https://www.asciiart.eu/animals/horses)".Pastel(Color.Green)}");
            PrintText($"Shop cat Ascii art: {"(https://asciiart.website/index.php?art=animals/cats)".Pastel(Color.Green)}");
            PrintText($"Scared cat Ascii art: {"(https://textart.sh/topic/cat)".Pastel(Color.Green)}");
            PrintText($"Dogs Ascii art: {"Noodles and Ralph".Pastel(Color.Cyan)} {"(https://www.asciiart.eu/animals/dogs)".Pastel(Color.Green)}");
            PrintText($"Elephant Ascii art: {"Art by Morfina".Pastel(Color.Cyan)} {"(https://www.asciiart.eu/animals/elephants)".Pastel(Color.Green)}");
            PrintText($"Cow Ascii art: {"Art by John Eidson".Pastel(Color.Cyan)} {"(https://www.asciiart.eu/animals/cows)".Pastel(Color.Green)}");
            PrintText($"Gothesme Ascii art: {"(https://www.asciiart.eu/people/faces)".Pastel(Color.Green)}");
            PrintText($"Frog Ascii art: {"(https://www.asciiart.eu/animals/frogs)".Pastel(Color.Green)}");
            PrintText($"Shop Music: {"Talking Cute Chiptune".Pastel(Color.Cyan)} {"(https://opengameart.org/content/talking-cute-chiptune)".Pastel(Color.Green)}");
            PrintText($"Battle Music: {"boss battle 2-8".Pastel(Color.Cyan)} {"(https://opengameart.org/content/boss-battle-2-8-bit)".Pastel(Color.Green)}");
            PrintText($"Dog Fight Music: {"Puppy Playing In the Garden".Pastel(Color.Cyan)} {"(https://opengameart.org/content/puppy-playing-in-the-garden-sms-port)".Pastel(Color.Green)}");
            PrintText($"Horse Shop Music: {"Karma 8-bit".Pastel(Color.Cyan)} {"(https://opengameart.org/content/karma8-bit)".Pastel(Color.Green)}");
            PrintText($"Dog Main Music: {"Doggys Floppy Ears".Pastel(Color.Cyan)} {"(https://opengameart.org/content/doggys-floppy-ears)".Pastel(Color.Green)}");
            PrintText($"World Main Music: {"Good Mood Theme 8-bit".Pastel(Color.Cyan)} {"(https://opengameart.org/content/good-mood-theme-8-bit)".Pastel(Color.Green)}");
            PrintText($"Gothesme Music: {"Happy Accident".Pastel(Color.Cyan)} {"(https://opengameart.org/content/happy-accident)".Pastel(Color.Green)}");
            PrintText($"Quiz Music: {"In The Jungle City".Pastel(Color.Cyan)} {"(https://opengameart.org/content/in-the-jungle-city)".Pastel(Color.Green)}");
            PrintText($"Castle Music: {"8-bit Chiptune Autumn Colors".Pastel(Color.Cyan)} {"(https://opengameart.org/content/8-bit-chiptune-autumn-colors)".Pastel(Color.Green)}");
            PrintText($"Bar Music: {"Red Heels".Pastel(Color.Cyan)} {"(https://opengameart.org/content/red-heels-0)".Pastel(Color.Green)}");
            PrintText($"Credits Music: {"Guinea Pig Hero".Pastel(Color.Cyan)} {"(https://opengameart.org/content/guinea-pig-hero)".Pastel(Color.Green)}");
            PrintText($"Intro Music: {"My Street".Pastel(Color.Cyan)} {"(https://opengameart.org/content/my-street)".Pastel(Color.Green)}");
            PrintText($"Death Music: {"8-Bit Nostalgia".Pastel(Color.Cyan)} {"(https://www.fesliyanstudios.com/royalty-free-music/downloads-c/8-bit-music/6)".Pastel(Color.Green)}");
            PrintText($"Gothesme Fight Music: {"Boss Time".Pastel(Color.Cyan)} {"(https://www.fesliyanstudios.com/royalty-free-music/downloads-c/8-bit-music/6)".Pastel(Color.Green)}");
            PrintText($"Menu Music: {"8-Bit Menu".Pastel(Color.Cyan)} {"(https://www.fesliyanstudios.com/royalty-free-music/downloads-c/8-bit-music/6)".Pastel(Color.Green)}");
            PrintText($"Platypus Ascii art: {"(https://www.asciiart.eu/animals/other-water)".Pastel(Color.Green)}");
            PrintText($"Armadillo Ascii art: {"(https://www.asciiart.eu/animals/other-land)".Pastel(Color.Green)}");
            PrintText($"Hippo Ascii art: {"(https://www.asciiart.eu/animals/other-land)".Pastel(Color.Green)}");
            PrintText($"Hamster Ascii art: {"(https://www.asciiart.eu/animals/other-land)".Pastel(Color.Green)}");
            PrintText($"Fox Ascii art: {"(https://www.asciiart.eu/animals/other-land)".Pastel(Color.Green)}");
            System.Threading.Thread.Sleep(3000);
            Title_Screen mainMenu = new Title_Screen();
            Music_SFX.MenuMusic();
            mainMenu.LoadMainMenu();

        }
    }
}
