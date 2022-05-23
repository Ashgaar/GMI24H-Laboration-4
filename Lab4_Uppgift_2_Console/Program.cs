using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using LaborationInterfaces;
using Olsson_Mikael;

namespace Lab4_Uppgift_2
{
    class Program
    {
        static readonly string InputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        static readonly string OutputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        const int WaitSeconds = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("|   WORD FREQUENCY COUNTER   |");
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("");

            //1. Get a file to process
            string inputFilePath = SelectInputFile(InputDir);

            while (inputFilePath.Length > 0)
            {
                //2. Read file contents
                string text = File.ReadAllText(inputFilePath);

                //3. Get list of words, converted to lowercase, and with unwanted characters filtered out
                //string[] cleanWords = GetCleanListOfWords(text);
                IEnumerable<string> cleanWords = GetCleanListOfWords(text);

                //4. Move word by word into (your implementation of) a binary search tree
                ISortedDictionary<string, int> dictionary = WordHandler.WordsToDictionary(cleanWords);

                //5. Build output file contents from the binary search tree
                string outputFileContents = TraverseToString(dictionary);

                //6. Write contents to file
                var outputFileName = ($"{Path.GetFileNameWithoutExtension(inputFilePath)}  {DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss.fff")}.out");
                var outputFilePath = Path.Combine(OutputDir, outputFileName);
                SaveToOutputFile(outputFilePath, outputFileContents);

                //Back to 1. Get new file to process
                inputFilePath = SelectInputFile(InputDir);
            }
            Console.Write($"\nExiting in {WaitSeconds} s...");
            Thread.Sleep(WaitSeconds * 1000);
        }

        #region Private functions for sub-parts of the overall program

        private const string IndentPrefix = "\t";

        /// <summary>
        /// Displays a selection menu with the files in subdirectory "Input", and
        /// lets the user select one (or none) of the files.
        /// </summary>
        /// <returns>The full path of the selected file. Empty string if no file is selected.</returns>
        private static string SelectInputFile(string inputDir)
        {
            string selectedFile = "";

            var inputFilePaths = Directory.GetFiles(inputDir);

            //It is fun to use our own dictionary, isn't it?
            BinarySearchTree<string, FileInfo> files = new BinarySearchTree<string, FileInfo>();

            for (int i = 0; i < inputFilePaths.Length; i++)
            {
                files.Add((i + 1).ToString(), new FileInfo(inputFilePaths[i]));
            }

            Console.WriteLine($"");
            Console.WriteLine($"Select a file to use as input.");
            Console.WriteLine($"------------------------------");
            files.Traverse((kvp) => Console.WriteLine($"{IndentPrefix}{kvp.Key}.\t{kvp.Value.Name}\t({kvp.Value.Length} B)"));
            Console.WriteLine($"{IndentPrefix}[Other]\tExit program.");
            Console.Write($"");
            Console.Write($"> ");

            var key = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine($"");
            if (files.Contains(key))
            {
                FileInfo selectedFileInfo = files.Get(key);
                selectedFile = selectedFileInfo.FullName;
            }
            if (String.IsNullOrEmpty(selectedFile))
            {
                Console.WriteLine("No file selected.");
            }
            else
            {
                Console.WriteLine($"File selected:");
                Console.WriteLine($"{IndentPrefix}{selectedFile}");
            }

            return selectedFile;
        }

        /// <summary>
        /// Gets a list of cleaned words from a string. 
        /// 
        /// *  "Words" consisting of characters that do not usually occur in natural language 
        ///    are removed (e.g. "$5,000", "http://...", "#hashtag").
        /// *  Delimiters (period, comma, exclamation mark, etc.) are trimmed, but the rest of
        ///    the word is used.
        /// *  Also converts the word to lowercase.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetCleanListOfWords(string text)
        {
            List<string> list = new List<string>();

            var words = text.Split(); // Split() without parameter splits string at each whitespace character.
            foreach (var word in words)
            {
                string lowercaseWord = word.ToLower();
                
                if (Regex.IsMatch(lowercaseWord, "^[a-zåäö]+$") ||
                    Regex.IsMatch(lowercaseWord, "^[a-zåäö]+[0-9.,:;!?'‘’\"“”-]+([a-zåäö]*[0-9.,:;!?'‘’\"“”-]*)*$") ||
                    Regex.IsMatch(lowercaseWord, "^[0-9.,:;!?'‘’\"“”-]+[a-zåäö]+([a-zåäö]*[0-9.,:;!?'‘’\"“”-]*)*$"))
                {
                    char[] charactersToTrim = new char[] { '.', ',', ':', ';', '!', '?', '\'', '‘', '’', '\"', '“', '”' };
                    string trimmedWord = lowercaseWord.Trim(charactersToTrim);
 
                    list.Add(trimmedWord);
                }
            }

            return list;
        }
        /// <summary>
        /// Saves <paramref name="fileContents"/> to file <paramref name="filePath"/>,
        /// while also writing some output to the Console.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContents"></param>
        private static void SaveToOutputFile(string filePath, string fileContents)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            File.WriteAllText(filePath, fileContents);

            Console.WriteLine("");
            Console.WriteLine($"Output file written:");
            Console.WriteLine($"");
            Console.WriteLine($"{IndentPrefix}{filePath}");
            Console.WriteLine($"");
        }

        /// <summary>
        /// Traverses the sorted dictionary, and writes all keys and values to a string.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private static string TraverseToString(ISortedDictionary<string, int> dictionary)
        {
            var sb = new StringBuilder(); // Om du inte känner till StringBuilder: sök efter information och använd den,
                                          //                                       ELLER jobba bara på datatypen String.
            dictionary.Traverse((kvp) => sb.AppendLine($"{kvp.Key}\t{kvp.Value}"));
            string retString = sb.ToString();
            return retString.Trim();
        }
        #endregion
    }
}
