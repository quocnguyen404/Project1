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

        public Dictionary<string, Item> items;
        public Dictionary<string, Weapon> weapons;
        public Dictionary<string, Cloth> cloths;


        public float Gold { get => gold; }

        //constructor
        public Inventory()
        {
            totalItem = 0;
            gold = 0;
            items = new Dictionary<string, Item>(capacity);
        }
        //constructor
        

        //Store item
        public void StoreItem(Item item)
        {
            if (totalItem >= capacity)
                return;

            if (items.ContainsKey(item.Name))
            {
                AddGold(items[item.Name].Price);
                items[item.Name] = item;
            }
            else
            {
                items.Add(item.Name, item);
                totalItem++;
            }
        }
        //Store item

        //Sell item
        public void SellItem(Item item)
        {
            if (totalItem <= 0)
                return;

            if (items.ContainsKey(item.Name))
            {
                AddGold(item.Price);
                items.Remove(item.Name);
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
            Console.Clear();

            //GameUtilities.SortInventory(items);
            List<Item> itemList = Generic<Item>.ConvertDictToList(items);

            foreach (Item item in itemList)
                item.ShowInfor();

            GameUtilities.ShowLine(20);
            Console.WriteLine("Total items: " + items.Count);
            Console.WriteLine("Gold: " + gold);

            Console.ReadKey();
        }//Show all item

        //Show all weapon
        public void ShowAllWeapon()
        {
            foreach (string name in items.Keys)
                if (items[name] is Weapon)
                    weapons.Add(name, items[name] as Weapon);

            List<Weapon> weaponList = Generic<Weapon>.ConvertDictToList(weapons);
            weaponList.Sort();

            foreach(Weapon weapon in weaponList)
                weapon.ShowInfor();
            Console.WriteLine("Total weapon: " + weaponList.Count);

            Console.ReadKey();
        }
        //Show all weapon

        //Show all cloth
        public void ShowAllCloth()
        {
            foreach (string name in items.Keys)
                if (items[name] is Cloth)
                    cloths.Add(name, items[name] as Cloth);

            List<Cloth> clothList = Generic<Cloth>.ConvertDictToList(cloths);
            clothList.Sort();

            foreach (Cloth cloth in clothList)
                cloth.ShowInfor();
            Console.WriteLine("Total weapon: " + clothList.Count);

            Console.ReadKey();
        }
        //Show all cloth
    }
}

