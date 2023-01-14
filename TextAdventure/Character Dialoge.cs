using System;
using Pastel;
using Color = System.Drawing.Color;
using static System.Console;
using Figgle;
using System.IO;
using System.Linq;

namespace TextAdventure
{
    class Character_Dialoge
    {

        //everything gothesme says
        public class Gothesme1
        {
            Program Main = new Program();
            public string prompt;

            public static void Seller1(string previousName)
            {
                Program Main = new Program();
                string prompt;
                Character_Dialoge.Gothesme1 gothesme = new Character_Dialoge.Gothesme1();

                Music_SFX.GothesmeMusic();
                Clear();
                System.Threading.Thread.Sleep(500);
                prompt = @"
   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:";
                WriteLine(prompt);
                Main.PrintText($"“Hello my name is { "Gothesme".Pastel(Color.Cyan) }, What happens to be your name?”");
                SaveVariables.playerName = ReadLine();
                Main.PrintText($"“Interesting, I've been told that your name is {previousName.Pastel(Color.Cyan)}, but hello {SaveVariables.playerName.Pastel(Color.Cyan)} I am willing to sell you a {"Cylinder of Rebirth".Pastel(Color.Yellow)} if you're willing to do some favours for me”");
                System.Threading.Thread.Sleep(2000);
                Clear();
                string[] options = { "Sure! I'm In! :D", "What's the favour?", "I'm good thanks!" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        gothesme.Yes();
                        break;
                    case 1:
                        gothesme.Favour();
                        break;
                    case 2:
                        gothesme.No();
                        break;
                }
            }

