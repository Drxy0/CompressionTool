using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionTool
{
    public class HuffmanLeafNode : IHuffmanBaseNode
    {
        public char Value { get; set; }
        public int Weight { get; set; }
        public bool IsLeaf
        {
            get { return true; }
            set { }
        }
        public HuffmanLeafNode(char _value, int weight)
        {
            Value = _value;
            Weight = weight;
        }
    }

    public class HuffmanInternalNode : IHuffmanBaseNode
    {
        public int Weight { get; set; }
        public IHuffmanBaseNode Left { get; set; }
        public IHuffmanBaseNode Right { get; set; }

        public HuffmanInternalNode(int weight, IHuffmanBaseNode left, IHuffmanBaseNode right)
        {
            Weight = weight;
            Left = left;
            Right = right;
        }

        public bool IsLeaf
        {
            get { return false; }
            set { }
        }
    }

    public class HuffmanTree
    {
        public IHuffmanBaseNode Root { get; set; }

        public HuffmanTree(char _value, int weight)
        {
            Root = new HuffmanLeafNode(_value, weight);
        }
        public HuffmanTree(int weight, IHuffmanBaseNode left, IHuffmanBaseNode right)
        {
            Root = new HuffmanInternalNode(weight, left, right);
        }

        int CompareTo(HuffmanTree t)
        {
            HuffmanTree that = (HuffmanTree) t;

            if (Root.Weight < that.Root.Weight)
            {
                return -1;
            }
            else if (Root.Weight > that.Root.Weight)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }


    static HuffmanTree BuildTree(Stack<KeyValuePair<char, int>> nodesStack)
    {

        while (nodesStack.Count > 1)
        {
            KeyValuePair<char, int> tmp1 = nodesStack.Pop();
            KeyValuePair<char, int> tmp2 = nodesStack.Pop();
            
            
        
        }
    }
}
