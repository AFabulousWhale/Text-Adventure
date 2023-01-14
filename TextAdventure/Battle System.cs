using System;
using System.Linq;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using System.Media;
using Figgle;
using Pastel;
using Color = System.Drawing.Color;

namespace TextAdventure
{
    class Battle_System
    {
        Program Main = new Program();

        Random random = new System.Random();

        public int enemyDamage = 5;
        public int playerDamage = 5;

        public int money = 0;

        int selectedIndex;

        public void BattleMain(string enemyType, int enemyHealth, string character)
        {
            int enemyAttack = random.Next(1, 3);

            if(SaveVariables.currentArmour == null || SaveVariables.currentArmour == "")
                SaveVariables.armourVal = 0;
            if (SaveVariables.currentWeapon == null || SaveVariables.currentWeapon == "")
                SaveVariables.weaponVal = 0;

            Console.WriteLine(character);
            Main.PrintText($"Woah! Look it's {enemyType.Pastel(Color.Red)} it seems they want to fight!");
            //if enemyAttack is 1 the enemy goes first, if it is 2 you go first
            if (enemyAttack == 1)
            {
                Main.PrintText($"{enemyType.Pastel(Color.Red)} seems to be cooler than you and therefore will attack first!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                enemyAttack = 0;
                EnemyTurn(enemyType, character, enemyHealth);
            }
            else if (enemyAttack == 2)
            {
                Main.PrintText($"You are way cooler than {enemyType.Pastel(Color.Red)} and therefore will attack first!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                enemyAttack = 0;
                YourTurn(enemyType, character, enemyHealth);
            }  
        }

        //the enemies turn
        public void EnemyTurn(string enemyType, string character, int enemyHealth)
        {
            Console.Clear();
            Console.WriteLine(character);
            Console.WriteLine($"Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}");
            while ((SaveVariables.playerHealth <= 100 && SaveVariables.playerHealth > 0) && (enemyHealth > 0) && selectedIndex != 3)
            {
                //change enemy damage depending on armour
                if (enemyType == "A scared kitten" || enemyType == "A Platypus" || enemyType == "An Armadillo" || enemyType == "A Hippo" || enemyType == "A Fox" || enemyType == "A Hamster")
                    enemyDamage = random.Next(20, 25);
                if (enemyType == "Blade and Beau")
                    enemyDamage = random.Next(20, 30);
                if (enemyType == "Flocuin")
                    enemyDamage = random.Next(20, 25);
                if (enemyType == "Gothesme")
                    enemyDamage = random.Next(25, 35);

                int randomDefence = random.Next(SaveVariables.armourVal, SaveVariables.armourVal + 3);
                if ((enemyDamage - randomDefence) > 0)
                {
                    enemyDamage = enemyDamage - random.Next(SaveVariables.armourVal, SaveVariables.armourVal + 3);
                }
                else
                {
                    enemyDamage = 1;
                }
                

                SaveVariables.playerHealth = SaveVariables.playerHealth - enemyDamage;
                Main.PrintText($"{enemyType.Pastel(Color.Red)} attacked you and dealt {enemyDamage.ToString().Pastel(Color.Red)} {"DAMAGE".Pastel(Color.Red)}");
                if (SaveVariables.playerHealth > 0)
                {
                    Main.PrintText($"You now have {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)} {"HEALTH".Pastel(Color.Yellow)}");
                    Console.Clear();
                    YourTurn(enemyType, character, enemyHealth);
                }
                else
                {
                    Console.Clear();
                    Main.Death();
                }
            }
        }

        //your turn - fighting the enemies
        public void YourTurn(string enemyType, string character, int enemyHealth)
        {
            Console.WriteLine(character);
            while ((SaveVariables.playerHealth <= 100 && SaveVariables.playerHealth > 0) && (enemyHealth > 0) && selectedIndex != 3)
            {
                //changing the prompt depending on which enemy you have to fight
                string prompt = null;
                if (enemyType == "A scared kitten")
                    prompt = $@"                  ████████████████                            
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
Scared Cat:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "Blade and Beau")
                    prompt = $@"       
       /^-^\         /^-----^\
      / o o \        V  o o  V
     /   Y   \        |  Y  |
     V \ v / V         \ Q /
       / - \           / - \
      /    |           |    \
(    /     |           |     \     )
 ===/___) ||           || (___\====
Blade and Beau:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "Flocuin")
                    prompt = $@"       
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
Flocuin:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "Gothesme")
                    prompt = $@"
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
Gothesme:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "A Platypus")
                    prompt = $@"
            _.- ~~^^^'~- _ __ .,.- ~ ~ ~  ~  -. _
 ________,'       ::.                       _,-  ~ -.
((      ~_\   -s-  ::                     ,'          ;,
 \\       <.._ .;;;`                     ;              `',
  ``======='    _ _- _ (                `,          ,'\,  `,
               ((/ _ _,i   ! _ ~ - -- - _ _'_-_,_,,,'    \,  ;
                ((((____/            (,(,(, ____>        \,'
A Platypus:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "An Armadillo")
                    prompt = $@"
       ,.-----__    
          ,:::://///,:::-. 
         /:''/////// ``:::`;/|/
        /'   ||||||     :://'`\
      .' ,   ||||||     `/(  e \
-===~__-'\__X_`````\_____/~`-._ `.
            ~~        ~~       `~-'
An Armadillo:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "A Hippo")
                    prompt = $@"
       c~~p ,---------. 
 ,---'oo  )           \
( O O                  )/
 `=^='                 /
       \    ,     .   /
       \\  |-----'|  /
       ||__|    |_|__|
A Hippo:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "A Fox")
                    prompt = $@"
   /|_/|
  / ^ ^(_o
 /    __.'
 /     \
(_) (_) '._
  '.__     '. .-''-'.
     ( '.   ('.____.''
     _) )'_, )mrf
    (__/ (__/
A Fox:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";
                if (enemyType == "A Hamster")
                    prompt = $@"
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
A Hamster:
Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}";

                //diaplys the options the player has against the enemies
                string[] options = { "Attack", "Heal", "Spare" };
                Menu mainMenu = new Menu(prompt, options);
                selectedIndex = mainMenu.PlayerInput();
                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine(character);
                        Attack(enemyType, character, enemyHealth);
                        break;
                    case 1:
                        Console.WriteLine(character);
                        Heal(enemyType, character, enemyHealth, prompt);
                        break;
                    case 2:
                        Console.WriteLine(character);
                        Spare(enemyType, enemyHealth, character);
                        break;
                }
            }
        }
        //if you choose to attack
        public void Attack(string enemyType, string character, int enemyHealth)
        {
            //changing damage depending on weapons you have found
            playerDamage = random.Next(20, 25);
            playerDamage += random.Next(SaveVariables.weaponVal, SaveVariables.weaponVal + 3); //attack damage is dependent on your weapon choice

            Console.WriteLine(FiggleFonts.Chunky.Render("YOU ATTACKED").Pastel(Color.Red)); //using an addons - figglefonts to generate ascii art text
            Console.Clear();
            Console.WriteLine(character);
            Console.WriteLine($"Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}");
            enemyHealth -= playerDamage;
            Main.PrintText($"You attack {enemyType.Pastel(Color.Red)} and dealt {playerDamage.ToString().Pastel(Color.Red) + " DAMAGE".Pastel(Color.Red)}");
            if (enemyHealth > 0) //if the enemy is alive then you can attack
            {
                Main.PrintText($"{enemyType.Pastel(Color.Red)} now has {enemyHealth.ToString().Pastel(Color.Red) + " HEALTH".Pastel(Color.Red)} left!");
                EnemyTurn(enemyType, character, enemyHealth);
            }
            else //if the enemy is dead
            {
                //depending on who you fight will depend on how much money you earn
                if (enemyType == "A scared kitten" || enemyType == "A Platypus" || enemyType == "An Armadillo" || enemyType == "A Hippo" || enemyType == "A Fox" || enemyType == "A Hamster")
                    money = random.Next(20, 35);
                if (enemyType == "Blade and Beau")
                    money = random.Next(30, 45);
                if (enemyType == "Flocuin")
                    money = random.Next(25, 35);
                //if you're fighting gothesme then you finish the game and get the end credits
                if (enemyType == "Gothesme")
                {
                    Castle castle = new Castle();
                    Main.PrintText($"“Good job {SaveVariables.playerName.Pastel(Color.Cyan)} You have defeated me...”");
                    Main.PrintText($"Gothesme dropped the {"Cylinder of Rebirth".Pastel(Color.Yellow)} and the rest of your items randomly vanished into thin air");
                    System.Threading.Thread.Sleep(3000);
                    castle.GothesmeDeath();
                }
                Console.WriteLine(FiggleFonts.Chunky.Render("YOU WON").Pastel(Color.Green));
                Main.PrintText($"You killed {enemyType.Pastel(Color.Red)}, you feel a bit of guilt, however they dropped {("$" + money.ToString()).Pastel(Color.Yellow)}");
                SaveVariables.money += money;
                //adds all the certain conditions so it knows that you've killed each animal and have been to their area.
                if (enemyType == "A scared kitten")
                {
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("stalls").ToArray();
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("stallKill").ToArray();
                }
                if (enemyType == "Blade and Beau")
                {
                    Main.PrintText($"They also dropped a {"Staff of Melancholy".Pastel(Color.Yellow)}");
                    SaveVariables.allWeapons = SaveVariables.allWeapons.Append("Staff of Melancholy").ToArray();
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("dogs").ToArray();
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("dogsKill").ToArray();
                }
                if (enemyType == "Flocuin")
                {
                    Main.PrintText($"They also dropped the {"Thunder Gauntlet".Pastel(Color.Yellow)}!! One of Gothesme's items");
                    SaveVariables.itemAmount++;
                    Main.PrintText($"YOU NOW HAVE {SaveVariables.itemAmount}/3 ITEMS FROM GOTHESEME'S LIST".Pastel(Color.HotPink));
                    SaveVariables.itemsObtained = SaveVariables.itemsObtained.Append("Thunder Gauntlet").ToArray();
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("elephantFight").ToArray();
                    SaveVariables.Conditions = SaveVariables.Conditions.Append("elephantKill").ToArray();
                }
                    if (SaveVariables.currentArmour == "Chestplate of Distress")
                {
                    Main.PrintText("The Chestplate of Distress randomly shattered and vanished into thin air");
                    SaveVariables.currentArmour = null;
                    int armourPos = Array.IndexOf(SaveVariables.allArmour, "Chestplate of Distress");
                    SaveVariables.allArmour = SaveVariables.allArmour.Where((source, index) => index != armourPos).ToArray();
                }
                Main.PrintText($"You now have ${SaveVariables.money.ToString()} in total! :D".Pastel(Color.Yellow));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                Main.randomItem = 7;
                LoadArea.load();
            }
        }

