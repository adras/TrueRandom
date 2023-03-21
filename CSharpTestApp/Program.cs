using RdrandManaged;
using System.Net.NetworkInformation;

namespace CSharpTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int test = Rdrand.GetBytes(1000, new IntPtr(1000));
        }
    }
}