using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3_3
{
    class Program
    {
        static void Main(string[] args)
        {

            SafeThreadList sf = new SafeThreadList();

            sf.StartColculate();

            Console.ReadKey();
        }
    }
}
