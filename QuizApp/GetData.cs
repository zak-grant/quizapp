using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuizApp
{
    class GetData
    {
        public List<string> GetDataFromTextFile()
        {
            // Path to text file
            string filePath = @"questions.txt";

            // Read data file and return text
            List<string> dataFile = File.ReadAllLines(filePath).ToList();

            foreach (string line in dataFile)
            {
                Console.WriteLine(line);
            }

            return dataFile;
        }
    }
}
