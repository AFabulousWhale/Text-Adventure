using System;
using System.Collections.Generic;
using System.Text;
using Pastel;
using Color = System.Drawing.Color;
using System.IO;
using static System.Console;
using System.Linq;
using System.Reflection;
using Figgle;

namespace TextAdventure
{
    class Castle
    {
        Program Main = new Program();
        string prompt = @"
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
        static Battle_System battle = new Battle_System();
        public static void CastleStart()
        {
            Program Main = new Program();
            string prompt = @"
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
            Castle castle = new Castle();
            //the description of the castle before the gothesme fight
            if (SaveVariables.lastClass != 14)
            {
                Music_SFX.CastleMusic();
                Main.PrintText($"You open the doors to the gates of the castle and head on inside");
                Main.PrintText($"The castle is huge! there are rooms everywhere and a chique, prisitne fountain in the middle of the room");
                Main.PrintText($"As you were admiring the scenery, you hear a sudden splash coming from the fountain!");
                Clear();
                WriteLine(prompt);
                Main.PrintText($"“Hello {SaveVariables.playerName.Pastel(Color.Cyan)}! It's great to see you again ;)”");
                Main.PrintText($"“I see you have all of the items I requested - Good job!”");
                System.Threading.Thread.Sleep(2000);
                Main.PrintText($"“Now before I can give you your {"Cylinder of Rebirth".Pastel(Color.Yellow)} you deserved, you will have to show your worth in a fight!”");
                SaveVariables.lastClass = 14;
            }
            System.Threading.Thread.Sleep(2000);
            Music_SFX.BossMusic();
            Clear();
            battle.BattleMain("Gothesme", 200, prompt);
        }

        //this is what happens once you defeat gothesme in the fight
        public void GothesmeDeath()
        {
            Clear();
            Music_SFX.StartMusic();
            Main.PrintText($"After getting the {"Cylinder of Rebirth".Pastel(Color.Yellow)}, you get out your World Travelling Portal and decide to head home to finish your potion");
            Main.PrintText($"You step into your home and take a deep breath, finally, the potion can be complete - you say to yourself");
            Main.PrintText($"As you add the {"Cylinder of Rebirth".Pastel(Color.Yellow)} to your potion - it flashes blue for a couple seconds and lights up the whole room!");
            Main.PrintText($"Once it's calmed down you then take a cup of it and feed it to your cat");
            Main.PrintText($"After a couple of seconds, your cat stands up and seems completely back to normal!");
            Main.PrintText($"It was all worth it to heal your cat!!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(FiggleFonts.FlowerPower.Render("THE END").Pastel(Color.Green));
            System.Threading.Thread.Sleep(2000);
            Main.Credits();
        }

    }
}
