using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.GamePanel;

namespace Project1
{
    public class Menu
    {
        public static Inventory inventory = new Inventory();
        public string menuName = "";
        List<MenuFunction> Functions;
        //GameUIManager gameUIManager = new GameUIManager();

        public Menu(string menuName)
        {
            this.menuName = menuName;
            Functions = new List<MenuFunction>();
        }

        public void AddFunction(string name, Action function)
        {
            Functions.Add(new MenuFunction(name, function));
        }

        public virtual void MenuUI()
        {
            Console.Clear();
            Console.WriteLine($"{this.menuName.ToUpper()} MENU MANAGER");
            GameUtilities.ShowLine(20);

            int index = 1;
            foreach (MenuFunction function in Functions)
            {
                Console.WriteLine($"{index}. {function.name} {menuName.ToLower()}");
            }

            GameUtilities.ShowLine(20);

            Console.Write("Enter selection: ");
            int key = int.Parse(Console.ReadLine());

            //if (key == 0)
            //    gameUIManager.ShowBaseMenu();

            this.Functions[key - 1].function.Invoke();
        }
    }

    public class MenuFunction
    {
        public string name;
        public Action function;

        public MenuFunction(string name, Action function)
        {
            this.name = name;
            this.function = function;
        }
    }

}
