﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           GameUIManager gameUIManager = new GameUIManager();

            while (true)
            {
                gameUIManager.ShowBaseMenu();

            }

        }
    }
}
