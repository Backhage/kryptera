using kryptera.Encrypt;
using System;

namespace kryptera.IO
{
    internal sealed class ConsoleReader : ICharReader
    {
        public char Read()
        {
            var n = (char)Console.Read();
            return n;
        }
    }
}
