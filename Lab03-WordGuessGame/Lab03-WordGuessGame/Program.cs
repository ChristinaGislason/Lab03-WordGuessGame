using System;
using System.IO;
using System.Text;

namespace Lab03_WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateFile();
        }

        static void CreateFile()
        {
            string path = "../../../myfile.txt";

            /*try
            {       
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.Write("Let\'s play a guessing word game!");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // close the file
            }
            */
            //second way to create a file

            try
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] myWords = new UTF8Encoding(true).GetBytes("Hello Class!");
                    fs.Write(myWords, 0, myWords.Length);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
