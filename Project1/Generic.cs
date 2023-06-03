using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Generic<T> where T : Item
    {
        //Convert Dictionary to List
        public static List<T> ConvertDictToList(Dictionary<string, T> items)
        {
            List<T> itemsList = new List<T>(items.Values);
            return itemsList;
        }
        //Convert Dictionary to List

    }
}