            //if you choose yes for the favour
            public void Yes()
            {
                Clear();
                WriteLine(@"
    XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:");
                Main.PrintText($"“Thank you! take this list and please complete everything to recieve your {"Cylinder of Rebirth".Pastel(Color.Yellow)} in return :D”");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Clear();
                GameStart();
            }

            //if you ask what the favour is
            public void Favour()
            {
                prompt = @"
    XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:";
                Clear();
                WriteLine(prompt);
                Main.PrintText($"“{SaveVariables.playerName.Pastel(Color.Cyan)}, if you can collect this list of items for me I will trade it for a {"Cylinder of Rebirth".Pastel(Color.Yellow)} in return!”");
                System.Threading.Thread.Sleep(1000);
                string[] options = { "Sound exciting! Sure!!", "No thank you!", "Can you repeat that?" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Yes();
                        break;
                    case 1:
                        No();
                        break;
                    case 2:
                        Clear();
                        WriteLine(@"
    XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:");
                        Main.PrintText($"“Of course! {SaveVariables.playerName.Pastel(Color.Cyan)}, I'm happy to repeat it for you!”");
                        System.Threading.Thread.Sleep(1000);
                        Favour();
                        break;
                }
            }

            //if you choose no, after asking the favour
            public void No()
            {
                Clear();
                WriteLine(@"
    XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:");
                Main.PrintText($"“That's upsetting, I thought you would be up for a deal like this {SaveVariables.playerName.Pastel(Color.Cyan)}, but oh well! I shall be off then!”");
                System.Threading.Thread.Sleep(1000);
                string[] options = { "Wait!", "Goodbye!!" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();

                switch (selectedIndex)
                {
                    case 0:
                        Wait();
                        break;
                    case 1:
                        Bye();
                        break;
                }
            }

            //if you choose to wait after saying no to the favour
            public void Wait()
            {
                Clear();
                WriteLine(@"
    XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:");
                Main.PrintText($"“You've changed your mind {SaveVariables.playerName.Pastel(Color.Cyan)}? Hmmm, Okay! I'm still willing to make the deal with you: if you can collect this list of items for me I will trade it for a {"Cylinder of Rebirth".Pastel(Color.Yellow)} in return!”");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Clear();
                GameStart();
            }

            //if you choose bye after saying no to the favour
            public void Bye()
            {
                Clear();
                Main.PrintText($"You say bye to {"Gothesme".Pastel(Color.Cyan)} as he walks off, you feel a bit of regret as you really need that {"Cylinder of Rebirth".Pastel(Color.Yellow)}, however he seemed sketchy and isn't worth the risk!");
                Main.PrintText("You head back inside and continue searching for that darn cylinder");
                System.Threading.Thread.Sleep(2000);
                Clear();
                WriteLine(FiggleFonts.Starwars.Render("GAME OVER"));
                File.Create(@"SavedGame.txt").Close();
                System.Threading.Thread.Sleep(4000);
                WriteLine("Press any key to go back to the main menu...");
                ReadKey(true);
                Title_Screen mainMenu = new Title_Screen();
                mainMenu.LoadMainMenu();
            }

            //if you decide to go with the favour - this is what starts the actual game.
            public void GameStart()
            {
                Music_SFX.StartMusic();
                Main.PrintText($"{"You recieved the list! You can check said list in your inventory at any time to see what you need to collect by typing OPEN INVENTORY".Pastel(Color.Yellow)}");
                Main.PrintText($"You decided to grab a backpack from your house to carry the items, and your {"World travelling wand".Pastel(Color.Yellow)} to take with you on your journey");
                Main.PrintText($"You grab your wand and creating the first portal stepping through into the first world...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Clear();
                World1 world1 = new World1();
                world1.World1Start();
            }
        }

        //everything rezelle says before you enter the shop
        public class Rezelle
        {
            Random random = new System.Random();
            Program Main = new Program();
            Shop shop = new Shop();
            public void RezelleStart()
            {
                string prompt = @"
                           |\      /|
                           | \____/ |
                           |        |
                          .'___  ___`.
                         /  \|/  \|/  \
        _.--------------( ____ __ _____)
     .-'    -.           \ ----\/---- /
   .'         \           `.  -'`-  .'
  /            \            `------'\
 /   `-------.  `-----.       -----. `---.
(             )        )            )     )
 `._________.'_____,,,/\_______,,,,/_,,,,/

Rezelle:";
                Music_SFX.RezelleMusic();
                Clear();
                System.Threading.Thread.Sleep(500);
                WriteLine(@"
                           |\      /|
                           | \____/ |
                           |        |
                          .'___  ___`.
                         /  \|/  \|/  \
        _.--------------( ____ __ _____)
     .-'    -.           \ ----\/---- /
   .'         \           `.  -'`-  .'
  /            \            `------'\
 /   `-------.  `-----.       -----. `---.
(             )        )            )     )
 `._________.'_____,,,/\_______,,,,/_,,,,/

Rezelle:");
                //chooses a random line to says when you enter the shop after the first time
                if (SaveVariables.Conditions.Contains("RShop"))
                {
                    int welcome = random.Next(1, 3);
                    if (welcome == 1)
                        Main.PrintText($"“Welcome back {SaveVariables.playerName.Pastel(Color.Cyan)}!”");
                    if (welcome == 2)
                        Main.PrintText($"“{SaveVariables.playerName.Pastel(Color.Cyan)}! My favourite customer!!”");
                }
                //what is said the first time you enter the shop
                if (!SaveVariables.Conditions.Contains("RShop"))
                {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("RShop").ToArray();
                    Main.PrintText($"“Hello! Welcome to my shop, not many people come by here but welcome! :D”");
                }
                System.Threading.Thread.Sleep(1000);
                Clear();
                SaveVariables.shopList("Rezelle");
                shop.ShopMainDisplay(prompt, "Rezelle");
            }
        }

        //everything the dogs say before the fight
        public class Dogs
        {
            Program Main = new Program();
            Battle_System battle = new Battle_System();
            public void DogMain()
            {
                Clear();
                WriteLine(@"
       /^-^\         /^-----^\
      / o o \        V  o o  V
     /   Y   \        |  Y  |
     V \ v / V         \ Q /
       / - \           / - \
      /    |           |    \
(    /     |           |     \     )
 ===/___) ||           || (___\====
Blade and Beau:");
                Music_SFX.DogMainMusic();
                Main.PrintText("“Hey, Beau do you smell a Human?”".Pastel(Color.LightBlue));
                System.Threading.Thread.Sleep(500);
                Main.PrintText("“BLADE DID YOU SAY HUMAN?!?”".Pastel(Color.LightPink));
                System.Threading.Thread.Sleep(500);
                Main.PrintText("“I did Beau but I don't know where they are, must be close...”".Pastel(Color.LightBlue));
                System.Threading.Thread.Sleep(500);
                Main.PrintText("“BLADE I CAN'T BELIVE THIS! THERE MIGHT BE A HUMAN NEAR BY - THAT MEANS PLAY TIME”".Pastel(Color.LightPink));
                System.Threading.Thread.Sleep(500);
                Clear();
                Music_SFX.DogBattleMusic();
                battle.BattleMain("Blade and Beau", 150, @"
       /^-^\         /^-----^\
      / o o \        V  o o  V
     /   Y   \        |  Y  |
     V \ v / V         \ Q /
       / - \           / - \
      /    |           |    \
(    /     |           |     \     )
 ===/___) ||           || (___\====
Blade and Beau:");
            }
        }

        //everything bar text realted
        public class Bar
        {
            Program Main = new Program();

            //all the options to do with the bear interaction
            public class Bear
            {
                Program Main = new Program();
                public string prompt = @"     
     (()__(()
     /       \ 
    ( /    \  \
     \ o o    /
     (_()_)__/ \             
    / _,==.____ \
   (   |--|      )
   /\_.|__|'-.__/\_
  / (        /     \ 
  \  \      (      /
   )  '._____)    /    
(((____.--(((____/
Octalo::";

                //the main thing the bear says when you first talk to them
                public static void BearMain()
                {
                    Program Main = new Program();
                    string prompt = @"     
     (()__(()
     /       \ 
    ( /    \  \
     \ o o    /
     (_()_)__/ \             
    / _,==.____ \
   (   |--|      )
   /\_.|__|'-.__/\_
  / (        /     \ 
  \  \      (      /
   )  '._____)    /    
(((____.--(((____/
Octalo::";
                    Character_Dialoge.Bar.Bear bear = new Character_Dialoge.Bar.Bear();

                    WriteLine(prompt);
                    //if you have interacted with the bear before
                    if (SaveVariables.Conditions.Contains("Bear"))
                    {
                        Main.PrintText($"“Nice to see you again {SaveVariables.playerName.Pastel(Color.Cyan)}!”");
                        System.Threading.Thread.Sleep(2000);
                        //if you decided to get the cake already from the bear
                        if (SaveVariables.Conditions.Contains("Cake"))
                        {
                            Main.PrintText($"“I'm sorry, but I have nothing else to give you :/”");
                            System.Threading.Thread.Sleep(2000);
                            bear.Goodbye();
                        }
                    }
                    if (!SaveVariables.Conditions.Contains("Bear"))
                    {
                        SaveVariables.Conditions = SaveVariables.Conditions.Append("Bear").ToArray();
                        Main.PrintText("“Why hello there, my name is Octalo, nice to meet you! :D”");
                        System.Threading.Thread.Sleep(2000);
                        Clear();

                    }
                    string[] options = { "Hello there!", "How are you?", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            bear.Hello();
                            break;
                        case 1:
                            bear.HRU();
                            break;
                        case 2:
                            bear.Goodbye();
                            break;
                    }
                }

                public void Goodbye()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText($"“Goodbye {SaveVariables.playerName.Pastel(Color.Cyan)}! I hope to see you again soon! :D”");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    World1.Left.LeftChoice1();
                }

                public void HRU()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“I am doing amazingly! I've got my favourite type of honey and it's just soo good!!”");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    string[] options = { "It smells great!", "May I have some?", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            Cake();
                            break;
                        case 1:
                            Cake();
                            break;
                        case 2:
                            Goodbye();
                            break;
                    }
                }

                public void Hello()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“What happens to bring you here?”");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    string[] options = { "It's secret information :P", "Trying to find something for a friend!", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            Fun();
                            break;
                        case 1:
                            Fun();
                            break;
                        case 2:
                            Goodbye();
                            break;
                    }
                }

                public void Cake()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Here, you can have some of the cake! :D”");
                    SaveVariables.healingItems = SaveVariables.healingItems.Append("Night Wasabi Cake").ToArray();
                    Main.PrintText("You obtained the Night Wasabi Cake!".Pastel(Color.Yellow));
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("Cake").ToArray();
                    System.Threading.Thread.Sleep(2000);
                    Goodbye();
                }

                public void Fun()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“That sounds pretty fun! and I hope you accomplish whatever you're doing! :D”");
                    System.Threading.Thread.Sleep(2000);
                    Main.PrintText("“That reminds me, I have some spare cake for you as a gift!”");
                    System.Threading.Thread.Sleep(1000);
                    Cake();
                }
            }

            //all the options to do with the cow interaction
            public class Cow
            {
                Program Main = new Program();
                public string prompt = @"              
              (      )
              ~(^^^^)~
               ) @@ \~_          |\
              /     | \        \~ /
             ( 0  0  ) \        | |
              ---___/~  \       | |
               /'__/ |   ~-_____/ |
o          _   ~----~      ___---~
  O       //     |         |
         ((~\  _|         -|
   o  O //-_ \/ |        ~  |
        ^   \_ /         ~  |
               |          ~ |
               |     /     ~ |
               |     (       |
                \     \      /\
               / -_____-\   \ ~~-*
               |  /       \  \
               / /         / /
             /~  |       /~  |
             ~~~~        ~~~~
Grissana:";

                public static void CowMain()
                {
                    Program Main = new Program();
                    string prompt = @"              
              (      )
              ~(^^^^)~
               ) @@ \~_          |\
              /     | \        \~ /
             ( 0  0  ) \        | |
              ---___/~  \       | |
               /'__/ |   ~-_____/ |
o          _   ~----~      ___---~
  O       //     |         |
         ((~\  _|         -|
   o  O //-_ \/ |        ~  |
        ^   \_ /         ~  |
               |          ~ |
               |     /     ~ |
               |     (       |
                \     \      /\
               / -_____-\   \ ~~-*
               |  /       \  \
               / /         / /
             /~  |       /~  |
             ~~~~        ~~~~
Grissana:";
                    Character_Dialoge.Bar.Cow cow = new Character_Dialoge.Bar.Cow();

                    WriteLine(prompt);
                    if (SaveVariables.Conditions.Contains("Cow"))
                    {
                        Main.PrintText($"“Howdy again, {SaveVariables.playerName.Pastel(Color.Cyan)}!”");
                        System.Threading.Thread.Sleep(2000);
                        if (SaveVariables.Conditions.Contains("Armour"))
                        {
                            Main.PrintText("“Sorry dude, I only had the one chestplate to give ya!”");
                            System.Threading.Thread.Sleep(2000);
                            cow.Goodbye();
                        }
                    }
                    if (!SaveVariables.Conditions.Contains("Cow"))
                    {
                        SaveVariables.Conditions = SaveVariables.Conditions.Append("Cow").ToArray();
                        Main.PrintText("“Sup, the name's Grissana, nice to meet ya!”");
                        System.Threading.Thread.Sleep(2000);
                        Clear();
                    }
                    string[] options = { "Hello there!", "How are you?", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            cow.Hello();
                            break;
                        case 1:
                            cow.HRU();
                            break;
                        case 2:
                            cow.Goodbye();
                            break;
                    }
                }

                public void Hello()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Sup my dude! It's good to see you!”");
                    System.Threading.Thread.Sleep(2000);
                    Armour();
                }
                public void HRU()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Feeling pretty chill right now my dude!”");
                    System.Threading.Thread.Sleep(2000);
                    Main.PrintText("“Actually that reminds me-”");
                    Armour();
                }
                public void Goodbye()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText($"“Cya {SaveVariables.playerName.Pastel(Color.Cyan)}! Hope to see ya later my dude!”");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    World1.Left.LeftChoice1();
                }
                public void Armour()
                {
                    Main.PrintText("“I've got something special for you if you're willing to try it! It'll make you feel super hyped up if you know what I mean!”");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    string[] options = { "Sure thing!", "No thanks!", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            Yes();
                            break;
                        case 1:
                            No();
                            break;
                        case 2:
                            Goodbye();
                            break;
                    }
                }
                public void Yes()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Here ya go! It only lasts once so use it wisely! :P”");
                    SaveVariables.allArmour = SaveVariables.allArmour.Append("Chestplate of Distress").ToArray();
                    Main.PrintText("You obtained the Chestplate of Distress!".Pastel(Color.Yellow));
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("CowArmour").ToArray();
                    System.Threading.Thread.Sleep(2000);
                    Goodbye();
                }
                public void No()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“The choice is yours! I respect you saying no! :)”");
                    System.Threading.Thread.Sleep(2000);
                    Goodbye();
                }
            }

            //all the options to do with the elephant interactions
            public class Elephant
            {
                Program Main = new Program();
                string prompt = @" 
__                 
'. \                
 '- \               
  / /_         .---.
 / | \\,.\/--.//    )
 |  \//        )/  / 
  \  ' ^ ^    /    )____.----..  6
   '.____.    .___/            \._) 
      .\/.                      )
       '\                       /
       _/ \/    ).        )    (
      /#  .!    |        /\    /
      \  C// #  /'-----''/ #  / 
   .   'C/ |    |    |   |    |  ,
   \), .. .'OOO-'. ..'OOO'OOO-'. ..\(,
Flocuin:";

                public static void ElephantMain()
                {
                    Program Main = new Program();
                    string prompt = @" 
__                 
'. \                
 '- \               
  / /_         .---.
 / | \\,.\/--.//    )
 |  \//        )/  / 
  \  ' ^ ^    /    )____.----..  6
   '.____.    .___/            \._) 
      .\/.                      )
       '\                       /
       _/ \/    ).        )    (
      /#  .!    |        /\    /
      \  C// #  /'-----''/ #  / 
   .   'C/ |    |    |   |    |  ,
   \), .. .'OOO-'. ..'OOO'OOO-'. ..\(,
Flocuin:";
                    Character_Dialoge.Bar.Elephant elephant = new Character_Dialoge.Bar.Elephant();
                    WriteLine(prompt);
                    if (!SaveVariables.Conditions.Contains("elephantFight"))
                    {
                        if (SaveVariables.Conditions.Contains("Elephant"))
                        {
                            Main.PrintText($"“Oh my god, it's {SaveVariables.playerName.Pastel(Color.Cyan)}!!”");
                        }
                        if (!SaveVariables.Conditions.Contains("Elephant"))
                        {
                            SaveVariables.Conditions = SaveVariables.Conditions.Append("Elephant").ToArray();
                            Main.PrintText("“Hey there, you can call me Flocuin :)”");
                        }
                    }
                    else if (SaveVariables.Conditions.Contains("elephantFight"))
                    {
                        if (SaveVariables.Conditions.Contains("elephantFlee"))
                        {
                            Main.PrintText("“Thanks for sparing me! Now continue on your joruney!”");
                            elephant.Goodbye();
                        }
                        if (SaveVariables.Conditions.Contains("elephantKill"))
                        {
                            Main.PrintText("You feel remorse seeing the empty spot in the corner of the room, however it was worth it for one more item! :D");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                            Clear();
                            World1.Left.LeftChoice1();
                        }
                    }

                    string[] options = { "Hello there!", "How are you?", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            elephant.Hello();
                            break;
                        case 1:
                            elephant.HRU();
                            break;
                        case 2:
                            elephant.Goodbye();
                            break;
                    }
                }

                public void Hello()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Please can you leave me alone, I's just like to be by myself!”");

                    string[] options = { "I'm sorry, I'll leave you alone", "No thanks!", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            Alone();
                            break;
                        case 1:
                            NotAlone();
                            break;
                        case 2:
                            Goodbye();
                            break;
                    }
                }

                public void HRU()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Just vibing alone rn :D”");

                    string[] options = { "Sounds like a good time!", "Alone?", "Goodbye!" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.PlayerInput();

                    switch (selectedIndex)
                    {
                        case 0:
                            NotAlone();
                            break;
                        case 1:
                            NotAlone();
                            break;
                        case 2:
                            Goodbye();
                            break;
                    }
                }

                public void Goodbye()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Goodbye! I hope you have fun on your adventure! :)”");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    World1.Left.LeftChoice1();
                }

                public void Alone()
                {
                    Clear();
                    WriteLine(prompt);
                    Main.PrintText($"“Thanks {SaveVariables.playerName.Pastel(Color.Cyan)}, I appreciate it! :D”");
                    System.Threading.Thread.Sleep(2000);
                    Goodbye();
                }

                public void NotAlone()
                {
                    Battle_System battle = new Battle_System();

                    Clear();
                    WriteLine(prompt);
                    Main.PrintText("“Hey are you making fun of me?!?”");
                    Clear();
                    Music_SFX.BattleMusic();
                    battle.BattleMain("Flocuin", 100, prompt);
                }
            }

            //what the horse says before you enter the shop
            public void HorseMain()
            {
                Music_SFX.HorseMusic();
                Shop shop = new Shop();
                string prompt = @"                                 
                                 |\    /|
                              ___| \,,/_/
                           ---__/ \/    \
                          __--/     (D)  \
                          _ -/    (_      \
                         // /       \_ /  -\
   __-------_____--___--/           / \_ O o)
  /                                 /   \__/
 /                                 /
||          )                   \_/\
||         /              _      /  |
| |      /--______      ___\    /\  :
| /   __-  - _/   ------    |  |   \ \
 |   -  -   /                | |     \ )
 |  |   -  |                 | )     | |
  | |    | |                 | |    | |
  | |    < |                 | |   |_/
  < |    /__\                <  \
  /__\                       /___\
Glodsea:";
                WriteLine(prompt);
                if (SaveVariables.Conditions.Contains("Horse"))
                {
                    Main.PrintText($"“Glad to see you here again {SaveVariables.playerName.Pastel(Color.Cyan)}!”");
                }
                if (!SaveVariables.Conditions.Contains("Horse"))
                {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("Horse").ToArray();
                    Main.PrintText("“Howdy there partner, the name's Glodsea!”");
                }
                SaveVariables.shopList("Glodsea");
                shop.ShopMainDisplay(prompt, "Glodsea");
                World1.Left.LeftChoice1();
            }
        }

        //everything to do with the frog guard before the quiz
        public class Guard
        {
            Program Main = new Program();
            public void GuardMain()
            {
                string prompt = @"     
         o  o   o  o
         |\/ \^/ \/|
         |,-------.|
       ,-.(|)   (|),-.
       \_*._ ' '_.* _/
        /`-.`--' .-'\
   ,--./    `---'    \,--.
   \   |(  )     (  )|   /
    \  | ||       || |  /
     \ | /|\     /|\ | /
     /  \-._     _,-/  \
    //| \\  `---'  // |\\
   /,-.,-.\       /,-.,-.\
  o   o   o      o   o    o
Hopscotch:";
                if (!SaveVariables.Conditions.Contains("Quiz"))
                {
                    WriteLine(prompt);
                    Music_SFX.CastleMusic();
                    Main.PrintText($"“Hello! {SaveVariables.playerName.Pastel(Color.Cyan)}? I believe? Welcome! :D”");
                    System.Threading.Thread.Sleep(2000);
                    if (!SaveVariables.itemsObtained.Contains("Fate's Lamp") || !SaveVariables.itemsObtained.Contains("Thunder Gauntlet"))
                    {
                        Main.PrintText($"“I'm sorry, but i cannot let you through just yet as you don't seem to have all the items required!”");
                        System.Threading.Thread.Sleep(1500);
                        Main.PrintText($"“Goodbye for now {SaveVariables.playerName.Pastel(Color.Cyan)}, I hope to see you again soon!”");
                        GuardBack();
                    }
                    if (SaveVariables.Conditions.Contains("Frog"))
                    {
                        Clear();
                        Quiz.Questions(prompt);
                    }
                    if (!SaveVariables.Conditions.Contains("Frog"))
                    {
                        SaveVariables.Conditions = SaveVariables.Conditions.Append("Frog").ToArray();
                        Main.SaveGame(SaveVariables.Conditions, SaveVariables.itemVal, SaveVariables.Description, SaveVariables.deaths, SaveVariables.playerName, SaveVariables.playerHealth, SaveVariables.lastClass, SaveVariables.currentWeapon, SaveVariables.weaponVal, SaveVariables.currentArmour, SaveVariables.armourVal, SaveVariables.money, SaveVariables.healingItems, SaveVariables.itemsObtained, SaveVariables.allWeapons, SaveVariables.allArmour, SaveVariables.healVal, SaveVariables.itemAmount);
                        if (SaveVariables.itemsObtained.Contains("Fate's Lamp") && SaveVariables.itemsObtained.Contains("Thunder Gauntlet")) //if you have the 2 items already then you get the last one
                        {
                            Main.PrintText($"“Wow! It appears as if you have all the items within this world! All expect one...”");
                            System.Threading.Thread.Sleep(1500);
                            Main.PrintText($"“Now before you can enter the castle you must complete my special quiz to obtain the last and final item”");
                            System.Threading.Thread.Sleep(1000);
                            Main.PrintText($"“Before you head on in, are you sure you're ready? You cannot turn back now, so make sure you have everything you need, and be sure to save before you come back here :)”");
                            System.Threading.Thread.Sleep(3000);
                            string prompt2 = "What would you like to do?";
                            string[] options = { "I'm ready!", "Go back!" };
                            Menu mainMenu = new Menu(prompt2, options);
                            int selectedIndex = mainMenu.PlayerInput();

                            if (selectedIndex == 0)
                            {
                                Clear();
                                Array.Clear(Quiz.questionAsked, 0, Quiz.questionAsked.Length);
                                Quiz.QuizMain(prompt);
                            }
                            else
                                GuardBack();
                        }
                    }
                }
                if (SaveVariables.Conditions.Contains("Quiz"))
                {
                    Battle_System battle = new Battle_System();

                    Main.PrintText($"You pass by Hopscotch and go straight through into the castle back to Gothesme!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Clear();
                    Music_SFX.BossMusic();
                    prompt = @"
   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
 XXXXXXXXXXXXXXXXXX         XXXXXXXX
XXXXXXXXXXXXXXXX              XXXXXXX
XXXXXXXXXXXXX                   XXXXX
 XXX     _________ _________     XXX      
  XX    I  _xxxxx I xxxxx_  I    XX        
 ( X----I         I         I----X )           
( +I    I      00 I 00      I    I+ )
 ( I    I    __0  I  0__    I    I )
  (I    I______ /   \_______I    I)
   I           ( ___ )           I
   I    _  :::::::::::::::  _    i
    \    \___ ::::::::: ___/    /
     \_      \_________/      _/
       \        \___,        /
         \                 /
          |\             /|
          |  \_________/  |
Gothesme:";
                    battle.BattleMain("Gothesme", 250, prompt);
                }
            }

            public void GuardBack()
            {
                Clear();
                Main.PrintText($"You left the castle and went back to the three pathways to see if there was anything you may have missed...");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Clear();
                SaveVariables.lastClass = 11;
                LoadArea.load();
            }
        }
    }
}
