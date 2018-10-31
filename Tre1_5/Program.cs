using System;
//Implement a function to check if a binary tree is a BST
namespace Tre1_5
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node()
        {
            data = 0;
            left = null;
            right = null;
        }
        public Node(int val)
        {
            data = val;
            left = null;
            right = null;
        }
    }


    public class BinaryTree
    {
        Node root, prev; // To keep tract of previous node in Inorder Traversal 
        public BinaryTree()
        {
            prev = null;
            root = null;
        }

        // method 1: do inOrder and check if it is in ascending order
        // doesnt work in case of duplicates
        /* Returns true if given search tree is binary search tree */
        public bool IsBST(Node node)
        {
            // traverse the tree in inorder fashion and keep a track of previous node 
            if (node != null)
            {
                if (!IsBST(node.left))
                    return false;

                // allows only distinct values node 
                if (prev != null && node.data <= prev.data)
                    return false;

                prev = node;
                return IsBST(node.right);
            }
            return true;
        }

        // //method 2
        // The max-Min solution
        public bool IsBST2(Node root, int min, int max)
        {
            if (root != null)
            {
                if (root.data > max || root.data < min)
                    return false;
                //if (!(root.data <= max && root.data >= min))
                //    return false;


                return IsBST2(root.left, min, root.data)
                        && IsBST2(root.right, root.data, max);
            }
            else
                return true;
        }


        static void Main(string[] args)
        {
            Node root = new Node(50);
            root.left = new Node(25);
            root.right = new Node(70);
            root.left.left = new Node(10);
            root.left.right = new Node(40);
            root.left.right.left = new Node(35);
            root.right.left = new Node(60);
            /*root.right.left.right = new Node(65);
            root.right.left.right.left = new Node(62);
            root.right.right = new Node(80);
            root.right.right.right = new Node(90);*/

            BinaryTree tree = new BinaryTree();

            bool result = tree.IsBST(root);
            int min = int.MinValue,
                max = int.MaxValue;

            //bool result = tree.IsBST2(root, min, max);
            if (result)
            {
                Console.WriteLine("A binary tree is a BST");
            }
            else
            {
                Console.WriteLine("A binary tree is NOT a BST");
            }
        }
    }
}
