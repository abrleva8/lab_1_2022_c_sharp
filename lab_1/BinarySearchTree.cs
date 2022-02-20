using System;
using System.Collections;

namespace lab_1 {

    class BinarySearchTree<T> where T : IComparable {
        private Node<T>? _root;
        private const int COLUMN_WIDTH = 10;

        public BinarySearchTree(List<T> values) {
            this._root = null;
            foreach (T value in values) {
                this.insert(value);
            }
        }

        public Node<T>? root {
            get {
                return this._root;
            }

            set {
                this._root = value;
            }
        }

        public int numberOfChildren(Node<T>? node) {
            return Convert.ToInt32(node?.left is not null) + Convert.ToInt32(node?.right is not null);
        }

        public bool insert(T value) {
            Node<T>? before = null;
            Node<T>? after = this.root;

            while (after != null) {
                before = after;

                if (value.CompareTo(after.value) < 0) {
                    after = after.left;
                } else if (value.CompareTo(after.value) > 0) {
                    after = after.right;
                } else {
                    return false;
                }
            }

            Node<T>? newNode = new Node<T>(value);

            if (this.root == null) {
                this.root = newNode;
            } else {
                if (before != null && value.CompareTo(before.value) < 0) {
                    before.left = newNode;
                } else {
                    if (before != null) before.right = newNode;
                }
            }

            return true;
        }

        public bool find(T value) {
            Node<T>? node = this.root;
            while (node != null) {

                if (value.CompareTo(node.value) < 0) {
                    node = node.left;
                } else if (value.CompareTo(node.value) > 0) {
                    node = node.right;
                } else {
                    return true;
                }
            }

            return false;
        }

        public bool remove(T value) {
            
            if (!find(value)) {
                return false;
            }

            Node<T>? before = null;
            Node<T>? after = this.root;

            while (after != null && after.value.CompareTo(value) != 0) {
                before = after;

                if (value.CompareTo(after.value) < 0) {
                    after = after.left;
                } else if (value.CompareTo(after.value) > 0) {
                    after = after.right;
                }
            }

            if (this.numberOfChildren(after) == 0) {
                if (before is null) {
                    this._root = null;
                } else {
                    if (value.CompareTo(before.value) < 0) {
                        before.left = null;
                    } else if (value.CompareTo(before.value) > 0) {
                        before.right = null;
                    }
                }
                // after = null;
            }

            if (this.numberOfChildren(after) == 1) {
                if (before is null) {
                    this._root = after?.right ?? after?.left;
                } else {
                    if (value.CompareTo(before.value) < 0) {
                        before.left = after?.right ?? after?.left;

                        if (after != null) after.right = null;
                    } else if (value.CompareTo(before.value) > 0) {
                        before.right = after?.right ?? after?.left;
                    }
                }

                if (after != null) {
                    after.right = null;
                    after.left = null;
                }
            }

            if (this.numberOfChildren(after) == 2) {
                Node<T>? node = after?.right;
                Node<T>? p = null;
                while (node?.left is not null) {
                    p = node;
                    node = node.left;
                }


                if (p is not null) {
                    p.left = node?.right;
                } else {
                    if (after != null) after.right = node?.right;
                }

                if (after != null && node != null)
                    after.value = node.value;
            }


            return true;
        }

        public int getHeight(Node<T>? node) {
            if (node is null) {
                return 0;
            }

            int leftHeight = getHeight(node.left);
            int rightHeight = getHeight(node.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        
        public void detour(Node<T>? node) {
            if (node == null) return;
            this.detour(node.left);
            Console.WriteLine(node + ": left child for " + node.left + " right child " + node.right);
            this.detour(node.right);
        }

        public List<T> rightDetour(Node<T>? node) {
            List<T> detour = new List<T>();
            rightDetourWorker(node, ref detour);
            return detour;
        }

        private void rightDetourWorker(Node<T>? node, ref List<T> detour) {
            if (node == null) return;
            detour.Add(node.value);
            this.rightDetourWorker(node.left, ref detour);
            this.rightDetourWorker(node.right, ref detour);
        }

        public void print() {
            this.print(this._root, 0);
        }

        private void print(Node<T>? node, int space) {
            while (true) {
                if (node is null) {
                    return;
                }

                space += COLUMN_WIDTH;

                print(node.right, space);

                System.Console.WriteLine();
                for (int i = COLUMN_WIDTH; i < space; i++) System.Console.Write(" ");
                System.Console.WriteLine(node);

                node = node.left;
            }
        }

        public static BinarySearchTree<int>? createRandomIntTree(int maxSize, int minValue, int maxValue) {
            var rand = new Random();
            int size = rand.Next(1, maxSize);
            List<int> values = new List<int>(size);
            for (int i = 0; i < size; i++) {
                values.Add(rand.Next(minValue, maxValue));
            }

            return new BinarySearchTree<int>(values);
        }
    }
}
