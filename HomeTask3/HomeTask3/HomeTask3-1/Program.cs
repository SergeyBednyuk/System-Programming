using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HomeTask3_1
{
    class Program
    {
        //public delegate void ExampleCallback(int lineCount);

        public class ThreadWithState
        {
            //// State information used in the task.
            //private string boilerplate;
            //private int value;
            //private ExampleCallback callback;

            //public ThreadWithState(string text, int number,ExampleCallback callbackDelegate)
            //{
            //    boilerplate = text;
            //    value = number;
            //    callback = callbackDelegate;
            //}

            //// The thread procedure performs the task, such as
            //// formatting and printing a document, and then invokes
            //// the callback delegate with the number of lines printed.
            //public void ThreadProc()
            //{
            //    Console.WriteLine(boilerplate, value);
            //    if (callback != null)
            //        callback(1);
            //}
        }
        static void Main(string[] args)
        {

            //// Supply the state information required by the task.
            //ThreadWithState tws = new ThreadWithState("This report displays the number {0}.",42,new ExampleCallback(ResultCallback));

            //Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            //t.Start();
            //Console.WriteLine("Main thread does some work, then waits.");
            //t.Join();
            //Console.WriteLine(
            //    "Independent task has completed; main thread ends.");

            //я несовсем уверен правельно ли я понял задание:)
            SafeThreadList lists = new SafeThreadList();

            lists.StartColculate();
           
        
            Console.ReadKey();
        }

        // The callback method must match the signature of the
        // callback delegate.
        //
        //public static void ResultCallback(int lineCount)
        //{
        //    Console.WriteLine(
        //        "Independent task printed {0} lines.", lineCount);
        //}
    
    }
}
