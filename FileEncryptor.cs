using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp007
{
    static class FileEncryptor
    {
        public static void Encrypt(string inputFilePath, string outputFilePath, string password)
        {
            try
            {
                StreamReader reader = new StreamReader(inputFilePath);
                StreamWriter writer = new StreamWriter(outputFilePath);
                string text = reader.ReadToEnd();
                reader.Close();

                char[] chars = text.ToCharArray();
                int index = 0;

                for (int i = 0; i < chars.Length; i++)
                {
                    if (index == password.Length)
                    {
                        index = 0;
                    }
                    chars[i] = (char)(chars[i] + password[index]);
                    index++;
                }
                string encryptedtext = new string(chars);

                writer.Write(encryptedtext);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            
        }

        public static void Decrypt(string inputFilePath, string outputFilePath, string password)
        {
            try
            {
                StreamReader reader = new StreamReader(inputFilePath);
                StreamWriter writer = new StreamWriter(outputFilePath);
                string text = reader.ReadToEnd();
                reader.Close();

                char[] chars = text.ToCharArray();
                int index = 0;

                for (int i = 0; i < chars.Length; i++)
                {
                    if (index == password.Length)
                    {
                        index = 0;
                    }
                    chars[i] = (char)(chars[i] - password[index]);
                    index++;
                }
                string decryptedtext = new string(chars);

                writer.Write(decryptedtext);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
           
        }
    }
}
