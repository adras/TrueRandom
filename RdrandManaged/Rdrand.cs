using System.Runtime.InteropServices;

namespace RdrandManaged
{
    public class Rdrand
    {
        [DllImport("RdRandDll.dll", CharSet=CharSet.Unicode, SetLastError = true, EntryPoint = "rdrand_get_bytes")]
        public static extern int GetBytes(uint n, IntPtr ptr);

    }
}