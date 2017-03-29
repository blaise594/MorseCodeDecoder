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
            var translating = true;
            while (translating)
                {
                Console.WriteLine("Enter your message here.");
                var input = Console.ReadLine().ToUpper();
                var userMorse = String.Empty;
                foreach (var letter in input)
                {
                    var temp = morsecodedictionary[letter.ToString()];
                    userMorse += temp;
                    Console.WriteLine(temp);
                }

                // input, userMorse
                using (StreamWriter sw = File.AppendText("output.csv"))
                {
                    sw.WriteLine($"{input},{userMorse}");
                }
                Console.WriteLine("Would you like to continue? [y/n]");
                var answer = Console.ReadLine();
                if (answer == "n")
                {
                    translating = false;
                }

            }
        }

    }

}
