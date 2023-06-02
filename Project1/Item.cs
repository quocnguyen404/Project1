using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public class Item/* : IComparable<Item>*/
    {
        public enum _Type
        {
            Cloth = 1,
            Weapon,
        }

        protected int id;
        protected string name = "";
        protected float price;
        protected _Type type;

        public int itemID { get => id; }
        public string Name { get => name; }
        public virtual float Price { get => price; }
        public _Type Type { get => type; }

        public int CompareTo(Item other)
        {
            if (other == null) return -1;

            return -this.Type.CompareTo(other.Type);
        }

        public Item()
        {
            id = GetHashCode();
            name = GetType().Name + " " + "0" + " " + GameUtilities.GetRandom(0, 10);
            price = GameUtilities.GetRandom(5, 10);
        }

        public virtual void ShowInfor()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Item ID: " + itemID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
        }

    }

}
