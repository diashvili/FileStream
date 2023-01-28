namespace ConsoleApp007
{
    internal class FileHelper
    {
        public static double GetSumFromFile(string filePath)
        {
            double sum = 0;
            double num;
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();
                        if (double.TryParse(line, out num))
                        {
                            sum += num;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            return sum;
        }

        public static void ReverseFileLines(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    for (int i = lines.Length - 1; i >= 0; i--)
                    {
                        writer.WriteLine(lines[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int GetWordsCount(string inputFilePath)
        {
            int wordscount = 0;
            StreamReader reader = new(inputFilePath);
            string text = reader.ReadToEnd();
            reader.Close();
            bool firstword = true;
            for (int i = 0; i < text.Length - 2; i++)
            {
                if (firstword == true && text[i] != ' ' && text[i] != '\r')
                {
                    wordscount++;
                    firstword = false;
                }
                else if (text[i] == ' ' && text[i + 1] != ' ')
                {
                    wordscount++;
                    firstword = false;
                }
                else if (text[i] == '\r' && text[i + 2] != '\r' && text[i + 2] != ' ')
                {
                    wordscount++;
                }
            }

            return wordscount;
        }
        public static void EnumerateFileLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new(inputFilePath);
            StreamWriter writer = new(outputFilePath);
            int lineNumber = 1;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                writer.WriteLine($"{lineNumber}. {line}");
                lineNumber++;
            }

            reader.Close();
            writer.Close();
        }

        public static void EnumerateFileLines2(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new(inputFilePath);
            StreamWriter writer = new(outputFilePath);
            int lineNumber = 1;

            while (!reader.EndOfStream)
            {
                writer.WriteLine($"{lineNumber++}. {reader.ReadLine()}");
            }

            reader.Close();
            writer.Close();
        }

        public static int GetSymbolsCount(string inputFilePath)
        {
            int symbolsCount = 0;

            StreamReader reader = new(inputFilePath);
            string text = reader.ReadToEnd();
            reader.Close();

            foreach (char symbol in text)
            {
                if (symbol >= 'A' && symbol <= 'Z' || symbol >= 'a' && symbol <= 'z' || symbol >= '0' && symbol <= '9')
                {
                    symbolsCount++;
                }
            }

            return symbolsCount;
        }

        public static SortedDictionary<char, int> GetSymbolsSequence(string inputFilePath)
        {
            SortedDictionary<char, int> symbolsSequence = new();

            StreamReader reader = new(inputFilePath);
            string text = reader.ReadToEnd();
            reader.Close();

            foreach (char key in text)
            {
                if (key >= 'A' && key <= 'Z' || key >= 'a' && key <= 'z' || key >= '0' && key <= '9')
                {
                    if (symbolsSequence.ContainsKey(key))
                    {
                        int value = symbolsSequence[key];
                        value++;
                        symbolsSequence[key] = value;
                    }
                    else
                    {
                        symbolsSequence.Add(key, 1);
                    }
                }
            }

            return symbolsSequence;
        }


        public static string ReadFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
            fs.Close();
            string text = GetString(buffer);

            return text;
        }

        public static void WriteToFile(string path, string text)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            byte[] data = GetBytes(text);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        public static void Append(string path, string text)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            byte[] data = GetBytes(text);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        private static string GetString(byte[] data)
        {
            char[] symbols = new char[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                symbols[i] = (char)data[i];
            }

            return new string(symbols);
        }

        private static byte[] GetBytes(string text)
        {
            byte[] data = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                data[i] = (byte)text[i];
            }

            return data;
        }
    }
}
