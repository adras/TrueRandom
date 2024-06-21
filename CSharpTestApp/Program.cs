using RdrandManaged;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace CSharpTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[1024];
            IntelRandom random = new IntelRandom();
            buffer = random.GetBytes(1200);

        }
    }
}