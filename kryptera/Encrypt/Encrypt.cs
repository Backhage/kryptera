namespace kryptera.Encrypt
{
    public class Encrypt
    {
        private readonly ICharReader charReader;
        private readonly ICharWriter charWriter;

        public Encrypt(ICharReader charReader, ICharWriter charWriter)
        {
            this.charReader = charReader;
            this.charWriter = charWriter;
        }

        public void Run()
        {
            var next = charReader.Read();
            while (next != '\0')
            {
                var encoded = Encode(next);
                charWriter.Write(encoded);
                next = charReader.Read();
            }
        }

        private char Encode(char c)
        {
            if (c == ' ' || c == '\n' || c >= '0' && c <= '9')
            {
                return c;
            }
            else if (c >= 'a' && c <= 'z')
            {
                return (char)(c == 'z' ? 'a' : c + 1);
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return (char)(c == 'Z' ? 'A' : c + 1);
            }
            return '\0';
        }
    }
}
