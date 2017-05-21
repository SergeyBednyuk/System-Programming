using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace WpfApplication1
{
    class Paths
    {
        //путь файла с которого копируют
        public string _pathIn;
        //путь файла в который копируют
        public string _pathOut;

        public void CopyFile()
        {
            

            byte[] arrtmp = new byte[0];

            //Read in file
            using (FileStream fs = File.OpenRead(_pathIn))
            {
                
                Array.Resize(ref arrtmp, (int) fs.Length);

                fs.Read(arrtmp, 0, arrtmp.Length);
            }

            //Write in file
            using (FileStream fs = new FileStream(_pathOut, FileMode.Append))
            {
                int _arr_count = arrtmp.Length/4096;
                for (int i = 0; i < _arr_count; i++)
                {
                    //Thread.Sleep(1000);
                    fs.Write(arrtmp, i*4096, 4096);
                }

                long divRem;
                Math.DivRem(arrtmp.Length, 4096, out divRem);

                fs.Write(arrtmp, arrtmp.Length - (int) divRem, (int) divRem);

            }
        }
    }
}
