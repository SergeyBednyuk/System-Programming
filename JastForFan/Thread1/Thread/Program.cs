using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadCanselettocen
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task1 = new Task(() => Factorial(5, token));
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y")
                cancelTokenSource.Cancel();

            Console.ReadLine();
        }

        static void Factorial(int x, CancellationToken token)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine("Факториал числа {0} равен {1}", i, result);
                Thread.Sleep(5000);
            }
        }
    }
}
