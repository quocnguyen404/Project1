using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Inventory
    {
        private int capacity = 10;
        private int totalItem;
        protected float gold;

        private Dictionary<string, Item> items;
        private Dictionary<string, Weapon> weapons;
        private Dictionary<string, Cloth> cloths;

        public Dictionary<string, Item> tempItems;

        public float Gold { get => gold; }
        public Dictionary<string, Item> Items { get => tempItems; }

        //constructor
        public Inventory()
        {
            totalItem = 0;
            gold = 0;
            items = new Dictionary<string, Item>(capacity);
            weapons = new Dictionary<string, Weapon>();
            cloths = new Dictionary<string, Cloth>();
            tempItems = new Dictionary<string, Item>();
        }
        //constructor

        //Weapon Inventory
        public void WeaponInventory()
        {
            tempItems.Clear();

            List<Weapon> weaponSort = GameUtilities<Weapon>.ConvertDictToList(weapons);
            weaponSort.Sort();
            for (int i = 0; i < weaponSort.Count; i++)
                tempItems[weaponSort[i].Name] = weaponSort[i];
        }
        //Weapon Inventory

        //Cloth Inventory
        public void ClothInventory()
        {
            tempItems.Clear();

            List<Cloth> clothSort = GameUtilities<Cloth>.ConvertDictToList(cloths);
            clothSort.Sort();
            for (int i = 0; i < clothSort.Count; i++)
                tempItems[clothSort[i].Name] = clothSort[i];
        }

        //Store item
        public void StoreItem(Item item)
        {
            if (totalItem >= capacity)
                return;

            if (Items.ContainsKey(item.Name))
            {
                AddGold(Items[item.Name].Price);
                Items[item.Name] = item;
            }
            else
            {
                Items.Add(item.Name, item);
                totalItem++;
            }
        }
        //Store item


        //Sell item
        public void SellItem(Item item)
        {
            if (totalItem <= 0)
                return;

            if (Items.ContainsKey(item.Name))
            {
                AddGold(item.Price);
                Items.Remove(item.Name);
                totalItem--;
            }
            else 
                return;
        }
        //Sell item


        //Sell Rare and Epic items
        public void SellItem(Item item, bool condition)
        {
            if (!condition)
                return;
            else
                SellItem(item);
        }
        //Sell Rare and Epic items

        //Add gold
        public void AddGold(float value)
        { gold += value; }
        //Add gold


        //Show all item
        public void ShowAllItem()
        {
            //GameUtilities.SortInventory(items);

            foreach (string key in items.Keys)
                items[key].ShowInfor();

            Console.WriteLine();
            Console.WriteLine("Total items: " + items.Count);
            Console.WriteLine();
            Console.WriteLine("Gold: " + gold);
        }//Show all item

    }
}

