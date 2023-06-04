using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project1
{
    public class GamePanel
    {
        //Inventory
        public static Inventory inventory = new Inventory();


        //Update
        public static void Update(Item item) 
        {
            string type = GameUtilities.ItemType(item);

            if (inventory.totalItem <= 0)
            {
                Console.WriteLine($"There is no item in {type} inventory");

                Console.WriteLine("Type any key to back.");
                Console.ReadKey();
                return;
            }    

            Console.Clear();

            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();

            if (inventory.items.ContainsKey(name))
            {
                Console.WriteLine($"Enter new {type} name: ");
                inventory.items[name].Name = Console.ReadLine();

                Console.WriteLine($"Enter new {type} price: ");
                inventory.items[name].Price = int.Parse(Console.ReadLine());

                Console.WriteLine($"Udapte {type} {name} success!");
                Console.WriteLine("Type any key to back.");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine($"{name} don't exist in inventory.");
                Console.WriteLine("Type any key to back.");
                Console.ReadKey();
            }
        }
        //Update


        //Add
        public static void Add(Item item) 
        {
            Console.Clear();

            if (item is Weapon)
            {
                Weapon weapon = new Weapon();
                Console.Write("Enter weapon name: ");
                weapon.Name = Console.ReadLine();

                Console.Write("Enter weapon price: ");
                weapon.Price = int.Parse(Console.ReadLine());

                inventory.StoreItem(weapon);
                
                Console.WriteLine($"Add weapon {weapon.Name} success!");
                Console.WriteLine("Type any key to back.");

                Console.ReadKey();
            }
            else if (item is Cloth)
            {
                Cloth cloth = new Cloth();
                Console.Write("Enter cloth name: ");
                cloth.Name = Console.ReadLine();

                Console.Write("Enter cloth price: ");
                cloth.Price = int.Parse(Console.ReadLine());

                inventory.StoreItem(cloth);

                Console.WriteLine($"Add cloth {cloth.Name} success!");

                Console.WriteLine("Type any key to back.");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("WTF");
                Console.ReadKey();
            }
        }
        //Add
        

        //Sell
        public static void Sell(Item item)
        {
            string type = GameUtilities.ItemType(item);

            if (inventory.totalItem <= 0)
            {
                Console.WriteLine($"There is no item in {type} inventory");
                Console.WriteLine("Type any key to back.");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();

            if (inventory.items.ContainsKey(name))
            {
                float gold = inventory.items[name].Price;
                inventory.SellItem(inventory.items[name]);
                Console.WriteLine($"Sell {type} success!");
                Console.WriteLine($"Add {gold} golds to inventory");

            }
            else
                Console.WriteLine($"{name} don't exist in inventory.");
        }
        //Sell

        //Show all
        public static void ShowAll(Item item) 
        {
            if (item is Weapon)
                inventory.ShowAllWeapon();
            else if (item is Cloth)
                inventory.ShowAllCloth();
            else
            {
                Console.WriteLine("Undefine");
                Console.ReadKey();
            }
        }
        //Show all

    }
}
