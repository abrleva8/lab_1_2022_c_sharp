namespace lab_1 {
    public class TreeDrawer<T> where T : IComparable {

        private const int ColumnWidth = 5;

        private BinarySearchTree<T> _bst;

        public TreeDrawer(BinarySearchTree<T> bst) {
            this._bst = bst;
        }

        public BinarySearchTree<T> Bst {
            get {
                return this._bst;
            }
        
            set {
                this._bst = value;
            }
        }

        public void Print() {
            Print(this._bst.Root, 0);
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
        private void DrawLeft<T>(Node<T>? node, int row, int column, char[][] console, int columnDelta){
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

        private static void DrawRight<T>(Node<T>? node, int row, int column, char[][] console, int columnDelta) {
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

        private void VisualizeNode<T>(Node<T>? node, int row, int column, char[][] console, int width) where T : IComparable {
            if (node == null) return;
            char[]? chars = node.Value.ToString()?.ToCharArray();
            if (chars != null) {
                int margin = (ColumnWidth - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++) {
                    console[row][ColumnWidth * column + i + margin] = chars[i];
                }
            }

            int columnDelta = (width + 1) / (int) Math.Pow(2, this._bst.GetHeightNode(node) + 1);
            VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
            VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
            DrawLeft(node, row, column, console, columnDelta);
            DrawRight(node, row, column, console, columnDelta);
        }

        private static char[][] InitializeVisualization<T>(BinarySearchTree<T> bst, out int width) where T : IComparable {
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
            char[][] console = InitializeVisualization(this._bst, out int width);
            VisualizeNode(this._bst.Root, 0, width / 2, console, width);
            return console;
        }

        public void VisualizeTree() {
            char[][] console = InitializeVisualization(this._bst, out int width);
            VisualizeNode(this._bst.Root, 0, width / 2, console, width);
            foreach (char[] row in console) {
                Console.WriteLine(row);
            }
        }

    }
}
