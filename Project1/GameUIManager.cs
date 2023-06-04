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
        //Field
        public Menu<Item> item;
        public Menu<Weapon> weapon;
        public Menu<Cloth> cloth;
        //Field

        //Constructor
        public GameUIManager()
        {
            MenuGenerate();
        }
        //Constructor


        //Menu setting
        private void MenuGenerate()
        {
            Item items = new Item();
            Weapon weapons = new Weapon();
            Cloth cloths = new Cloth();

            item = new Menu<Item>("Inventory", items);
            weapon = new Menu<Weapon>("Weapons", weapons);
            cloth = new Menu<Cloth>("Cloths", cloths);

            item.AddFunction("Show inventory information", () => GamePanel.inventory.ShowAllItem());

            weapon.AddFunction("Update", () => GamePanel.Update(weapon.item));
            weapon.AddFunction("Add", () => GamePanel.Add(weapon.item));
            weapon.AddFunction("Sell", () => GamePanel.Sell(weapon.item));
            weapon.AddFunction("Show all", () => GamePanel.ShowAll(weapon.item));

            cloth.AddFunction("Update", () => GamePanel.Update(cloth.item));
            cloth.AddFunction("Add", () => GamePanel.Add(cloth.item));
            cloth.AddFunction("Sell", () => GamePanel.Sell(cloth.item));
            cloth.AddFunction("Show all", () => GamePanel.ShowAll(cloth.item));
        }
        //Menu setting


        //BaseMenu
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
        //Base Menu
    }
}
