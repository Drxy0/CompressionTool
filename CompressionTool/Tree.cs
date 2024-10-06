using System;
using System.Collections;
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

        public HuffmanInternalNode(IHuffmanBaseNode left, IHuffmanBaseNode right, int weight)
        {
            Left = left;
            Right = right;
            Weight = weight;
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
        public HuffmanTree(IHuffmanBaseNode left, IHuffmanBaseNode right, int weight)
        {
            Root = new HuffmanInternalNode(left, right, weight);
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


        public override string ToString()
        {
            return Root.Weight.ToString();
        }
    }

    public static class HuffmanAlgorithm
    {
        public static Stack<HuffmanTree> InitHuffmanTrees(List<KeyValuePair<char, int>> nodesList)
        {
            Stack<HuffmanTree> nodesStack = new Stack<HuffmanTree>();
            for (int i = 0; i < nodesList.Count; i++)
            {
                HuffmanTree leaf = new HuffmanTree(nodesList[i].Key, nodesList[i].Value);
                nodesStack.Push(leaf);
            }

            return nodesStack;
        }

        public static HuffmanTree BuildTree(Stack<HuffmanTree> nodesStack)
        {
            HuffmanTree tmp1, tmp2, tmp3 = null;

            while (nodesStack.Count > 1)
            {
                tmp1 = nodesStack.Pop();
                tmp2 = nodesStack.Pop();
                tmp3 = new HuffmanTree(tmp1.Root, tmp2.Root,
                                         tmp1.Root.Weight + tmp2.Root.Weight);
                nodesStack.Push(tmp3);
            }
            return tmp3;
        }
    }


}
