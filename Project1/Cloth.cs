using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Cloth : Item, IComparable<Cloth>
    {
        public enum _Rarity
        {
            Acient = 1,
            Shadow,
            GodLight,
            Eternal,
        }

        public int CompareTo(Cloth other)
        {
            if (other == null)
                return -1;

            if (this.Rarity > other.Rarity)
                return -1;
            else if (this.Rarity < other.Rarity)
                return 1;
            else
            {
                return -this.Star.CompareTo(other.Star);
            }
        }

        protected int star;
        protected _Rarity rarity;

        public int Star { get => star; }
        public _Rarity Rarity { get => rarity; }
        public override float Price => base.Price * Star * (float)Rarity;

        public Cloth()
        {
            star = GameUtilities.GetRandom(1, 5);
            rarity = (_Rarity)GameUtilities.GetRandom(1, 4);
            type = _Type.Cloth;
        }

        public override void ShowInfor()
        {
            base.ShowInfor();
            Console.WriteLine("Star: " + Star);
            Console.WriteLine("Rarity: " + Rarity);
        }

    }
}

