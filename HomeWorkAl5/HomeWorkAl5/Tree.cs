using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkAl5
{
    public interface ITree
    {
        TreeNode GetRoot();
        TreeNode GetFreeNode(int value, TreeNode parent); //Возвращает корневой элемент
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
    public class Tree : ITree
    {
        public TreeNode Head { get; set; }
        public List<int> list = new List<int>();
        public void AddItem(int value) // добавить узел
        {
            TreeNode tmp = null;

            if (Head == null)
            {
                Head = GetFreeNode(value, null);
            }
            else
            {
                tmp = Head;

            }
            while (tmp != null)
            {
                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value, tmp);
                    }
                }
                else if (value < tmp.Value)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value, tmp);
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");                  // Дерево построено неправильно
                }
                return;
            }
        }
        public TreeNode GetFreeNode(int value, TreeNode parent)
        {
            return new TreeNode
            {
                Value = value,
                Parent = parent
            };
        }
        public void RemoveItem(int value)
        {
            TreeNode tree = GetNodeByValue(value);
            if (tree == null) return;
            TreeNode elem;

            if (tree.LeftChild == null && tree.RightChild == null && tree.Parent != null)
            {
                if (tree == tree.Parent.LeftChild)
                    tree.Parent.LeftChild = null;
                else
                {
                    tree.Parent.RightChild = null;
                }
                return;
            }

            if (tree.Value == value)
            {
                if (tree.RightChild != null)
                {
                    elem = tree.RightChild;
                }
                else elem = tree.LeftChild;

                while (elem.LeftChild != null)
                {
                    elem = elem.LeftChild;
                }
                var temp = elem.Value;
                this.RemoveItem(temp);
                tree.Value = temp;

                return;
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value < value)
                {
                    currentNode = currentNode.RightChild;
                    continue;
                }
                if (currentNode.Value > value)
                {
                    currentNode = currentNode.LeftChild;
                    continue;
                }
                if (currentNode.Value == value)
                    return currentNode;
            }
            return null;
        }

        public void PrintTree()
        {
            Console.Clear();
            PrintTree(Head);
        }
        private int PrintTree(TreeNode node, int x = 0, int y = 0)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(node.Value);

            var loc = y;

            if (node.RightChild != null)
            {
                Console.SetCursorPosition(x + 2, y);
                Console.Write("--");
                y = PrintTree(node.RightChild, x + 4, y);
            }

            if (node.LeftChild != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(x, loc + 1);
                    Console.Write(" |");
                    loc++;
                }
                y = PrintTree(node.LeftChild, x, y + 2);
            }

            return y;
        }

        public TreeNode GetRoot()
        {
            return Head;
        }

        public void BreadthFirstSearch()
        {
            BreadthFirstSearch(Head);
        }
        private void BreadthFirstSearch(TreeNode node)
        {
            var queue = new Queue<TreeNode>(); 
            queue.Enqueue(node); 
            while (queue.Count != 0) 
            {
                if (queue.Peek().LeftChild != null)
                {
                    queue.Enqueue(queue.Peek().LeftChild);
                }
                if (queue.Peek().RightChild != null)
                {
                    queue.Enqueue(queue.Peek().RightChild);
                }
                
                Console.Write($"[{queue.Peek().Value.ToString()}]  ");
                queue.Dequeue();
            }
        }
        
        public void DeepFirstSearch()

        {
           DeepFirstSearch(Head);
            foreach (var item in hashSet)
            {
                Console.Write($"[{item}]  ");
            }
            
        }
        public static HashSet<int> hashSet = new HashSet<int>();
        private static string DeepFirstSearch(TreeNode currentNode)
        {
            string s = "";
            if (currentNode != null)
            {
                hashSet.Add(currentNode.Value);
                s = DeepFirstSearch(currentNode.LeftChild);
                s = DeepFirstSearch(currentNode.RightChild);
            }
           
            return s;
        }
    }

}
