using System.Runtime.CompilerServices;

namespace RdrandManaged
{
    /// <summary>
    /// Wrapper around nrandom.h that allows easy access to intel cpu random generator
    /// </summary>
    public class IntelRandom
    {
        /// <summary>
        /// Creates a new instance of IntelRandom
        /// </summary>
        /// <remarks>Let's put it this way, true random doesn't require a seed</remarks>
        public IntelRandom()
        {
        }

        public ushort GetUShort()
        {
            ushort[] u16 = new ushort[1];

            RdrandStatus result = RdRandBindings.rdrand_16(u16, 1);
            ThrowIfNotSuccessful(result);
            
            return u16[0];
        }
        public uint GetUInt()
        {
            uint[] u32 = new uint[1];

            RdrandStatus result = RdRandBindings.rdrand_32(u32, 1);
            ThrowIfNotSuccessful(result);

            return u32[0];
        }
        public ulong GetULong()
        {
            ulong[] u64 = new ulong[1];

            RdrandStatus result = RdRandBindings.rdrand_64(u64, 1);
            ThrowIfNotSuccessful(result);

            return u64[0];
        }

        // TODO: Implement ..._n_ variants to get arrays of ushort, etc

        public byte[] GetBytes(uint size)
        {
            byte[] bytes = new byte[size];
            RdrandStatus result = (RdrandStatus)RdRandBindings.rdrand_get_bytes(size, bytes);
            ThrowIfNotSuccessful(result);

            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowIfNotSuccessful(RdrandStatus result)
        {
            if (result != RdrandStatus.RDRAND_SUCCESS)
            {
                switch (result)
                {
                    case RdrandStatus.RDRAND_NOT_READY:
                        throw new InvalidOperationException("RDRAND_NOT_READY");
                    case RdrandStatus.RDRAND_SUPPORTED:
                        throw new InvalidOperationException("RDRAND_SUPPORTED");
                    case RdrandStatus.RDRAND_UNSUPPORTED:
                        throw new InvalidOperationException("RDRAND_UNSUPPORTED");
                    case RdrandStatus.RDRAND_SUPPORT_UNKNOWN:
                        throw new InvalidOperationException("UNKNOWN");
                }
            }
        }
    }
}