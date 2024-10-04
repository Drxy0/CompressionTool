using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionTool
{
    public interface IHuffmanBaseNode
    {
        public bool IsLeaf { get; set; }
        public int Weight { get; set; }
    }
}
