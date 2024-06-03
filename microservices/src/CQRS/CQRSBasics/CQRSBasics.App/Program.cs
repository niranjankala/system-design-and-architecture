using AutoMapper;
using Ninject;

namespace CQRSBasics.App
{
    internal class Program
    {
        static public IKernel kernel = new StandardKernel(); // ninject
        static public MapperConfiguration mappconfig = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


}
