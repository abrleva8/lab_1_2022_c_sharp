namespace lab_1 {
    public class TreeDrawer<T> where T : IComparable {

        private const int ColumnWidth = 5;

        private BinarySearchTree<T>? _bst;

        public TreeDrawer(BinarySearchTree<T>? bst) {
            this._bst = bst;
        }

        public BinarySearchTree<T>? Bst {
            get {
                return this._bst;
            }
        
            set {
                this._bst = value;
            }
        }

        private void DrawLeft(Node<T>? node, int row, int column, char[][] console, int columnDelta){
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

        private void VisualizeNode(Node<T>? node, int row, int column, char[][] console, int width){
            if (node == null) return;
            char[]? chars = node.Value.ToString()?.ToCharArray();
            if (chars != null) {
                int margin = (ColumnWidth - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++) {
                    console[row][ColumnWidth * column + i + margin] = chars[i];
                }
            }

            var binarySearchTree = this._bst;
            if (binarySearchTree != null) {
                int columnDelta = (width + 1) / (int) Math.Pow(2, binarySearchTree.GetHeightNode(node) + 1);
                VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
                VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
                DrawLeft(node, row, column, console, columnDelta);
                DrawRight(node, row, column, console, columnDelta);
            }
        }

        private static char[][] InitializeVisualization(BinarySearchTree<T>? bst, out int width) {
            if (bst != null) {
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
            } else {
                throw new NullReferenceException("The tree is empty!");
            }
        }


        public char[][] GetDrawedTree() {
            char[][] console = InitializeVisualization(this._bst, out int width);
            VisualizeNode(this._bst?.Root, 0, width / 2, console, width);
            return console;
        }

        public void VisualizeTree() {
            char[][] console = InitializeVisualization(this._bst, out int width);
            VisualizeNode(this._bst?.Root, 0, width / 2, console, width);
            foreach (char[] row in console) {
                Console.WriteLine(row);
            }
        }

    }
}