        //if you decide to heal
        public void Heal(string enemyType, string character, int enemyHealth, string prompt)
        {
            //displays all the items you have + their healing value so you know which item is best to use
                int backPosition;
                string[] healDisplay = { };
                foreach (string item in SaveVariables.healingItems)
                {
                    SaveVariables.SeperateList(item);
                    healDisplay = healDisplay.Append($"{item} - {SaveVariables.healVal}").ToArray();
                }
                string[] options = healDisplay;
                options = options.Append("Back").ToArray();
                backPosition = Array.IndexOf(options, "Back");
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.PlayerInput();


                if (SaveVariables.healingItems.Length >= 1)
                {
                    SaveVariables.SeperateList(SaveVariables.healingItems[selectedIndex]);
                if (SaveVariables.playerHealth >= 100)
                    {
                        Main.PrintText($"You decided not to eat {SaveVariables.healingItems[selectedIndex].Pastel(Color.Yellow)} as your health is already maxed out!");
                        YourTurn(enemyType, character, enemyHealth);
                    }
                    int healAmount = random.Next(SaveVariables.healVal, SaveVariables.healVal + 10);
                    SaveVariables.playerHealth = SaveVariables.playerHealth + healAmount;
                    if (SaveVariables.playerHealth >= 100)
                    {
                        SaveVariables.playerHealth = 100;
                        Console.WriteLine(FiggleFonts.Chunky.Render("YOU HEALED").Pastel(Color.Green));
                        Main.PrintText($"You ate the {SaveVariables.healingItems[selectedIndex].Pastel(Color.Yellow)} and maxed out your {"HEALTH".Pastel(Color.Yellow)}");
                    }
                    else if (SaveVariables.playerHealth > 0)
                    {
                        Console.WriteLine(FiggleFonts.Chunky.Render("YOU HEALED").Pastel(Color.Green));
                        Main.PrintText($"You ate the {SaveVariables.healingItems[selectedIndex].Pastel(Color.Yellow)} and your {"HEALTH".Pastel(Color.Yellow)} increased by {healAmount.ToString().Pastel(Color.Yellow)}");
                        Main.PrintText($"You are now on {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow) + " HEALTH".Pastel(Color.Yellow)}");
                    }
                    SaveVariables.healingItems = SaveVariables.healingItems.Where((source, index) => index != selectedIndex).ToArray();
                    Main.PrintText($"You now have {(SaveVariables.healingItems.Length.ToString().Pastel(Color.Yellow)) + " HEALING ITEMS".Pastel(Color.Yellow)} left!");
                    EnemyTurn(enemyType, character, enemyHealth);
                }
            
        }

