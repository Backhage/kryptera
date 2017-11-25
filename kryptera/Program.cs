// This is a small father and son programming project.
// Even though it is small and just for fun it should be well written.

using kryptera.IO;
using System;

namespace kryptera
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteWelcomeMessage();
            RunEncryption();
        }

        private static void WriteWelcomeMessage()
        {
            Console.WriteLine("The secret club's encryption tool");
            Console.WriteLine("Type your input and press enter to encrypt");
            Console.WriteLine(Environment.NewLine);
        }

        private static void RunEncryption()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var encrypt = new Encrypt.Encrypt(reader, writer);
            encrypt.Run();
        }
    }
}
