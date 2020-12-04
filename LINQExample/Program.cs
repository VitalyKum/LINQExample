using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
 
    class Program
    {
        static void Main(string[] args)
        {
            new Query1("Aleksey", "Aleksey").Execute();
            new Query2("Ivan", "Ivan").Execute();
            new Query3("Peter", "Peter").Execute();
            new Query4().Execute();
            new Query5(1000).Execute();

            Console.ReadKey();

        }

             
    }
}
