using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public static class GameUtilities
    {

        public static void ShowInfor(List<Item> items)
        {
            foreach (Item item in items)
            {
                item.ShowInfor();
            }
        }

        //show infor of List<Weapon>
        public static void ShowInfor(List<Weapon> weapons)
        {
            foreach (Weapon weapon in weapons)
            {
                weapon.ShowInfor();
            }
        }
        //show infor of List<Weapon>

        //Get random value
        public static int GetRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //Get random value

        //Get random item
        public static Item GetRandomItem()
        {
            int ranNum = GetRandom(0, 100);

            if (ranNum % 2 == 0)
                return new Weapon();
            else
                return new Cloth();
        }
        //Get random item

        //CAN STORE CONDITION
        //store new item
        // item that exist in inventory --> can't store
        // if it's price greater than item's price already in inventory --> can store
        public static bool CanStore(Item item, Dictionary<string, Item> Items)
        {
            bool CanStore = true;

            if (Items.ContainsKey(item.Name))
            {
                CanStore = false;
                if (item.Price > Items[item.Name].Price)
                    CanStore = true;
            }

            return CanStore;
        }
        // CAN STORE CONDITION

        // check weapon quality is Epic or Rare
        public static bool IsEpicRare(Item item)
        {
            bool condition = false;
            Weapon weapon = item as Weapon;
            if (weapon == null)
                return condition;
            else
            {
                if ((int)weapon.Quality == 2 || (int)weapon.Quality == 3)
                    condition = true;
            }

            return condition;
        }
        // check weapon quality is Epic or Rare

        //Convert Dictionary to List
        public static List<Item> ConvertDictToList(Dictionary<string, Item> items)
        {
            List<Item> itemsList = new List<Item>(items.Values);
            return itemsList;
        }
        //Convert Dictionary to List

        //Sorting inventory
        public static void SortInventory(Dictionary<string, Item> items)
        {
            List<Item> itemsList = ConvertDictToList(items);
            //itemsList.Sort();

            List<Weapon> weaponList = new List<Weapon>();
            List<Cloth> clothList = new List<Cloth>();

            foreach (Item item in itemsList)
            {
                if (item is Weapon)
                    weaponList.Add(item as Weapon);
                else
                    clothList.Add(item as Cloth);
            }

            weaponList.Sort();
            clothList.Sort();

            itemsList.Clear();

            itemsList.AddRange(weaponList);
            itemsList.AddRange(clothList);

            int count = 0;
            foreach (string key in items.Keys)
            {
                items[key] = itemsList[count];
                count++;
            }
        }
        //Sort inventory

        public static void ShowLine(int length)
        {
            for (int i = 0; i < length; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        public static string FirstName(string name)
        {
            return name.Split()[0].ToLower();
        }



        //public static void ToDictionay(List<Item> items, Dictionary<string, Item> dictItems)
        //{
        //    foreach (Item item in items)
        //        dictItems[item.Name] = item;
        //}

        //public static Dictionary<string, Item> ToDictionary(List<Item> items)
        //{
        //    Dictionary<string, Item> inventory = new Dictionary<string, Item>();
        //    foreach (Item item in items)
        //    {
        //        inventory.Add(item.Name, item);
        //    }

        //    return inventory;
        //}

        //public static void SellEpicAndRare(Inventory inventory)
        //{
        //    Dictionary<string, Item> Items = inventory.Items;

        //    List<Item> weapons = new List<Item>();

        //    foreach (string key in Items.Keys)
        //    {
        //        if (Items[key] is Weapon)
        //        {
        //            weapons.Add(Items[key]);
        //        }
        //    }

        //    foreach (Weapon weapon in weapons)
        //    {
        //        if ((int)weapon.Quality == 2 || (int)weapon.Quality == 3)
        //            inventory.SellItem(weapon);
        //    }
        //}

        //public static Item[] RemoveItem(Item[] arr, int index)
        //{
        //    Item[] newArr = new Item[arr.Length - 1];

        //    for (int i = 0; i < arr.Length - 1; i++)
        //    {
        //        if (i < index)
        //            newArr[i] = arr[i];
        //        else
        //            newArr[i] = arr[i + 1];
        //    }

        //    return newArr;
        //}
    }
}
