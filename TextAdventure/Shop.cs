using System;
using System.Collections.Generic;
using System.Text;
using Pastel;
using Color = System.Drawing.Color;
using System.IO;
using static System.Console;
using System.Linq;
using System.Reflection;

namespace TextAdventure
{
    class Shop
    {
        LoadArea loadArea = new LoadArea();

        Program Main = new Program();
        public Random random = new System.Random();

        int backPosition;
        public int menuOption;
        string[] options = { "Buy", "Sell", "Leave" };
        public string[] sellOptions = { };

        //displaying of buy, sell and leave - the first menu you will see when entering the shops
        public void ShopMainDisplay(string prompt, string shopKeeper)
        {
            menuOption = 1;
            //calls the menu script which detects player input with the arrow keys and if you press enter to confirm an action - options is what is displayed, selectedindex is what you choose.
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();

            switch (selectedIndex)
            {
                case 0:
                    BuyMainDisplay(prompt, shopKeeper);
                    break;
                case 1:
                    SellMainDisplay(prompt, shopKeeper);
                    break;
                case 2:
                    Back(prompt, menuOption, shopKeeper);
                    break;
            }
        }

        //chooses where to send you "back" to depending on the value of menuOption
        public void Back(string prompt, int menuOption, string shopKeeper)
        {
            switch (menuOption)
            {
                case 1:
                    Clear();
                    Main.PrintText("You exit the shop and think about what to do next on your journey..");
                    LoadArea.load();
                    break;
                case 2:
                    ShopMainDisplay(prompt, shopKeeper);
                    break;
                case 3:
                    SellMainDisplay(prompt, shopKeeper);
                    break;
                case 4:
                    BuyMainDisplay(prompt, shopKeeper);
                    break;
            }
        }

        //displaying of weapons, armour, heling items - everything you can sell.
        public void SellMainDisplay(string prompt, string shopKeeper)
        {
            string[] sellOptions = { "Weapons", "Armour", "Healing Items" };
            menuOption = 2;
            string[] options = sellOptions;
            sellOptions = sellOptions.Append("Back").ToArray();
            backPosition = Array.IndexOf(sellOptions, "Back");
            Menu mainMenu = new Menu(prompt, sellOptions);
            int selectedIndex = mainMenu.PlayerInput();

            //adds back to the array briefly to display it and once chosen an option removes it.
            if (selectedIndex == backPosition)
            {
                Clear();
                sellOptions = sellOptions.Where((source, index) => index != backPosition).ToArray();
                Back(prompt, menuOption, shopKeeper);
            }
            sellOptions = sellOptions.Where((source, index) => index != backPosition).ToArray();
            switch (selectedIndex)
            {
                case 0:
                    SellDisplayOptions(prompt, SaveVariables.allWeapons, "Weapon", shopKeeper);
                    break;
                case 1:
                    SellDisplayOptions(prompt, SaveVariables.allArmour, "Armour", shopKeeper);
                    break;
                case 2:
                    SellDisplayOptions(prompt, SaveVariables.healingItems, "Heal", shopKeeper);
                    break;
                case 3:
                    Back(prompt, menuOption, shopKeeper);
                    break;

            }
        }

        //displays the specific items you can sell of that category
        public void SellDisplayOptions(string prompt, string[] itemArray, string itemType, string shopKeeper)
        {
            bool selling = true;
            menuOption = 3;
            string[] options = itemArray;
            options = options.Append("Back").ToArray();
            backPosition = Array.IndexOf(options, "Back");
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();


            if (selectedIndex == backPosition)
            {
                Clear();
                options = options.Where((source, index) => index != backPosition).ToArray();
                Back(prompt, menuOption, shopKeeper);
            }
            else
            {
                switch (selectedIndex)
                {
                    default:
                        SellBuyItem(itemType, selectedIndex, prompt, itemArray, selling, shopKeeper);
                        break;
                }
            }
        }

