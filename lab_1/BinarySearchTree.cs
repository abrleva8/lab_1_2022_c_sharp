﻿namespace lab_1 {

    class BinarySearchTree<T> where T : IComparable {
        private Node<T>? _root;
        private const int ColumnWidth = 5;
        public const int MaxRandomSize = 10;
        private const int MinValue = -100;
        private const int MaxValue = 100;

        public BinarySearchTree(List<T> values) {
            this._root = null;
            foreach (T value in values) {
                this.Insert(value);
            }
        }

        public Node<T>? Root {
            get {
                return this._root;
            }

            set {
                this._root = value;
            }
        }

        private static int NumberOfChildren(Node<T>? node) {
            return Convert.ToInt32(node?.Left is not null) + Convert.ToInt32(node?.Right is not null);
        }

        public bool Insert(T value) {
            Node<T>? before = null;
            Node<T>? after = this.Root;

            while (after != null) {
                before = after;

                if (value.CompareTo(after.Value) < 0) {
                    after = after.Left;
                } else if (value.CompareTo(after.Value) > 0) {
                    after = after.Right;
                } else {
                    return false;
                }
            }

            Node<T>? newNode = new Node<T>(value);

            if (this.Root == null) {
                this.Root = newNode;
            } else {
                if (before != null && value.CompareTo(before.Value) < 0) {
                    before.Left = newNode;
                } else {
                    if (before != null) before.Right = newNode;
                }
            }

            return true;
        }

        public bool Find(T value) {
            Node<T>? node = this.Root;
            while (node != null) {

                if (value.CompareTo(node.Value) < 0) {
                    node = node.Left;
                } else if (value.CompareTo(node.Value) > 0) {
                    node = node.Right;
                } else {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value) {
            
            if (!Find(value)) {
                return false;
            }

            Node<T>? before = null;
            Node<T>? after = this.Root;

            while (after != null && after.Value.CompareTo(value) != 0) {
                before = after;

                if (value.CompareTo(after.Value) < 0) {
                    after = after.Left;
                } else if (value.CompareTo(after.Value) > 0) {
                    after = after.Right;
                }
            }

            if (NumberOfChildren(after) == 0) {
                if (before is null) {
                    this._root = null;
                } else {
                    if (value.CompareTo(before.Value) < 0) {
                        before.Left = null;
                    } else if (value.CompareTo(before.Value) > 0) {
                        before.Right = null;
                    }
                }
                // after = null;
            }

            if (NumberOfChildren(after) == 1) {
                if (before is null) {
                    this._root = after?.Right ?? after?.Left;
                } else {
                    if (value.CompareTo(before.Value) < 0) {
                        before.Left = after?.Right ?? after?.Left;

                        if (after != null) after.Right = null;
                    } else if (value.CompareTo(before.Value) > 0) {
                        before.Right = after?.Right ?? after?.Left;
                    }
                }

                if (after != null) {
                    after.Right = null;
                    after.Left = null;
                }
            }

            if (NumberOfChildren(after) == 2) {
                Node<T>? node = after?.Right;
                Node<T>? p = null;
                while (node?.Left is not null) {
                    p = node;
                    node = node.Left;
                }


                if (p is not null) {
                    p.Left = node?.Right;
                } else {
                    if (after != null) after.Right = node?.Right;
                }

                if (after != null && node != null)
                    after.Value = node.Value;
            }


            return true;
        }

        public int GetHeight(Node<T>? node) {
            if (node is null) {
                return 0;
            }

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int GetHeightNode(Node<T>? node) {
            return 1 + GetHeight(_root) - GetHeight(node);
        }

        public void Detour(Node<T>? node) {
            if (node == null) return;
            this.Detour(node.Left);
            Console.WriteLine(node + ": left child for " + node.Left + " right child " + node.Right);
            this.Detour(node.Right);
        }

        public List<T> RightDetour(Node<T>? node) {
            List<T> detour = new List<T>();
            RightDetourWorker(node, ref detour);
            return detour;
        }

        private void RightDetourWorker(Node<T>? node, ref List<T> detour) {
            if (node == null) return;
            detour.Add(node.Value);
            this.RightDetourWorker(node.Left, ref detour);
            this.RightDetourWorker(node.Right, ref detour);
        }

        public void Print() {
            Print(this._root, 0);
        }

        private static void Print(Node<T>? node, int space) {
            while (true) {
                if (node is null) {
                    return;
                }

                space += ColumnWidth;

                Print(node.Right, space);

                Console.WriteLine();
                for (int i = ColumnWidth; i < space; i++) Console.Write(" ");
                Console.WriteLine(node);

                node = node.Left;
            }
        }

        public static BinarySearchTree<int>? CreateRandomIntTree(int maxSize, int minValue = MinValue, int maxValue = MaxValue) {
            var rand = new Random();
            int size = rand.Next(1, maxSize);
            List<int> values = new List<int>(size);
            for (int i = 0; i < size; i++) {
                values.Add(rand.Next(minValue, maxValue));
            }

            return new BinarySearchTree<int>(values);
        }

        private static void DrawLeft(Node<T>? node, int row, int column, char[][] console, int columnDelta) {
            if (node?.Left != null) {
                int startColumnIndex = ColumnWidth * (column - columnDelta) + 2;
                int endColumnIndex = ColumnWidth * column + 2;
                for (int i = startColumnIndex; i < endColumnIndex; i++) {
                    console[row + 1][i] = '-';
                }

                console[row + 1][startColumnIndex] = '\u250c';
                console[row + 1][endColumnIndex] = '+';
            }
        }

        private static void DrawRight(Node<T>? node, int row, int column, char[][] console, int columnDelta) {
            if (node?.Right != null) {
                int startColumnIndex = ColumnWidth * column + 2;
                int endColumnIndex = ColumnWidth * (column + columnDelta) + 2;
                for (int i = startColumnIndex + 1; i < endColumnIndex; i++) {
                    console[row + 1][i] = '-';
                }

                console[row + 1][startColumnIndex] = '+';
                console[row + 1][endColumnIndex] = '\u2510';
            }
        }

        private void VisualizeNode(Node<T>? node, int row, int column, char[][] console, int width) {
            if (node != null) {
                char[]? chars = node.Value.ToString()?.ToCharArray();
                if (chars != null) {
                    int margin = (ColumnWidth - chars.Length) / 2;
                    for (int i = 0; i < chars.Length; i++) {
                        console[row][ColumnWidth * column + i + margin] = chars[i];
                    }
                }

                int columnDelta = (width + 1) / (int) Math.Pow(2, GetHeightNode(node) + 1);
                VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
                VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
                DrawLeft(node, row, column, console, columnDelta);
                DrawRight(node, row, column, console, columnDelta);
            }
        }

        private static char[][] InitializeVisualization(BinarySearchTree<T> bst, out int width) {
            int height = bst.GetHeight(bst.Root);
            width = (int) Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < 2 * height; i++) {
                console[i] = new char[ColumnWidth * width];
                for (int j = 0; j < console[i].Length; j++) {
                    console[i][j] = ' ';
                }
            }

            return console;
        }


        public char[][] GetDrawedTree() {
            char[][] console = InitializeVisualization(this, out int width);
            VisualizeNode(this.Root, 0, width / 2, console, width);
            return console;
        }
        
        public void VisualizeTree() {
            char[][] console = InitializeVisualization(this, out int width);
            VisualizeNode(this.Root, 0, width / 2, console, width);
            foreach (char[] row in console) {
                Console.WriteLine(row);
            }
        }

    }
}
