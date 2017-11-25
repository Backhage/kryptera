using kryptera.Encrypt;
using System;

namespace kryptera.IO
{
    internal sealed class ConsoleWriter : ICharWriter
    {
        public void Write(char c)
        {
            Console.Write(c);
        }
    }
}
