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
        public T item;
        public string menuName = "";
        public List<MenuFunction> Functions;
        //Field


        //Constructor
        public Menu(string menuName, T item)
        {
            this.item = item;
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


        //Menu UI show
        public virtual void MenuUI()
        {
            Console.Clear();
            Console.WriteLine($"{this.menuName.ToUpper()} MANAGER MENU");

            GameUtilities.ShowLine(20);
            int index = 1;
            foreach (MenuFunction function in Functions)
            {
                Console.WriteLine($"{index}. {function.name} {menuName.ToLower()}");
                index++;
            }
            GameUtilities.ShowLine(20);

            int key;

            while (true)
            {
                Console.Write("Enter selection: ");
                bool input = int.TryParse(Console.ReadLine(), out key);

                if (input && (key > 0 && key <= Functions.Count))
                {
                    this.Functions[key - 1].function.Invoke();
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Try other option!\n");
            }
        }
        //Menu UI Show
    }
}
