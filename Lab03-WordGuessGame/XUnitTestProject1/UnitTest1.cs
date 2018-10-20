using System;
using System.IO;
using Xunit;
using Lab03_WordGuessGame;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Test that a file can be created with words
        /// </summary>
        [Fact]
        public void TestCreateFile()
        {
            string[] testWords = { "testword" };
            Program.CreateFile(testWords);

            string path = "../../../myfile.txt";
            string[] allFileLines = File.ReadAllLines(path);

            Assert.Equal("testword", allFileLines[0]);
        }

        /// <summary>
        /// Test that a word can be added to a file
        /// </summary>
        [Fact]
        public void TestAddWordToFile()
        {
            Program.AddWordToFile("testword2");

            string path = "../../../myfile.txt";
            string[] allFileLines = File.ReadAllLines(path);

            Assert.Equal("testword2", allFileLines[allFileLines.Length - 1]);
        }
        
        /// <summary>
        /// Test that a word can be removed from file
        /// </summary>
        [Fact]
        public void TestRemoveWordFromFile()
        {
            Program.AddWordToFile("testword3");
            Program.RemoveWordFromFile("testword3");

            string path = "../../../myfile.txt";
            string[] allFileLines = File.ReadAllLines(path);

            Assert.NotEqual("testword3", allFileLines[allFileLines.Length - 1]);
        } 

        /// <summary>
        /// Test that all words can be retrieved from file
        /// </summary>
        [Fact]
        public void TestGetAllWordsFromFile()
        {
            string[] testWords = { "dog", "cat" };
            Program.CreateFile(testWords);

            string[] actualWordsFromFile = Program.GetWords();

            // Check to see values, not references, equals each other
            Assert.Equal(testWords[0], actualWordsFromFile[0]);
            Assert.Equal(testWords[1], actualWordsFromFile[1]);
        }


    }
}
