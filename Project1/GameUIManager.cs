using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GameUIManager
    {
        public Menu<Item> item;
        public Menu<Weapon> weapon;
        public Menu<Cloth> cloth;

        public GameUIManager()
        {
            MenuGenerate();
        }

        public void MenuGenerate()
        {
            item = new Menu<Item>("Inventory");
            weapon = new Menu<Weapon>("Weapons");
            cloth = new Menu<Cloth>("Cloths");

            item.AddFunction("Show inventory information", () => GamePanel.inventory.ShowAllItem());

            weapon.AddFunction("Update", () => GamePanel.Update(Menu<Weapon>.item));
            weapon.AddFunction("Add", () => GamePanel.Add(Menu<Weapon>.item));
            weapon.AddFunction("Sell", () => GamePanel.Sell(Menu<Weapon>.item));
            weapon.AddFunction("Show all", () => GamePanel.ShowAll(Menu<Weapon>.item));

            cloth.AddFunction("Update", () => GamePanel.Update(Menu<Cloth>.item));
            cloth.AddFunction("Add", () => GamePanel.Add(Menu<Cloth>.item));
            cloth.AddFunction("Sell", () => GamePanel.Sell(Menu<Cloth>.item));
            cloth.AddFunction("Show all", () => GamePanel.ShowAll(Menu<Cloth>.item));
        }

        public void ShowBaseMenu()
        {
            Console.Clear();
            Console.WriteLine("INVENTORY MANAGER MENU");
            GameUtilities.ShowLine(20);

            Console.WriteLine("1. Weapon manger.");
            Console.WriteLine("2. Cloth manger.");
            Console.WriteLine("3. Inventory manger.");

            GameUtilities.ShowLine(20);
            Console.Write("Enter selection: ");
            int key = int.Parse(Console.ReadLine());

            switch (key)
            {
                case 1:
                    weapon.MenuUI();
                    break;
                case 2:
                    cloth.MenuUI();
                    break;
                case 3:
                    item.MenuUI();
                    break;
            }

        }
        
    }
   

}
