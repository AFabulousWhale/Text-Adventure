using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Pastel;
using Color = System.Drawing.Color;
using Figgle;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace TextAdventure
{
    class Inventory_system
    {
        Program Main = new Program();

        public string prompt;

        public string itemType;

        Random random = new System.Random();

        string menuOption;
        int backPosition;

        LoadArea loadArea = new LoadArea();

        //the main menu for inventory - Weapons, Armour, Healing Items
        public void InventoryMain()
        {
            //the main display of the inventory menu
            menuOption = "";
            prompt = @"Select a menu with the arrow keys and then you can use, drop or find out more about every item you have collected so far by pressing enter";
            string[] options = { "Weapons", "Armour", "Healing Items", "Gothesme's List", "Back"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    Weapons();
                    break;
                case 1:
                    Clear();
                    Armour();
                    break;
                case 2:
                    Clear();
                    HealingItems();
                    break;
                case 3:
                    Clear();
                    ItemList();
                    break;
                case 4:
                    Clear();
                    Back();
                    break;
            }
        }

        //displays the list of items to collect
        public void ItemList()
        {
            menuOption = "decision";
            itemType = "list";
            string[] listedItems = new string[] { "Fate's Lamp","Thunder Gauntlet", "Horn of Doom"};
            foreach (string item in listedItems)
            {
                if (SaveVariables.itemsObtained.Contains(item))
                {
                    WriteLine(item.Pastel(Color.Green));
                }
                else
                {
                    WriteLine(item);
                }
            }
            WriteLine("Press any key to go back...");
            ReadKey();
            Clear();
            InventoryMain();
        }

        //Displays the specific Healing items you own
        public void HealingItems()
        {
            menuOption = "decision";
            itemType = "Heal";
            prompt = $"You are currently on {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow)} {"health!".Pastel(Color.Yellow)}";
            string[] options = SaveVariables.healingItems;
            options = options.Append("Back").ToArray();
            backPosition = Array.IndexOf(options, "Back");
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            if (selectedIndex == backPosition)
            {
                Clear();
                Back();
                options = options.Where((source, index) => index != backPosition).ToArray();
            }
            else
            {
                switch (selectedIndex)
                {
                    default:
                        ItemOptions(selectedIndex);
                        break;
                }
            }
        }

        //Displays the specific Weapons you own
        public void Weapons()
        {
            menuOption = "decision";
            itemType = "Weapon";
            if (SaveVariables.currentWeapon == null || SaveVariables.currentWeapon == "")
                prompt = $@"You have nothing currently equipped!";
            else if (SaveVariables.currentWeapon != null || SaveVariables.currentWeapon == "")
                prompt = $@"You have {SaveVariables.currentWeapon.Pastel(Color.Yellow)} already equipped!";
            string[] options = SaveVariables.allWeapons;
            options = options.Append("Back").ToArray();
            backPosition = Array.IndexOf(options, "Back");
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            if (selectedIndex == backPosition)
            {
                Clear();
                Back();
                options = options.Where((source, index) => index != backPosition).ToArray();
            }
            else
            {
                switch (selectedIndex)
                {
                    default:
                        ItemOptions(selectedIndex);
                        break;
                }
            }
        }

        //Displays the specific Armour you own
        public void Armour()
        {
            menuOption = "decision";
            itemType = "Armour";
            if (SaveVariables.currentArmour == null || SaveVariables.currentArmour == "") //if the current armour is empty then it displays something else
                prompt = $@"You have nothing currently equipped!";
            else if (SaveVariables.currentArmour != null || SaveVariables.currentArmour == "")
                prompt = $@"You have {SaveVariables.currentArmour.Pastel(Color.Yellow)} already equipped!";
            string[] options = SaveVariables.allArmour;
            options = options.Append("Back").ToArray();
            backPosition = Array.IndexOf(options, "Back");
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            if (selectedIndex == backPosition)
            {
                Clear();
                Back();
                options = options.Where((source, index) => index != backPosition).ToArray();
            }
            else
            {
                switch (selectedIndex)
                {
                    default:
                        ItemOptions(selectedIndex);
                        break;
                }
            }
        }
 

        //use, drop or info about each item
        public void ItemOptions(int selectedItem)
        {
            menuOption = "options";
            if (itemType == "Heal")
            {
                prompt = $@"You have selected {SaveVariables.healingItems[selectedItem].Pastel(Color.Yellow)}";
            }
            else if (itemType == "Weapon")
            {
                prompt = $@"You have selected {SaveVariables.allWeapons[selectedItem].Pastel(Color.Yellow)}";
            }
            else if (itemType == "Armour")
            {
                prompt = $@"You have selected {SaveVariables.allArmour[selectedItem].Pastel(Color.Yellow)}";
            }
            string[] options = { "Use", "Drop", "Info", "Back"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    UseItem(selectedItem);
                    break;
                case 1:
                    Clear();
                    DropItem(selectedItem);
                    break;
                case 2:
                    Clear();
                    InfoItem(selectedItem);
                    break;
                case 3:
                    Clear();
                    Back();
                    break;
            }
        }

        //using items
        public void UseItem(int selectedItem)
        {
            //using a healing item - if you health is below 100
            if (itemType == "Heal")
            {
                SaveVariables.SeperateList(SaveVariables.healingItems[selectedItem]);
                if (SaveVariables.healingItems.Length >= 1)
                {
                    if(SaveVariables.playerHealth >= 100)
                    {
                        Main.PrintText($"You decided not to eat {SaveVariables.healingItems[selectedItem].Pastel(Color.Yellow)} as your health is already maxed out!");
                        HealingItems();
                    }
                    int healAmount = random.Next(SaveVariables.healVal, SaveVariables.healVal + 10);
                    SaveVariables.playerHealth = SaveVariables.playerHealth + healAmount;
                    if (SaveVariables.playerHealth >= 100)
                    {
                        SaveVariables.playerHealth = 100;
                        Console.WriteLine(FiggleFonts.Chunky.Render("YOU HEALED").Pastel(Color.Green));
                        Main.PrintText($"You ate the {SaveVariables.healingItems[selectedItem].Pastel(Color.Yellow)} and maxed out your {"HEALTH".Pastel(Color.Yellow)}");
                    }
                    else if (SaveVariables.playerHealth > 0)
                    {
                        Console.WriteLine(FiggleFonts.Chunky.Render("YOU HEALED").Pastel(Color.Green));
                        Main.PrintText($"You ate the {SaveVariables.healingItems[selectedItem].Pastel(Color.Yellow)} and your {"HEALTH".Pastel(Color.Yellow)} increased by {healAmount.ToString().Pastel(Color.Yellow)}");
                        Main.PrintText($"You are now on {SaveVariables.playerHealth.ToString().Pastel(Color.Yellow) + " HEALTH".Pastel(Color.Yellow)}");
                    }
                    SaveVariables.healingItems = SaveVariables.healingItems.Where((source, index) => index != selectedItem).ToArray();
                    Main.PrintText($"You now have {(SaveVariables.healingItems.Length.ToString().Pastel(Color.Yellow)) + " HEALING ITEMS".Pastel(Color.Yellow)} left!");
                    HealingItems();
                }
            }
            //equipping the selected weapon
            else if (itemType == "Weapon")
            {
                if (SaveVariables.currentWeapon == null || SaveVariables.currentWeapon == "")
                    Main.PrintText($"You equipped the {SaveVariables.allWeapons[selectedItem].Pastel(Color.Yellow)}!");
                else if (SaveVariables.currentWeapon != null || SaveVariables.currentWeapon != "")
                {
                    Main.PrintText($"You swapped out {SaveVariables.allWeapons[selectedItem].Pastel(Color.Yellow)} for {SaveVariables.currentWeapon.Pastel(Color.Yellow)} you already had equipped");
                    SaveVariables.allWeapons = SaveVariables.allWeapons.Append(SaveVariables.currentWeapon).ToArray();
                }
                System.Threading.Thread.Sleep(1000);
                SaveVariables.currentWeapon = SaveVariables.allWeapons[selectedItem];
                SaveVariables.SeperateList(SaveVariables.currentWeapon);
                SaveVariables.allWeapons = SaveVariables.allWeapons.Where((source, index) => index != selectedItem).ToArray();
                Weapons();
            }
            //equipping the selected armour
            else if (itemType == "Armour")
            {
                if (SaveVariables.currentArmour == null || SaveVariables.currentArmour == "")
                    Main.PrintText($"You put on the {SaveVariables.allArmour[selectedItem].Pastel(Color.Yellow)}!");
                else if (SaveVariables.currentArmour != null || SaveVariables.currentArmour != "")
                {
                    Main.PrintText($"You swapped out {SaveVariables.allArmour[selectedItem].Pastel(Color.Yellow)} for {SaveVariables.currentArmour.Pastel(Color.Yellow)} you were already wearing");
                    SaveVariables.allArmour = SaveVariables.allArmour.Append(SaveVariables.currentArmour).ToArray();
                }
                System.Threading.Thread.Sleep(1000);
                SaveVariables.currentArmour = SaveVariables.allArmour[selectedItem];
                SaveVariables.SeperateList(SaveVariables.currentArmour);
                SaveVariables.allArmour = SaveVariables.allArmour.Where((source, index) => index != selectedItem).ToArray();
                Armour();
            }
        }

        //dropping armour
        public void DropItem(int selectedItem)
        {
            if (itemType == "Heal")
            {
                Main.PrintText($"You threw out the {SaveVariables.healingItems[selectedItem].Pastel(Color.Yellow)} as you deicded it would no longer be necessary in your backpack");
                SaveVariables.healingItems = SaveVariables.healingItems.Where((source, index) => index != selectedItem).ToArray();
                HealingItems();
            }
            else if (itemType == "Weapon")
            {
                Main.PrintText($"You threw out the {SaveVariables.allWeapons[selectedItem].Pastel(Color.Yellow)} as you have equipped better weapons");
                SaveVariables.allWeapons = SaveVariables.allWeapons.Where((source, index) => index != selectedItem).ToArray();
                Weapons();
            }
            else if (itemType == "Armour")
            {
                Main.PrintText($"You threw out the {SaveVariables.allArmour[selectedItem].Pastel(Color.Yellow)} as you have equipped better armour");
                SaveVariables.allArmour = SaveVariables.allArmour.Where((source, index) => index != selectedItem).ToArray();
                Armour();
            }
        }
        
        //diaplying the information of the selected item by seperating it in the list and then setting all the respective values.
        public void InfoItem(int selectedItem)
        {
            if (itemType == "Heal")
            {
                Clear();
                string item = SaveVariables.healingItems[selectedItem];
                SaveVariables.SeperateList(item);
                Main.PrintText(SaveVariables.Description);
                Main.PrintText($"It can heal between {SaveVariables.healVal.ToString().Pastel(Color.Yellow)} and {(SaveVariables.healVal + 10).ToString().Pastel(Color.Yellow)} health");
                HealingItems();
            }
            else if (itemType == "Weapon")
            {
                Clear();
                string item = SaveVariables.allWeapons[selectedItem];
                SaveVariables.SeperateList(item);
                Main.PrintText(SaveVariables.Description);
                Main.PrintText($"It can deal between {(SaveVariables.weaponVal).ToString().Pastel(Color.Yellow)} and {(SaveVariables.weaponVal + 3).ToString().Pastel(Color.Yellow)} damage to any enemy");
                Weapons();
            }
            else if (itemType == "Armour")
            {
                Clear();
                string item = SaveVariables.allArmour[selectedItem];
                SaveVariables.SeperateList(item);
                Main.PrintText(SaveVariables.Description);
                Main.PrintText($"It can protect between {(SaveVariables.armourVal).ToString().Pastel(Color.Yellow)} and {(SaveVariables.armourVal + 3).ToString().Pastel(Color.Yellow)} damage from enemies");
                Armour();
            }
        }

        public void Back()
        {
            if (menuOption == "options")
            {
                if (itemType == "Armour")
                {
                    Armour();
                }
                else if (itemType == "Heal")
                {
                    HealingItems();
                }
                else if (itemType == "Weapon")
                {
                    Weapons();
                }
            }
            else if (menuOption == "decision")
            {
                InventoryMain();
            }
        }
    }
}
