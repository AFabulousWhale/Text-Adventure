using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TextAdventure
{
    class SaveVariables
    {
        public static int deaths;
        public static string playerName;
        public static int playerHealth;
        public static int lastClass;
        public static string currentWeapon;
        public static int weaponVal;
        public static string currentArmour;
        public static int armourVal;
        public static int money;
        public static int itemVal;
        public static int healVal;

        //this is so if you go the same place or do the same thing twice it doesn't give the same description/outcome
        public static string[] Conditions = { };

        public static string[] everyWeapon = { };
        public static string[] everyArmour = { };
        public static string[] everyHeal = { };

        public static int itemAmount;
        public static string Description;
        public static string[] healingItems = { };
        public static string[] itemsObtained = { };
        public static string[] allWeapons = { };
        public static string[] allArmour = { };

        public static string[] itemsToBuy = { };
        public static string[] weaponsToBuy = { };
        public static string[] healToBuy = { };
        public static string[] armourToBuy = { };
        public static int shopValue;

        //this is to seperate the list of all the weapons and armour values so that the values, names and descriptions are seperate
        public static void SeperateList(string specifiedItem)
        {
            Program Main = new Program();
            List<ItemValues> typeValues = new List<ItemValues>();
            List<string> itemValues = File.ReadAllLines("ItemValues.txt").ToList();

            //for every item in the text file it splits it by : the first value is the name, second is value, third is description and fourth is the type of item.
            foreach (string line in itemValues)
            {
                string[] entries = line.Split(":");
                ItemValues newType = new ItemValues();
                newType.Name = entries[0];
                newType.Value = entries[1];
                newType.Description = entries[2];
                newType.Item = entries[3];
                typeValues.Add(newType);

                if(newType.Item == "weapon")
                {
                    everyWeapon = everyWeapon.Append(newType.Name).ToArray();
                }

                if (newType.Item == "armour")
                {
                    everyArmour = everyArmour.Append(newType.Name).ToArray();
                }

                if (newType.Item == "food")
                {
                    everyHeal = everyHeal.Append(newType.Name).ToArray();
                }
            }

            typeValues = typeValues.Where(x => x.Name == specifiedItem).ToList();

            //for each type of item it sets the specific values to that item's value
            foreach (var thing in typeValues)
            {
                if (thing.Item == "armour")
                {
                    armourVal = Convert.ToInt32(thing.Value);
                    Description = thing.Description;                
                }

                if (thing.Item == "weapon")
                {
                    weaponVal = Convert.ToInt32(thing.Value);
                    Description = thing.Description;                
                }

                if (thing.Item == "food")
                {
                    healVal = Convert.ToInt32(thing.Value);
                    Description = thing.Description;                
                }

                if (thing.Item == "item")
                {
                    itemVal = Convert.ToInt32(thing.Value);
                    Description = thing.Description;
                }
            }
            
        }

        public static void shopList(string specifiedItem)
        {
            string[] entries;
            Program Main = new Program();
            List<ShopPrices> typePrices = new List<ShopPrices>();
            List<string> shopPrices = File.ReadAllLines("ShopPrices.txt").ToList();

            foreach (string line in shopPrices)
            {
                entries = line.Split(":");
                ShopPrices newType = new ShopPrices();
                newType.Name = entries[0];
                newType.Value = entries[1];
                newType.Weapons = entries[2];
                newType.Armour = entries[3];
                newType.Heal = entries[4];
                newType.Items = entries[5];
                typePrices.Add(newType);
            }

            typePrices = typePrices.Where(x => x.Name == specifiedItem).ToList();

            foreach (var thing in typePrices)
            {
                shopValue = Convert.ToInt32(thing.Value);

                entries = thing.Weapons.Split(",");
                entries = entries.Where(x => !allWeapons.Contains(x)).ToArray();
                entries = entries.Where(x => currentWeapon != x).ToArray();
                weaponsToBuy = entries;

                entries = thing.Armour.Split(",");
                entries = entries.Where(x => !allArmour.Contains(x)).ToArray();
                entries = entries.Where(x => currentArmour != x).ToArray();
                armourToBuy = entries;

                entries = thing.Heal.Split(",");
                entries = entries.Where(x => !healingItems.Contains(x)).ToArray();
                healToBuy = entries;

                entries = thing.Items.Split(",");
                entries = entries.Where(x => !itemsObtained.Contains(x)).ToArray();
                itemsToBuy = entries;
            }

        }
    }
}
