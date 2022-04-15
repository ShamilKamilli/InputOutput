using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            var helperBuffer = new char[512];
            int helperBufferEveryCount = 0;

            var buffer = new char[512];
            int count = 0;
            int copyCount = 0;

            do
            {
                if (count == buffer.Length)
                {
                    PutData(buffer, count);
                    count = 0;

                    if (helperBufferEveryCount > copyCount)
                    {
                        Array.Copy(helperBuffer, copyCount, buffer, 0, helperBufferEveryCount - copyCount);
                        count = helperBufferEveryCount - copyCount;
                    }
                }

                helperBufferEveryCount = GetData(out helperBuffer);

                copyCount = Math.Min(helperBufferEveryCount, buffer.Length - count);

                Array.Copy(helperBuffer, 0, buffer, count, copyCount);

                count += copyCount;

            } while (helperBufferEveryCount > 0);

            if (count > 0)
                PutData(buffer, count);
        }

        static int GetData(out char[] Buf)

        {
            Buf = Console.ReadLine().ToCharArray();

            return Buf.Length;
        }

        static void PutData(char[] Buf, int count)
        {
            Console.WriteLine(count);
        }
    }
}
