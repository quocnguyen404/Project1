using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Program
    {

        public static GameUIManager gameUIManager = new GameUIManager();

        public static void Main(string[] args)
        {

            while (true)
            {
                gameUIManager.ShowBaseMenu();
            }
            
        }
        public static void WeaponMenu()
        {
            gameUIManager.weapon.MenuUI();
        }

        public static void ClothMenu()
        {
            gameUIManager.cloth.MenuUI();
        }

        public static void InventoryMenu()
        {
            gameUIManager.item.MenuUI();
        }

        public static void MainMenu()
        {
            gameUIManager.menu.MenuUI();
        }
    }
}
