using System;
using System.Collections.Generic;
using System.Text;
using Figgle;
using Pastel;
using Color = System.Drawing.Color;
using System.Media;

namespace TextAdventure
{
    class Intro
    {
        Program Main = new Program();
        Character_Dialoge dialogue = new Character_Dialoge();

        //the intro description before meeting gothesme - the first thing you read
        public void Start(string previousName)
        {
            Music_SFX.StartMusic();
            Main.PrintText("Your final potion is almost complete, yet you seem to be missing the one important and final item!");
            Main.PrintText($"The {"Cylinder of Rebirth".Pastel(Color.Yellow)}");
            Main.PrintText("You search your whole house yet it's no where to be found");
            Main.PrintText("As you decided to give up and slowly slump to the floor, you hear a knock at the door");
            Main.PrintText($"“Nobody comes around here, it must be important!” you quietly say to yourself whilst heading over to the door");
            Main.PrintText("As your rusty door slowly swings open, standing there is an odd looking man with a big grin on his face, he appears to be selling something");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Character_Dialoge.Gothesme1.Seller1(previousName);
        }
    }
}
