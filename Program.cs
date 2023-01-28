using System;
using System.Linq;

namespace ConsoleApp007
{
    class Program
    {
        static void Main()
        {
            FileHelper.ReverseFileLines(@"D:\stringtext.txt");
            FileEncryptor.Encrypt(@"D:\text.txt", @"D:\encryptedtext.txt", "data");
            FileEncryptor.Decrypt(@"D:\encryptedtext.txt", @"D:\decryptedtext.txt", "data");
            string inputPath = @"D:\G15.txt";
            string outputPath = @"D:\G15_2.txt";

            FileHelper.EnumerateFileLines(inputPath, outputPath);

            Console.WriteLine($"Sum of the numbers in file is {FileHelper.GetSumFromFile(@"D:\Numbers.txt")}");

            Console.WriteLine();

            Console.WriteLine($"There are {FileHelper.GetSymbolsCount(inputPath)} symbol in the file.");

            Console.WriteLine();

            Console.WriteLine($"There are {FileHelper.GetWordsCount(inputPath)} word in the file.");

            Console.WriteLine();

            var symbolsSequence = FileHelper.GetSymbolsSequence(inputPath);
            foreach (var item in symbolsSequence)
            {
                Console.WriteLine($"Symbol: {item.Key} - Count: {item.Value}");
            }
        }
    }
}