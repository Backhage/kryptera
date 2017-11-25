using kryptera.Encrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace krypteraTester
{
    [TestClass]
    public class EncryptTests
    {
        [TestMethod]
        public void Encrypt_GivenCharA_ShouldReturnB()
        {
            var input = new List<char> { 'A', 'a' };
            var expectedOutput = new List<char> { 'B', 'b' };
            VerifyEncryption(input, expectedOutput);
        }

        [TestMethod]
        public void Encrypt_GivenABC_ShouldReturnBCD()
        {
            var input = new List<char> { 'A', 'B', 'C', 'a', 'b', 'c' };
            var expectedOutput = new List<char> { 'B', 'C', 'D', 'b', 'c', 'd' };
            VerifyEncryption(input, expectedOutput);
        }

        [TestMethod]
        public void Encrypt_GivenASpaceB_ShouldReturnBSpaceC()
        {
            var input = new List<char> { 'A', ' ', 'B', 'a', ' ', 'b' };
            var expectedOutput = new List<char> { 'B', ' ', 'C', 'b', ' ', 'c' };
            VerifyEncryption(input, expectedOutput);
        }

        [TestMethod]
        public void Encrypt_GivenZ_ShouldReturnA()
        {
            var input = new List<char> { 'Z', 'z' };
            var expectedOutput = new List<char> { 'A', 'a' };
            VerifyEncryption(input, expectedOutput);
        }

        private void VerifyEncryption(IList<char> input, IList<char> expectedOutput)
        {
            var testCharReader = new TestCharReader();
            var testCharWriter = new TestCharWriter();
            var encrypt = new Encrypt(testCharReader, testCharWriter);
            testCharReader.AddInput(input);

            encrypt.Run();

            var output = testCharWriter.GetOutput();
            Assert.AreEqual(input.Count, output.Count);
            for (var i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(expectedOutput[i], output[i]);
            }
        }

        private class TestCharReader : ICharReader
        {
            private List<char> chars;

            public TestCharReader()
            {
                chars = new List<char>();
            }

            public char Read()
            {
                if (chars.Count == 0)
                {
                    return '\0';
                }

                var c = chars[0];
                chars.RemoveAt(0);
                return c;
            }

            public void AddInput(IList<char> input)
            {
                foreach (var c in input)
                {
                    chars.Add(c);
                }
            }
        }

        private class TestCharWriter : ICharWriter
        {
            private readonly List<char> output;

            public TestCharWriter()
            {
                output = new List<char>();
            }

            public void Write(char c)
            {
                output.Add(c);
            }

            public IList<char> GetOutput()
            {
                return output;
            }
        }
    }
}
