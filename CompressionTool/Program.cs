
using System.Reflection.PortableExecutable;

namespace CompressionTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fileName = "";
            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            
            Console.WriteLine("Input name of file");
            fileName = Console.ReadLine();
            fileName = $"{baseDir}/{fileName}";
            string fileNameToWrite = $"{baseDir}/marko.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line;
                    int lineNumber = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lineNumber++;
                        foreach (char c in line)
                        {
                            if (occurrences.ContainsKey(c))
                            {
                                occurrences[c]++;
                            }
                            else
                            {
                                occurrences.Add(c, 1);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file exists!");
            }

            List<KeyValuePair<char, int>> nodesList = new List<KeyValuePair<char, int>>();

            foreach(var kvp in occurrences)
            {
                nodesList.Add(kvp);
            }
            nodesList.Sort((kvp1, kvp2) => kvp1.Value.CompareTo(kvp2.Value));
            
            Writer.WriteHeader(fileNameToWrite, nodesList);
            Stack<HuffmanTree> nodesStack = HuffmanAlgorithm.InitHuffmanTrees(nodesList);
            HuffmanTree tree = HuffmanAlgorithm.BuildTree(nodesStack);
            
            HuffmanAlgorithm.BuildPrefixCodeTable(tree);

        }
    }
}
