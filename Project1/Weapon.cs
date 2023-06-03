using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Weapon : Item, IComparable<Weapon>
    {
        public enum _Quality
        {
            Common = 1,
            Rare,
            Epic,
            Legendary,
        }

        protected int level;
        protected _Quality quality;

        public int Level { get => level; }
        public _Quality Quality { get => quality; }

        public override float Price => base.Price/* * Level * (float)Quality*/;

        public int CompareTo(Weapon other)
        {
            if (other == null)
                return -1;

            if (this.Quality > other.Quality)
                return -1;
            else if (this.Quality < other.Quality)
                return 1;
            else
            {
                return -this.Level.CompareTo(other.Level);
            }
        }

        public Weapon()
        {
            quality = (_Quality)GameUtilities.GetRandom(1, 4);
            level = GameUtilities.GetRandom(1, 5);
            type = _Type.Weapon;
        }

        public override void ShowInfor()
        {
            base.ShowInfor();
            Console.WriteLine("Quality: " + Quality);
            Console.WriteLine("Level: " + Level);
        }

    }
}

