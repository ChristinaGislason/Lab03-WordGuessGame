using System;
using System.IO;
using System.Text;

namespace Lab03_WordGuessGame
{
    public class Program
    {
        public static string path = "../../../myfile.txt";

        static void Main(string[] args)
        {
            string[] words = { "banana", "grapes", "cherry", "peach", "strawberry", "lemon" };
            CreateFile(words);

            Console.WriteLine("Welcome, let\'s play a Word Guess Game!");
            WordGuessGame();
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

        static void RunAdmin()
        {
            bool choice = false;
            while (!choice)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. View all words");
                Console.WriteLine("2. Add a word");
                Console.WriteLine("3. Remove a word");
                Console.WriteLine("4. Return to main menu");

                //Exception handling for options
                int adminOptionChosen;
                try
                {
                    adminOptionChosen = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid option. Try again.");
                    continue;
                }
                
                switch (adminOptionChosen)
                {
                    case 1:
                        foreach (string word in GetWords())
                        {
                            Console.WriteLine(word);
                        }
                        break;
                    case 2:
                        Console.WriteLine("What word do you want to add?");
                        string wordToAdd = Console.ReadLine();
                        AddWordToFile(wordToAdd);
                        break;
                    case 3:
                        Console.WriteLine("Which word would you like to remove?");
                        string userRequest = Console.ReadLine();
                        RemoveWordFromFile(userRequest);
                        break;
                    case 4:
                        WordGuessGame();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
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
            
            string randomGeneratedWord = GetRandomGeneratedWord();

            // Initialize currently guessed word characters
            char[] currentlyGuessedWordChars = new char[randomGeneratedWord.Length];
            for (int i = 0; i < currentlyGuessedWordChars.Length; i++)
            {
                currentlyGuessedWordChars[i] = '_';
            }

            // START GAME

            while (!string.Equals(randomGeneratedWord, new string(currentlyGuessedWordChars)))
            {
                GuessALetter(randomGeneratedWord, currentlyGuessedWordChars, ref incorrectLetterList);
            }

            // Output currently guessed result to user
            for (int i = 0; i < currentlyGuessedWordChars.Length; i++)
            {
                Console.Write($"{currentlyGuessedWordChars[i]} ");
            }
            Console.WriteLine("\nCongrats! You guessed the word.\n\n");
        }

        static string GetRandomGeneratedWord()
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
        static void GuessALetter(string randomGeneratedWord, char[] currentlyGuessedWordChars, ref string incorrectLetterList)
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
                    if (letter == randomGeneratedWord[i])
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

        /// <summary>
        /// Grabs all words from file
        /// </summary>
        /// <returns></returns>
        public static string[] GetWords()
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Create a file to add words to
        /// </summary>
        /// <param name="words"></param>
        public static void CreateFile(string[] words)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        foreach (string word in words)
                        {
                            sw.WriteLine(word);
                        }
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
                //
            }
        }

        /// <summary>
        /// Method to add a word to a file
        /// </summary>
        /// <param name="word"></param>
        public static void AddWordToFile(string word)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(word);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to remove a word from a file
        /// </summary>
        /// <param name="word"></param>
        public static void RemoveWordFromFile(string word)
        {
            string[] allWords = GetWords();
            string[] newWords = new string[allWords.Length - 1];
            int j = 0;
            for (int i = 0; i < allWords.Length; i++)
            {
                if (word != allWords[i])
                {
                    newWords[j++] = allWords[i];
                }
            }
            // Create a file for the new words to be added onto

            CreateFile(newWords);
        }
    }
}
