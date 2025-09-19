using System;
using System.Linq;
using System.Collections.Generic;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class TreeBuilder
{
    public static TreeNode BuildTree(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return null;
        }
        int rootValue = array.Max();
        TreeNode root = new TreeNode(rootValue);
        List<int> leftBranch = new List<int>();
        List<int> rightBranch = new List<int>();

        foreach (int item in array)
        {
            if (item != rootValue)
            {
                if (item < rootValue)
                {
                    leftBranch.Add(item);
                }
                else
                {
                    rightBranch.Add(item);
                }
            }
        }
        leftBranch.Sort((a, b) => b.CompareTo(a));
        rightBranch.Sort((a, b) => b.CompareTo(a)); 

        TreeNode currentLeftNode = root;
        foreach (int value in leftBranch)
        {
            currentLeftNode.Left = new TreeNode(value);
            currentLeftNode = currentLeftNode.Left;
        }

        TreeNode currentRightNode = root;
        foreach (int value in rightBranch)
        {
            currentRightNode.Right = new TreeNode(value);
            currentRightNode = currentRightNode.Right;
        }

        return root;
    }

    public static void PrintTree(TreeNode node, string indent = "", bool isLeft = false)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.Value);
        indent += (isLeft ? "│   " : "    ");

        PrintTree(node.Left, indent, true);
        PrintTree(node.Right, indent, false);
    }
}

public class Program
{
    public static void Main()
    {
        int[] scenario1 = { 3, 2, 1, 6, 0, 5 };
        Console.WriteLine("--- Cenário 1 ---");
        Console.WriteLine("Array de entrada: [{0}]", string.Join(", ", scenario1));
        TreeNode root1 = TreeBuilder.BuildTree(scenario1);
        Console.WriteLine("Raiz: " + root1.Value);
        Console.WriteLine("Estrutura da Árvore:");
        TreeBuilder.PrintTree(root1);
        Console.WriteLine();
        int[] scenario2 = { 7, 5, 13, 9, 1, 6, 4 };
        Console.WriteLine("--- Cenário 2 ---");
        Console.WriteLine("Array de entrada: [{0}]", string.Join(", ", scenario2));
        TreeNode root2 = TreeBuilder.BuildTree(scenario2);
        Console.WriteLine("Raiz: " + root2.Value);
        Console.WriteLine("Estrutura da Árvore:");
        TreeBuilder.PrintTree(root2);
    }
}