using System;

namespace ngApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var toTs = new JsonToTs();
            toTs.ToNgService();
        }
    }
}
