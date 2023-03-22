using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RdrandApp
{
    internal class Program
    {
        [DllImport("rdrand.dll")]
        public static extern int rdrand_16([MarshalAs(UnmanagedType.LPArray)] ushort[] x, int retry);

        [DllImport("rdrand.dll")]
        public static extern int rdrand_32([MarshalAs(UnmanagedType.LPArray)] uint[] x, int retry);

        [DllImport("rdrand.dll")]
        public static extern int rdrand_64([MarshalAs(UnmanagedType.LPArray)] ulong[] x, int retry);

        [DllImport("rdrand.dll")]
        public static extern int rdrand_get_n_32(uint n, [MarshalAs(UnmanagedType.LPArray)] uint[] x);

        [DllImport("rdrand.dll")]
        public static extern int rdrand_get_n_64(uint n, [MarshalAs(UnmanagedType.LPArray)] ulong[] x);

        [DllImport("rdrand.dll")]        
        public static extern int rdrand_get_bytes(uint n, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

        private const int BUFFSIZE = 1275;
        static void Main(string[] args)
        {
            ushort[] u16 = new ushort[1];
            uint[] u32 = new uint[1];
            ulong[] u64 = new ulong[1];

            uint[] array32 = new uint[10];
            ulong[] array64 = new ulong[10];

            byte[] buffer = new byte[BUFFSIZE];

            int r;

            r = rdrand_16(u16, 1);
            if (r != 1) Console.WriteLine("rdrand instruction failed with code " + r);
            r = rdrand_32(u32, 1);
            if (r != 1) Console.WriteLine("rdrand instruction failed with code " + r);
            r = rdrand_64(u64, 1);
            if (r != 1) Console.WriteLine("rdrand instruction failed with code " + r);

            Console.WriteLine("uint16: " + u16[0]);
            Console.WriteLine("uint32: " + u32[0]);
            Console.WriteLine("uint64: " + u64[0]);

            r = rdrand_get_n_32(10, array32);
            if (r != 1) Console.WriteLine("rdrand instruction failed with code " + r);
            if (r == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("10 uint32's:");
                for(int i=0; i<10;i++)
                    Console.WriteLine(array32[i]);
                Console.WriteLine("");
            }

            r = rdrand_get_n_64(10, array64);
            if (r != 1) Console.WriteLine("rdrand instruction failed with code " + r);
            if (r == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("10 uint64's:");
                for (int i = 0; i < 10; i++)
                    Console.WriteLine(array64[i]);
                Console.WriteLine("");
            }

            r = rdrand_get_bytes(BUFFSIZE, buffer);
            if (r == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Buffer of " + BUFFSIZE + " bytes:");
                for (int i = 0; i < BUFFSIZE; i++)
                {
                    Console.Write(buffer[i].ToString("x2"));
                    if (i % 16 == 15)
                        Console.WriteLine();
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }
            else
                Console.WriteLine("rdrand instruction failed with code " + r);

            Console.ReadKey(true);
        }
    }
}
