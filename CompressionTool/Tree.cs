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
        public int CompareTo(HuffmanTree other)
        {
            return Root.Weight.CompareTo(other.Root.Weight);
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
            for (int i = nodesList.Count - 1; i >= 0; i--)
            {
                HuffmanTree leaf = new HuffmanTree(nodesList[i].Key, nodesList[i].Value);
                nodesStack.Push(leaf);
            }

            return nodesStack;
        }

        public static HuffmanTree BuildTree(Stack<HuffmanTree> nodesStack)
        {
            while (nodesStack.Count > 1)
            {
                // Pop the two trees with lowest weight
                HuffmanTree left = nodesStack.Pop();
                HuffmanTree right = nodesStack.Pop();
                // Combine them into a new internal node
                HuffmanTree parent = new HuffmanTree(left.Root, right.Root, left.Root.Weight + right.Root.Weight);
                // Push the new tree back to the stack
                nodesStack.Push(parent);
                // Sort stack so the smallest weights are on top
                nodesStack = new Stack<HuffmanTree>(nodesStack.OrderByDescending(tree => tree.Root.Weight));
            }

            // The last remaining tree in the stack is the root Huffman tree
            return nodesStack.Pop();
        }

        public static void SortStack(Stack<HuffmanTree> nodesStack)
        {
            List<HuffmanTree> list = nodesStack.ToList();
            for (int i = 0; i <  list.Count - 1; i++)
            {
                if (list[i].Root.Weight > list[i+1].Root.Weight)
                {
                    var temp = list[i];
                    list[i] = list[i+1];
                    list[i+1] = temp;
                }
                else
                {
                    nodesStack.Clear();
                    list.Sort((a, b) => b.Root.Weight.CompareTo(a.Root.Weight));
                    foreach (var item in list)
                    {
                        nodesStack.Push(item);
                    }
                    return;
                }
            }
        }

        public static Dictionary<char, string> GeneratePrefixCodeTable(HuffmanTree tree)
        {
            Dictionary<char, string> prefixCodeTable = new Dictionary<char, string>();
            GenerateCodesRecursive(tree.Root, "", prefixCodeTable);
            return prefixCodeTable;
        }

        private static void GenerateCodesRecursive(IHuffmanBaseNode node, string code, Dictionary<char, string> prefixCodeTable)
        {
            if (node == null) return;

            if (node.IsLeaf && node is HuffmanLeafNode leaf)
            {
                // Add leaf character and its code to the dictionary
                prefixCodeTable[leaf.Value] = code;
            }
            else if (node is HuffmanInternalNode internalNode)
            {
                // Traverse left (add '0' to code)
                GenerateCodesRecursive(internalNode.Left, code + "0", prefixCodeTable);
                // Traverse right (add '1' to code)
                GenerateCodesRecursive(internalNode.Right, code + "1", prefixCodeTable);
            }
        }
        public static void PrintPrefixCodeTable(Dictionary<char, string> prefixCodeTable)
        {
            foreach (var entry in prefixCodeTable)
            {
                Console.WriteLine($"Character: {entry.Key}, Code: {entry.Value}");
            }
        }
    }
}
