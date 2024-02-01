using System;
using System.Linq;
using System.Text;

namespace AdvancedCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your text:");
            string inputText = Console.ReadLine();

            Console.WriteLine("Enter the key (word):");
            string key = Console.ReadLine();

            string cipheredText = VigenereCipher(inputText, key);

            Console.WriteLine("Original Text: " + inputText);
            Console.WriteLine("Ciphered Text: " + cipheredText);
        }

        static string VigenereCipher(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            key = key.ToUpper();

            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    c = (char)((c + key[j] - 2 * (isUpper ? 'A' : 'a')) % 26 + (isUpper ? 'A' : 'a'));
                    j = (j + 1) % key.Length;
                }
                result.Append(c);
            }

            return result.ToString();
        }
    }
}
