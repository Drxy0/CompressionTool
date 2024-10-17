using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionTool
{
    static public class Writer
    {
        static public void WriteHeader(string filePath, List<KeyValuePair<char, int>> frequencyTable)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    string header = string.Empty;

                    foreach (var node in frequencyTable)
                    {
                        header += $"{node}\n";
                    }

                    header += "###END_HEADER###\n";

                    writer.Write(header);
                    writer.Flush();
                }
            }
        }
    }
}
