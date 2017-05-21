using System.Collections.Generic;
using System.Threading;

namespace HomeTask3_3
{
    class ThreadList
    {
        private List<double> _listS = new List<double>();
        private List<double> _listR = new List<double>();

        private Thread _a;
        private Thread _b;
        private Thread _c;
        private Thread _d;

        public void Deadlock()
        {
            var th1 = new Thread(() =>
            {
                lock (_listS)
                {
                    Thread.Sleep(1000);
                    lock (_listR)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
            th1.Start();
            var th2 = new Thread(() =>
            {
                lock (_listR)
                {
                    Thread.Sleep(1000);
                    lock (_listS)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
            th2.Start();
        }
    }
}
