using System.Runtime.InteropServices;

namespace RdrandManaged
{
    public enum RdrandStatus
    {
        RDRAND_SUCCESS = 1,
        RDRAND_NOT_READY = -1,
        RDRAND_SUPPORTED = -2,
        RDRAND_UNSUPPORTED = -3,
        RDRAND_SUPPORT_UNKNOWN = -4
    }


    public class RdRandBindings
    {
        const string DLL_NAME = "rdrand.dll";

        [DllImport(DLL_NAME)]
        public static extern RdrandStatus rdrand_16([MarshalAs(UnmanagedType.LPArray)] ushort[] x, int retry);

        [DllImport(DLL_NAME)]
        public static extern RdrandStatus rdrand_32([MarshalAs(UnmanagedType.LPArray)] uint[] x, int retry);

        [DllImport(DLL_NAME)]
        public static extern RdrandStatus rdrand_64([MarshalAs(UnmanagedType.LPArray)] ulong[] x, int retry);

        [DllImport(DLL_NAME)]
        public static extern RdrandStatus rdrand_get_n_32(uint n, [MarshalAs(UnmanagedType.LPArray)] uint[] x);

        [DllImport(DLL_NAME)]
        public static extern RdrandStatus rdrand_get_n_64(uint n, [MarshalAs(UnmanagedType.LPArray)] ulong[] x);

        [DllImport(DLL_NAME)]
        public static extern int rdrand_get_bytes(uint n, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

    }
}