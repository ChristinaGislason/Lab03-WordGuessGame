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
        /// Test that a word be added to a file
        /// </summary>
        [Fact]
        public void TestAddWordToFile()
        {
            Program.AddWordToFile("testword2");

            string path = "../../../myfile.txt";
            string[] allFileLines = File.ReadAllLines(path);

            Assert.Equal("testword2", allFileLines[allFileLines.Length - 1]);
        }
    }
}
