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
        //unique GameUiManager instance
        private static GameUIManager instance;


        //Field
        private Menu<Item> menu;
        private Menu<Item> item;
        private Menu<Weapon> weapon;
        private Menu<Cloth> cloth;
        //Field


        //Properties
        public static GameUIManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameUIManager();
                return instance;
            }
        }

        public Menu<Item> Menu => menu;
        public Menu<Item> Item => item;
        public Menu<Weapon> Weapon => weapon;
        public Menu<Cloth> Cloth => cloth;
        //Properties


        //Constructor
        private GameUIManager()
        {
            MenuGenerate();
            AddMainMenuFunction();
            AddInventoryMenuFunction();
            AddWeaponMenuFunction();
            AddClothMenuFunction();
        }
        //Constructor

        //Show base Menu
        public void ShowBaseMenu()
        {
            menu.MenuUI();
        }
        //Show base Menu

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
        }
        //Menu setting

        //Add function to main menu
        private void AddMainMenuFunction()
        {
            menu.AddFunction("Weapon menu", () => WeaponMenu());
            menu.AddFunction("Cloth menu", () => ClothMenu());
            menu.AddFunction("Inventory menu", () => InventoryMenu());
        }


        //Add function to Inventory menu
        private void AddInventoryMenuFunction()
        {
            item.AddFunction("Show inventory information", () => Inventory.Instance.ShowAllItem());
            item.AddFunction("Back", () => MainMenu());
        }


        //Add function to Weapon menu
        private void AddWeaponMenuFunction()
        {
            weapon.AddFunction("Update", () => GamePanel.Update(weapon.item));
            weapon.AddFunction("Add", () => GamePanel.Add(weapon.item));
            weapon.AddFunction("Sell", () => GamePanel.Sell(weapon.item));
            weapon.AddFunction("Show all", () => GamePanel.ShowAll(weapon.item));
            weapon.AddFunction("Back", () => MainMenu());
        }


        //Add function to Cloth menu
        private void AddClothMenuFunction()
        {
            cloth.AddFunction("Update", () => GamePanel.Update(cloth.item));
            cloth.AddFunction("Add", () => GamePanel.Add(cloth.item));
            cloth.AddFunction("Sell", () => GamePanel.Sell(cloth.item));
            cloth.AddFunction("Show all", () => GamePanel.ShowAll(cloth.item));
            cloth.AddFunction("Back", () => MainMenu());
        }
        //Add function to Cloth menu


        //Switch menu method
        public static void WeaponMenu()
        {
            Instance.Weapon.MenuUI();
        }

        public static void ClothMenu()
        {
            Instance.Cloth.MenuUI();
        }

        public static void InventoryMenu()
        {
            Instance.Item.MenuUI();
        }

        public static void MainMenu()
        {
            Instance.Menu.MenuUI();
        }
        //Switch menu method
    }
}
