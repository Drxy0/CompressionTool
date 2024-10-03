
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
            
            while (true)
            {
                Console.WriteLine("Input name of file");
                fileName = Console.ReadLine();
                fileName = $"{baseDir}/{fileName}";

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
            }
        }
    }
}
