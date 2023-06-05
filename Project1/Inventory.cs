using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Inventory
    {
        //Field
        private static Inventory instance;

        private int capacity = 10;
        private int totalItem;
        private float gold;
        private int totalWeapon;
        private int totalCloth;

        public Dictionary<string, Item> items;
        public Dictionary<string, Weapon> weapons;
        public Dictionary<string, Cloth> cloths;
        //Field

        //Properties

        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                    instance = new Inventory();
                return instance;
            }
        }

        public float Gold { get => gold; }
        public int TotalItem { get => totalItem; }
        public int TotalWeapon { get => totalWeapon; }
        public int TotalCloth { get => totalCloth; }

        //Properties

        //Constructor
        private Inventory()
        {
            totalItem = 0;
            gold = 0;
            items = new Dictionary<string, Item>(capacity);
        }
        //Constructor
        

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


        //Sell particular items
        public void SellItem(Item item, bool condition)
        {
            if (!condition)
                return;
            else
                SellItem(item);
        }
        //Sell particular items


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
            Console.Clear();

            List<Weapon> weaponList = new List<Weapon>();

            foreach (string key in items.Keys)
            {
                if (items[key] is Weapon)
                    weaponList.Add(items[key] as Weapon);
            }

            weaponList.Sort();

            foreach(Weapon weapon in weaponList)
                weapon.ShowInfor();

            Console.WriteLine();
            Console.WriteLine("Total weapons: " + weaponList.Count);
            totalWeapon = weaponList.Count;

            Console.ReadKey();
        }
        //Show all weapon


        //Show all cloth
        public void ShowAllCloth()
        {
            Console.Clear();

            List<Cloth> clothList = new List<Cloth>();

            foreach (string key in items.Keys)
            {
                if (items[key] is Cloth)
                    clothList.Add(items[key] as Cloth);
            }

            foreach (Cloth cloth in clothList)
                cloth.ShowInfor();

            Console.WriteLine();
            Console.WriteLine("Total cloths: " + clothList.Count);
            totalCloth = clothList.Count;

            Console.ReadKey();
        }
        //Show all cloth
    }
}

