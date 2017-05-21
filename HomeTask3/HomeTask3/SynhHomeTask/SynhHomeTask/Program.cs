using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynhHomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ListThreadSafe list = new ListThreadSafe();

            list.StartColculate();

            Console.ReadKey();
        }
    }
}
