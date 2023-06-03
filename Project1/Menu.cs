using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Menu<T> where T : Item
    {
        //Field
        public static T item;
        public string menuName = "";
        private List<MenuFunction> Functions;
        //Field

        //Constructor
        public Menu(string menuName)
        {
            this.menuName = menuName;
            Functions = new List<MenuFunction>();
        }
        //Constructor


        //Add function to menu
        public void AddFunction(string name, Action function)
        {
            Functions.Add(new MenuFunction(name, function));
        }
        //Add function to menu


        //Menu UI Show
        public virtual void MenuUI()
        {
            Console.Clear();
            Console.WriteLine($"{this.menuName.ToUpper()} MENU MANAGER");
            GameUtilities.ShowLine(20);

            int index = 1;
            foreach (MenuFunction function in Functions)
            {
                Console.WriteLine($"{index}. {function.name} {menuName.ToLower()}");
                index++;
            }

            GameUtilities.ShowLine(20);

            Console.Write("Enter selection: ");
            int key = int.Parse(Console.ReadLine());

            this.Functions[key - 1].function.Invoke();
        }
        //Menu UI Show

    }
}
