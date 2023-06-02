using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GameUIManager
    {
        public List<Menu> menus;

        public GameUIManager()
        {
            menus = new List<Menu>();

            MenuGenerate();
            AddFunction();
        }

        public void MenuGenerate()
        {
            menus[1] = new Menu("Weapons");
            menus[2] = new Menu("Cloths");
            menus[3] = new Menu("Inventory");
            menus[menus.Count + 1] = new Menu("Information");
        }

        public void AddFunction()
        {
            for (int i = 1; i < menus.Count - 1; i++)
            {
                menus[i].AddFunction("Update", () => { GamePanel.Update(Menu.inventory); });
                menus[i].AddFunction("Add", () => { GamePanel.Add(Menu.inventory); }) ;
                menus[i].AddFunction("Sell", () => { GamePanel.Sell(Menu.inventory); }) ;
                menus[i].AddFunction("Show all", () => { GamePanel.ShowAll(Menu.inventory); });
            }

            menus[menus.Count + 1].AddFunction("Show all", () => { Menu.inventory.ShowAllItem(); });
            menus[menus.Count + 1].AddFunction("Show gold", () => { Console.WriteLine(Menu.inventory.Gold); });
        }

        public void ShowBaseMenu()
        {
            Console.Clear();
            Console.WriteLine("INVENTORY MANAGER MENU");
            GameUtilities.ShowLine(20);

            for (int i = 1; i < menus.Count; i++)
                Console.WriteLine($"{i}. {menus[i].menuName} Manager");

            GameUtilities.ShowLine(20);
            Console.Write("Enter selection: ");
            int key = int.Parse(Console.ReadLine());
            menus[key].MenuUI();
        }
        
    }
   

}