        //displaying of weapons, armour, healing items and items
        public void BuyMainDisplay(string prompt, string shopKeeper)
        {
            if (shopKeeper == "Rezelle")
                sellOptions = new string[]{ "Weapons", "Armour", "Healing Items", "Items" };
            if (shopKeeper == "Glodsea")
                sellOptions = new string[]{ "Healing Items"};
            menuOption = 2;
            string[] options = sellOptions;
            sellOptions = sellOptions.Append("Back").ToArray();
            backPosition = Array.IndexOf(sellOptions, "Back");
            Menu mainMenu = new Menu(prompt, sellOptions);
            int selectedIndex = mainMenu.PlayerInput();

            if (selectedIndex == backPosition)
            {
                Clear();
                sellOptions = sellOptions.Where((source, index) => index != backPosition).ToArray();
                Back(prompt, menuOption, shopKeeper);
            }
            sellOptions = sellOptions.Where((source, index) => index != backPosition).ToArray();
            switch (selectedIndex)
            {
                case 0:
                    //changes the position of the options as Glodsea only displays healing items
                    if (shopKeeper == "Rezelle")
                        BuyDisplayOptions(prompt, SaveVariables.weaponsToBuy, "Weapon", shopKeeper);
                    if (shopKeeper == "Glodsea")
                        BuyDisplayOptions(prompt, SaveVariables.healToBuy, "Heal", shopKeeper);
                    break;
                case 1:
                    BuyDisplayOptions(prompt, SaveVariables.armourToBuy, "Armour", shopKeeper);
                    break;
                case 2:
                    BuyDisplayOptions(prompt, SaveVariables.healToBuy, "Heal", shopKeeper);
                    break;
                case 3:
                    BuyDisplayOptions(prompt, SaveVariables.itemsToBuy, "Items", shopKeeper);
                    break;
                case 4:
                    Back(prompt, menuOption, shopKeeper);
                    break;

            }
        }

        //displays the specific items you can buy of that category
        public void BuyDisplayOptions(string prompt,  string[] itemArray, string itemType, string shopKeeper)
        {
            bool selling = false;
            menuOption = 4;
            string[] options = itemArray;
            options = options.Append("Back").ToArray();
            backPosition = Array.IndexOf(options, "Back");
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();


            if (selectedIndex == backPosition)
            {
                Clear();
                options = options.Where((source, index) => index != backPosition).ToArray();
                Back(prompt, menuOption, shopKeeper);
            }
            else
            {
                switch (selectedIndex)
                {
                    default:
                        SellBuyItem(itemType, selectedIndex, prompt, itemArray, selling, shopKeeper);
                        break;
                }
            }
        }

