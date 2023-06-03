using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
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
