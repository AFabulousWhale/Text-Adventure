using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class LoadArea
    {
        public static void load()
        {
            int lastClass = SaveVariables.lastClass;
            switch (lastClass)
            {
                //first choice in world1
                case 11:
                    Music_SFX.World1Music();
                    World1.W1Choice1();
                    break;
                //second choice (forwards) in world1
                case 12:
                    Music_SFX.World1Music();
                    World1.Forward.F1Choice1();
                    break;
                //first choice (left) in world1
                case 13:
                    Music_SFX.BarMusic();
                    World1.Left.LeftChoice1();
                    break;
                case 14:
                    Castle.CastleStart();
                    break;

            }
        }
    }
}
