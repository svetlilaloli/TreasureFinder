using System;

namespace TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] key = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            string line = Console.ReadLine();

            while (line != "find")
            {
                string decrypted = "";
                int keyIndex = 0;
                
                // decrypting the message
                for (int i = 0; i < line.Length; i++)
                {
                    decrypted += (char)(line[i] - key[keyIndex]);
                    if (keyIndex < key.Length - 1)
                    {
                        keyIndex++;
                    }
                    else
                    {
                        keyIndex = 0;
                    }
                }
                
                // extracting the treasure type 
                int startIndex = decrypted.IndexOf('&');
                int endIndex = decrypted.IndexOf('&', startIndex + 1);
                string treasure = decrypted.Substring(startIndex + 1, endIndex - startIndex - 1);
                
                // extracting the coordinates
                startIndex = decrypted.IndexOf('<');
                endIndex = decrypted.IndexOf('>');
                string coordinates = decrypted.Substring(startIndex + 1, endIndex - startIndex - 1);
                
                Console.WriteLine($"Found {treasure} at {coordinates}");
                line = Console.ReadLine();
            }
        }
    }
}
