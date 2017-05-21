using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynhHomeTask
{
    class ListThreadSafe
    {
        private List<double> _listS = new List<double>();
        private List<double> _listR = new List<double>();

        private Thread _a;
        private Thread _b;
        private Thread _c;
        private Thread _d;


        public void StartColculate()
        {
            //Thread A
            _a = new Thread(() =>
            {
                lock (_listS)
                {
                    _listS.Add(1);
                    _listS.Add(2);
                    _listS.Add(3);
                }
               
            });
            //Thread B
            _b = new Thread(() =>
            {
                lock (_listS)
                {
                    var lastElement = _listS.Last();
                    if (lastElement == null)
                    {
                        Thread.Sleep(1000);
                    }
                    lastElement = Math.Sqrt(lastElement);
                    lock (_listR)
                    {
                        _listR.Add(lastElement);
                    }
                }
            }
            );
            //Thread C
            _c = new Thread(() =>
            {
                lock (_listS)
                {
                    var lastElement = _listS.Last();
                    if (lastElement == null)
                    {
                        Thread.Sleep(1000);
                    }

                    try
                    {
                        lastElement /= 3;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Divide by zero");
                    }
                    lock (_listR)
                    {
                        _listR.Add(lastElement);
                    }
                }
            }
            );
            //Thread D
            _d = new Thread(() =>
            {
                lock (_listR)
                {
                    var lastElement = _listR.Last();
                    if (lastElement == null)
                    {
                        Console.WriteLine("Last element == null");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Last element from list R - {0}", lastElement);
                }
            }
            );
        }
    }
}
