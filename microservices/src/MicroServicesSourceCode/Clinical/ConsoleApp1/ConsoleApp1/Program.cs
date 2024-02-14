using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IExport ex = FactoryExport.Create(1);
            ex.Export();
        }
    }
}
