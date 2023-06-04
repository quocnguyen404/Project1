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
        public Menu<Item> menu;
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
            //Type object pass
            Item items = new Item();
            Weapon weapons = new Weapon();
            Cloth cloths = new Cloth();
            //Type object pass

            //Initializationz menu
            menu = new Menu<Item>("Main", items);
            item = new Menu<Item>("Inventory", items);
            weapon = new Menu<Weapon>("Weapons", weapons);
            cloth = new Menu<Cloth>("Cloths", cloths);
            //Initializationz menu

            menu.AddFunction("Weapon menu", () => Program.WeaponMenu());
            menu.AddFunction("Cloth menu", () => Program.ClothMenu());
            menu.AddFunction("Inventory menu", () => Program.InventoryMenu());

            item.AddFunction("Show inventory information", () => GamePanel.inventory.ShowAllItem());
            item.AddFunction("Back", () => Program.MainMenu());

            weapon.AddFunction("Update", () => GamePanel.Update(weapon.item));
            weapon.AddFunction("Add", () => GamePanel.Add(weapon.item));
            weapon.AddFunction("Sell", () => GamePanel.Sell(weapon.item));
            weapon.AddFunction("Show all", () => GamePanel.ShowAll(weapon.item));
            weapon.AddFunction("Back", () => Program.MainMenu());

            cloth.AddFunction("Update", () => GamePanel.Update(cloth.item));
            cloth.AddFunction("Add", () => GamePanel.Add(cloth.item));
            cloth.AddFunction("Sell", () => GamePanel.Sell(cloth.item));
            cloth.AddFunction("Show all", () => GamePanel.ShowAll(cloth.item));
            cloth.AddFunction("Back", () => Program.MainMenu());
        }
        //Menu setting

        //BaseMenu
        public void ShowBaseMenu()
        {
            menu.MenuUI();
        }
        //Base Menu
    }
}