        //displays info and pricings for the items
        public void SellBuyItem(string itemType, int selectedIndex, string prompt, string[] itemArray, bool selling, string shopKeeper)
        {
            int itemValue = 0;
            string chosenItem = "";
            if (selling)
            {
                Clear();
                WriteLine(prompt);
                string item = itemArray[selectedIndex];
                SaveVariables.SeperateList(item);

                if (itemType == "Weapon")
                {
                    chosenItem = SaveVariables.allWeapons[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.weaponVal;
                }
                if (itemType == "Armour")
                {
                    chosenItem = SaveVariables.allArmour[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.armourVal;
                }
                if (itemType == "Heal")
                {
                    chosenItem = SaveVariables.healingItems[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.healVal;
                }
                int moneyrand = random.Next(SaveVariables.shopValue, SaveVariables.shopValue * 2); //generated random money value depending on the shop value
                int moneyEarnt = (moneyrand + (itemValue / 2)); //adds the shopvalue to half the item value
                Main.PrintText($"“Here, I can give ya {("$" + moneyEarnt.ToString()).Pastel(Color.Yellow)} for the {itemArray[selectedIndex].Pastel(Color.Yellow)}! What do you say?”");
                WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Decision(prompt, itemType, selling, moneyEarnt, itemArray, selectedIndex, shopKeeper);
            }
            else if (!selling)
            {
                Clear();
                WriteLine(prompt);
                int moneyrand = random.Next(SaveVariables.shopValue, SaveVariables.shopValue + 2);
                string item = itemArray[selectedIndex];
                SaveVariables.SeperateList(item);
                if(itemType == "Weapon")
                {
                    chosenItem = SaveVariables.weaponsToBuy[selectedIndex];
                    SaveVariables.SeperateList(chosenItem); //seperates the lists of all items depending on the item you have chosen to buy
                    itemValue = SaveVariables.weaponVal;
                    Main.PrintText($"“This {itemArray[selectedIndex].Pastel(Color.Yellow)} is pertty good, it can do between {itemValue} and {itemValue + 3} damage”");
                }
                if (itemType == "Armour")
                {
                    chosenItem = SaveVariables.armourToBuy[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.armourVal;
                    Main.PrintText($"“This {itemArray[selectedIndex].Pastel(Color.Yellow)} is pertty good, it can protect between {itemValue} and {itemValue + 3} damage”");
                }
                if (itemType == "Heal")
                {
                    chosenItem = SaveVariables.healToBuy[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.healVal;
                    Main.PrintText($"“This {itemArray[selectedIndex].Pastel(Color.Yellow)} is pertty good, it can heal between {itemValue + 15} and {itemValue + 20} health”");
                }
                if (itemType == "Items")
                {
                    chosenItem = SaveVariables.itemsToBuy[selectedIndex];
                    SaveVariables.SeperateList(chosenItem);
                    itemValue = SaveVariables.itemVal;
                    Main.PrintText($"“Oooh the {itemArray[selectedIndex].Pastel(Color.Yellow)}” - {"It appears to be one of Gothesme's items :o".Pastel(Color.Yellow)}");
                }
                int moneyBuy = (moneyrand + (itemValue + (itemValue / 2)));
                Main.PrintText($"“It costs {("$" + moneyBuy.ToString()).Pastel(Color.Yellow)}! What do ya say?”");
                WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Decision(prompt, itemType, selling, moneyBuy, itemArray, selectedIndex, shopKeeper);
            }
        }

        //if you decide you want to buy a specific item
        public void Decision(string prompt, string itemType, bool selling, int moneyEarnt, string[] itemArray, int selectedItem, string shopKeeper)
        {
            string[] options = { "Yes", "No" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.PlayerInput();
            switch (selectedIndex)
            {
                case 0:
                    Yes(prompt, moneyEarnt, selling, itemArray, selectedItem, itemType, shopKeeper);
                    break;
                case 1:
                    Clear();
                    if (selling)
                    {
                        if (itemType == "Heal")
                            SellDisplayOptions(prompt, SaveVariables.healingItems, "Heal", shopKeeper);
                        if (itemType == "Weapon")
                            SellDisplayOptions(prompt, SaveVariables.allWeapons, "Weapon", shopKeeper);
                        if (itemType == "Armour")
                            SellDisplayOptions(prompt, SaveVariables.allArmour, "Armour", shopKeeper);
                    }
                    if (!selling)
                    {
                        if (itemType == "Items")
                            BuyDisplayOptions(prompt, SaveVariables.itemsToBuy, "Items", shopKeeper);
                        if (itemType == "Heal")
                            BuyDisplayOptions(prompt, SaveVariables.healToBuy, "Heal", shopKeeper);
                        if (itemType == "Weapon")
                            BuyDisplayOptions(prompt, SaveVariables.weaponsToBuy, "Weapon", shopKeeper);
                        if (itemType == "Armour")
                            BuyDisplayOptions(prompt, SaveVariables.armourToBuy, "Armour", shopKeeper);
                    }
                    break;
            }
        }

        //if you want to buy an item it works out if you have enough money and how much money you should earn by multiplying the items value by the shop value.
        public void Yes(string prompt, int moneyEarnt, bool selling, string[] itemArray, int selectedIndex, string itemType, string shopKeeper)
        {
            Clear();
            if (selling)
            {
                SaveVariables.money = SaveVariables.money + moneyEarnt;
                Main.PrintText($"You sold the {itemArray[selectedIndex]} and now have ${SaveVariables.money} in total".Pastel(Color.Yellow));
                itemArray = itemArray.Where((source, index) => index != selectedIndex).ToArray();
                Clear();
                if (itemType == "Weapon")
                {
                    SaveVariables.allWeapons = itemArray;
                    SellDisplayOptions(prompt, SaveVariables.allWeapons, "Weapon", shopKeeper);
                }
                else if (itemType == "Armour")
                {
                    SaveVariables.allArmour = itemArray;
                    SellDisplayOptions(prompt, SaveVariables.allArmour, "Armour", shopKeeper);
                }
                else if (itemType == "Heal")
                {
                    SaveVariables.healingItems = itemArray;
                    SellDisplayOptions(prompt, SaveVariables.healingItems, "Heal", shopKeeper);
                }
            }

            if (SaveVariables.money < moneyEarnt)
                NoMoney(itemType, prompt, itemArray, selling, shopKeeper);
            if (!selling)
            {
                string itemToAdd = itemArray[selectedIndex];
                SaveVariables.money = SaveVariables.money - moneyEarnt;
                Main.PrintText($"You bought the {itemArray[selectedIndex]} and now have ${SaveVariables.money} in total".Pastel(Color.Yellow));
                if (itemType == "Weapon")
                {
                    SaveVariables.weaponsToBuy = SaveVariables.weaponsToBuy.Where((source, index) => index != selectedIndex).ToArray();
                    SaveVariables.allWeapons = SaveVariables.allWeapons.Append(itemToAdd).ToArray();
                    BuyDisplayOptions(prompt, SaveVariables.weaponsToBuy, "Weapon", shopKeeper);
                }
                else if (itemType == "Armour")
                {
                    SaveVariables.armourToBuy = SaveVariables.armourToBuy.Where((source, index) => index != selectedIndex).ToArray();
                    SaveVariables.allArmour = SaveVariables.allArmour.Append(itemToAdd).ToArray();
                    BuyDisplayOptions(prompt, SaveVariables.armourToBuy, "Armour", shopKeeper);
                }
                else if (itemType == "Heal")
                {
                    SaveVariables.healToBuy = SaveVariables.healToBuy.Where((source, index) => index != selectedIndex).ToArray();
                    SaveVariables.healingItems = SaveVariables.healingItems.Append(itemToAdd).ToArray();
                    BuyDisplayOptions(prompt, SaveVariables.healToBuy, "Heal", shopKeeper);
                }
                else if (itemType == "Items")
                {
                    SaveVariables.itemAmount++;
                    Main.PrintText($"YOU NOW HAVE {SaveVariables.itemAmount}/3 ITEMS FROM GOTHESEME'S LIST".Pastel(Color.HotPink));
                    SaveVariables.itemsToBuy = SaveVariables.itemsToBuy.Where((source, index) => index != selectedIndex).ToArray();
                    SaveVariables.itemsObtained = SaveVariables.itemsObtained.Append(itemToAdd).ToArray();
                    System.Threading.Thread.Sleep(1500);
                    BuyDisplayOptions(prompt, SaveVariables.itemsToBuy, "Items", shopKeeper);
                }
            }
        }

        //if you don't have enough money this happens
        public void NoMoney(string itemType, string prompt, string[] itemArray, bool selling, string shopKeeper)
        {
            Main.PrintText("“Oops! looks like you don't have enough money for this item! try finding money scattered around the world or sell some unused item to me :D”");
            System.Threading.Thread.Sleep(1000);
            if (!selling)
                BuyDisplayOptions(prompt, itemArray, itemType, shopKeeper);
            if (selling)
                SellDisplayOptions(prompt, itemArray, itemType, shopKeeper);
        }
    }
}