        //if you choose to spare/run from the enemy
        public void Spare(string enemyType, int enemyHealth, string character)
        {
            Console.Clear();
            if (enemyType == "Gothesme")
            {
                Console.WriteLine(character);
                Main.PrintText("“You shall not spare me, otherwise you are unworthy of this item! ;)”");
                System.Threading.Thread.Sleep(1000);
                YourTurn(enemyType, character, enemyHealth);
            }
            if (enemyType == "A scared kitten" || enemyType == "A Platypus" || enemyType == "An Armadillo" || enemyType == "A Hippo" || enemyType == "A Fox" || enemyType == "A Hamster")
                money = random.Next(10, 20);
            if (enemyType == "Blade and Beau")
                money = random.Next(20, 35);
            if (enemyType == "Flocuin")
                money = random.Next(15, 20);
            Main.PrintText($"You spared {enemyType.Pastel(Color.Red)}");
            Console.Clear();
            Console.WriteLine(character);
            Console.WriteLine($"Enemy's health: {enemyHealth.ToString().Pastel(Color.Yellow)}            Your health: {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)}");
           //adds conditions if you choose to spare but you get less money
            if (enemyType == "A scared kitten") // scared kitten
            {
                Main.PrintText("“Here before you go, take this as a reward for not killing me!”");
                Main.PrintText($"{enemyType.Pastel(Color.Red)} gave you {("$" + money.ToString()).Pastel(Color.Yellow)}!");
                SaveVariables.Conditions = SaveVariables.Conditions.Append("stalls").ToArray();
                SaveVariables.Conditions = SaveVariables.Conditions.Append("stallFlee").ToArray();
            }
            if (enemyType == "Blade and Beau") //pack of dogs
            {
                Main.PrintText("“Hey wait up human!”".Pastel(Color.LightBlue));
                Main.PrintText("“TAKE THIS BEFORE YOU GO!!!”".Pastel(Color.LightPink));
                Main.PrintText($"{enemyType.Pastel(Color.Red)} gave you {("$" + money.ToString()).Pastel(Color.Yellow)}!");
                Main.PrintText($"They also gave you a {"Bow of Dusk".Pastel(Color.Yellow)}");
                SaveVariables.allWeapons = SaveVariables.allWeapons.Append("Bow of Dusk").ToArray();
                SaveVariables.Conditions = SaveVariables.Conditions.Append("dogs").ToArray();
                SaveVariables.Conditions = SaveVariables.Conditions.Append("dogsFlee").ToArray();
            }
            if (enemyType == "Flocuin")
            {
                Main.PrintText("“Here before you go, take this as a reward for not killing me!”");
                Main.PrintText($"{enemyType.Pastel(Color.Red)} gave you the {"Thunder Gauntlet".Pastel(Color.Yellow)}!! One of Gothesme's items");
                SaveVariables.itemAmount++;
                Main.PrintText($"YOU NOW HAVE {SaveVariables.itemAmount}/3 ITEMS FROM GOTHESEME'S LIST".Pastel(Color.HotPink));
                SaveVariables.itemsObtained = SaveVariables.itemsObtained.Append("Thunder Gauntlet").ToArray();
                SaveVariables.Conditions = SaveVariables.Conditions.Append("elephantFight").ToArray();
                SaveVariables.Conditions = SaveVariables.Conditions.Append("elephantFlee").ToArray();
            }
            if (enemyType == "A Platypus" || enemyType == "An Armadillo" || enemyType == "A Hippo" || enemyType == "A Fox" || enemyType == "A Hamster")
            {
                Main.PrintText("“Here before you go, take this as a reward for not killing me!”");
                Main.PrintText($"{enemyType.Pastel(Color.Red)} gave you {("$" + money.ToString()).Pastel(Color.Yellow)}!");
            }
            Console.WriteLine(FiggleFonts.Chunky.Render("YOU FLED").Pastel(Color.FromArgb(66, 135, 245)));
            SaveVariables.money += money;
            if(SaveVariables.currentArmour == "Chestplate of Distress")
            {
                Main.PrintText("The Chestplate of Distress randomly shattered and vanished into thin air");
                int armourPos = Array.IndexOf(SaveVariables.allArmour, "Chestplate of Distress");
                SaveVariables.currentArmour = null;
                SaveVariables.allArmour = SaveVariables.allArmour.Where((source, index) => index != armourPos).ToArray();
            }
            Main.PrintText($"You now have ${SaveVariables.money.ToString().Pastel(Color.Yellow)} in total! :D".Pastel(Color.Yellow));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Main.randomItem = 7;
            LoadArea.load();
        }

    }

}
