using System.Runtime.InteropServices;

namespace RdrandManaged
{
    public class Rdrand
    {
        [DllImport("RdRandDll.dll", CharSet=CharSet.Unicode, SetLastError = true)]
        public static extern int GetBytes(uint n, IntPtr ptr);

    }
}