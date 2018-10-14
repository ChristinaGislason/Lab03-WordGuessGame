using System;
using System.IO;
using System.Text;

namespace Lab03_WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, let\'s play a Word Guess Game!");
            WordGuessGame();
            



            CreateFile();
        }

        static void WordGuessGame() 
        {
            bool action = true;
            while (action) 
            {              
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Start a Game");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit Game");
                int option;

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    option = 5;
                }

                switch (option)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        RunAdmin();
                        break;
                    case 3:                                             
                        Environment.Exit(0);
                        break;                                     
                    default:
                        Console.Write("Invalid option. Please choose an option.");                    
                        break;    
                } 
            }
        }

        ViewAllWords();
        AddAWord();
        DeleteAWord();
        ReturnToMainMenu();


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
