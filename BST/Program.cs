using System;

namespace BST
{
    public class Program
    {
        static void Main(string[] args)
        {
            BST binaryTree = new BST();
            Leaf treeRoot;

            //przykładowe wartości początkowe
            binaryTree.Insert(5); //korzeń
            binaryTree.Insert(2);
            binaryTree.Insert(6);
            binaryTree.Insert(1);
            binaryTree.Insert(10);
            binaryTree.Insert(8);
            //przykładowe wartości początkowe

            int input;

            int k = 0;

            while (k != 8)
            {
                Console.WriteLine("------MENU------");
                Console.WriteLine("1. Wprowadź liczbę całkowitą do drzewa");
                Console.WriteLine("2. Usuń liczbę całkowitą z drzewa");
                Console.WriteLine("3. Maksymalna wartość drzewa");
                Console.WriteLine("4. Minimalna wartość drzewa");
                Console.WriteLine("5. Sprawdź czy podana liczba całkowita zawiera się w drzewie");
                Console.WriteLine("6. Operacja InOrder");
                Console.WriteLine("7. Operacja Successor");
                Console.WriteLine("8. Wyjdź");
                Console.WriteLine("------MENU------");

                k = Convert.ToInt32(Console.ReadLine());

                switch (k)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Podaj liczbę całkowitą:");
                        input = Convert.ToInt32(Console.ReadLine());
                        binaryTree.Insert(input);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Podaj liczbę całkowitą:");
                        input = Convert.ToInt32(Console.ReadLine());
                        binaryTree.DeleteLeaf(input);
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        treeRoot = binaryTree.Root;
                        Console.WriteLine($"Maksymalna wartość w drzewie to: {binaryTree.Max(treeRoot).Key}");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        treeRoot = binaryTree.Root;
                        Console.WriteLine($"Minimalna wartość w drzewie to: {binaryTree.Min(treeRoot).Key}");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        treeRoot = binaryTree.Root;
                        Console.WriteLine("Podaj liczbę całkowitą:");
                        input = Convert.ToInt32(Console.ReadLine());

                        var tempLeaf = binaryTree.Member(input, treeRoot);

                        if (tempLeaf != null)
                        {
                            Console.WriteLine($"Wartość {input} znajduję się w drzewie");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Wartość {input} nie znajduję się w drzewie");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;

                    case 6:
                        Console.Clear();
                        treeRoot = binaryTree.Root;
                        Console.WriteLine("Operacja InOrder:");
                        binaryTree.InOrder(treeRoot);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 7:
                        Console.Clear();
                        treeRoot = binaryTree.Root;
                        Console.WriteLine("Podaj liczbę całkowitą dla której chcesz poznać bezpośredniego następce:");
                        input = Convert.ToInt32(Console.ReadLine());
                        var temp = binaryTree.Member(input, treeRoot);
                        if (binaryTree.Succesor(treeRoot, temp) != null)
                        {
                            Console.WriteLine($"Successor: {binaryTree.Succesor(treeRoot, temp).Key}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Brak successora!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case 8:
                        break;
                }

            }
        } 
    }

    public class Leaf
    {
        public Leaf Left { get; set; }
        public Leaf Right { get; set; }
        public int Key { get; set; }
    }

    public class BST
    {
        public Leaf Root { get; set; }
        public bool Insert(int data)
        {
            Leaf before = null;
            Leaf after = this.Root;

            while (after != null)
            {
                before = after;

                if (data < after.Key)
                {
                    after = after.Left;
                }
                else if (data > after.Key)
                {
                    after = after.Right;
                }
                else
                {
                    return false;
                }
            }

                Leaf newLeaf = new Leaf();
                newLeaf.Key = data;

                if (this.Root == null)
                {
                    this.Root = newLeaf;
                }
                else
                {
                    if (data < before.Key)
                    {
                        before.Left = newLeaf;
                    }
                    else
                    {
                        before.Right = newLeaf;
                    }
                }

                return true;
        }
        public void DeleteLeaf(int data)
        {
            this.Root = Delete(this.Root, data);
        }
        private Leaf Delete(Leaf parent, int key)
        {
            if (parent == null)
            {
                return parent;
            }

            if (key < parent.Key)
            {
                parent.Left = Delete(parent.Left, key);
            }
            else if (key > parent.Key)
            {
                parent.Right = Delete(parent.Right, key);
            }
            else
            {
                if (parent.Left == null)
                {
                    return parent.Right;
                }
                else if (parent.Right == null)
                {
                    return parent.Left;
                }

                parent.Key = Min(parent.Right).Key;

                parent.Right = Delete(parent.Right, parent.Key);
            }

            return parent;
        }
        public void InOrder(Leaf parent)
        {
            if (parent != null)
            {
                InOrder(parent.Left);
                Console.WriteLine(parent.Key + " ");
                InOrder(parent.Right);
            }
        }
        public Leaf Member(int data, Leaf parent)
        {
            if (parent != null)
            {
                if (data == parent.Key)
                {
                    return parent;
                }

                if (data < parent.Key)
                {
                    return Member(data, parent.Left);
                }
                else
                {
                    return Member(data, parent.Right);
                }
            }

            return null;
        }
        public Leaf Min(Leaf leaf)
        {
            //int minValue = leaf.Key;

            while (leaf.Left != null)
            {
                //minValue = leaf.Left.Key;
                leaf = leaf.Left;
            }

            return leaf;
        }
        public Leaf Max(Leaf leaf)
        {
            //int maxValue = leaf.Key;

            while (leaf.Right != null)
            {
                //maxValue = leaf.Right.Key;
                leaf = leaf.Right;
            }

            return leaf;
        }
        public Leaf Succesor(Leaf root, Leaf n)
        {
            if (n.Right != null)
            {
                return Min(n.Right);
            }

            Leaf succ = null;

            while (root != null)
            {
                if (n.Key < root.Key)
                {
                    succ = root;
                    root = root.Left;
                }
                else if (n.Key > root.Key)
                {
                    root = root.Right;
                }
                else
                {
                    break;
                }
            }

            return succ;
        }
    }
}
