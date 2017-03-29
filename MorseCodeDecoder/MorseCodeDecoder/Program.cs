using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {   
            var path = "morse.csv";
            Dictionary<string, string> morsecodedictionary = new Dictionary<string, string>();

            using (var reader = new StreamReader(path))
            {
                
                while (reader.Peek() > -1)
                {
                    var code = reader.ReadLine();
                    Console.WriteLine(code);
                    var split = code.Split(',');
                    morsecodedictionary.Add(split[0], split[1]);


                }

            }
            Console.WriteLine("Enter your message here.");
            var input=Console.ReadLine().ToUpper();
            foreach (var letter in input)
            {
                Console.WriteLine(morsecodedictionary[letter.ToString()]);
            }

        }
    }
}
