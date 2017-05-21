using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HomeTask3_3
{
    class SafeThreadList
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
                    _listS.Add(11);
                    _listS.Add(22);
                    _listS.Add(33);
                }

            });
            _a.Start();
            //Thread B
            _b = new Thread(() =>
            {
                lock (_listS)
                {
                    try
                    {
                        lock (_listR)
                        {
                            _listR.Add(_listS.Last());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            );
            _b.Start();
            //Thread C
            _c = new Thread(() =>
            {
                lock (_listS)
                {
                    try
                    {
                        var lastElement = _listS.Last();
                        if (lastElement == null)
                        {
                            Thread.Sleep(1000);
                        }
                        lastElement /= 3;

                        lock (_listR)
                        {
                            _listR.Add(lastElement);
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Divide by zero");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            );
            _c.Start();
            //Thread D
            _d = new Thread(() =>
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            );
            _d.Start();
        }
    }
}
