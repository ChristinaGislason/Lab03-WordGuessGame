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
            
            //CreateFile();
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

                //Exception handling for options
                int gameOptionChosen;
                try
                {
                    gameOptionChosen = Convert.ToInt32(Console.ReadLine());                  
                }
                catch 
                {
                    Console.WriteLine("Invalid option. Try again.");
                    continue;
                }
                             
                switch (gameOptionChosen)
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
                        break;   
                } 
            }       
        }

        /// <summary>
        /// Initiates Word Guess Game 
        /// </summary>
        static void StartGame()
        {

            //  GAME SETUP
            string incorrectLetterList = "";

            // Get random word for game
            string path = "../../../myfile.txt";
            string randomGeneratedWord = GetRandomGeneratedWord(path);

            // Initialize currently guessed word characters
            char[] currentlyGuessedWordChars = new char[randomGeneratedWord.Length];
            for (int i = 0; i < currentlyGuessedWordChars.Length; i++)
            {
                currentlyGuessedWordChars[i] = '_';
            }


            // START GAME

            GuessALetter(randomGeneratedWord, currentlyGuessedWordChars, incorrectLetterList);

        }

        static string GetRandomGeneratedWord(string path)
        {
            string[] words = File.ReadAllLines(path);
            Random random = new Random();
            int randomIndexChosen = random.Next(0, words.Length);
            string randomGeneratedWord = words[randomIndexChosen];
            return randomGeneratedWord;
        }

        /// <summary>
        /// Match user's guessed letter to the word
        /// </summary>
        /// <param name="randomGeneratedWord"></param>
        /// <param name="currentlyGuessedWordChars"></param>
        static void GuessALetter(string randomGeneratedWord, char[] currentlyGuessedWordChars, string incorrectLetterList)
        {
            // Output currently guessed result to user
            for (int i = 0; i < currentlyGuessedWordChars.Length; i++)
            {
                Console.Write($"{currentlyGuessedWordChars[i]} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Guess a letter: "); 
            string letterWithNewLine = Console.ReadLine();
            char letter = letterWithNewLine[0];


            if (randomGeneratedWord.Contains(letter))
            {
                for (int i = 0; i < randomGeneratedWord.Length; i++)
                {
                    if(letter == randomGeneratedWord[i])
                    {
                        currentlyGuessedWordChars[i] = letter;
                    }                   
                }
            }
            else
            {
                incorrectLetterList += letter;
                Console.WriteLine($"Letters guessed so far: {incorrectLetterList}");
            }

  
        }
        
        static void RunAdmin()
        {
            Console.WriteLine("Running Admin functionality");
        }
        /*
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
        } */
    }
}
