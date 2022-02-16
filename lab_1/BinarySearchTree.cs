using System;
using System.Collections;

namespace lab_1 {

    class BinarySearchTree<T> where T : IComparable {
        private Node<T>? _root;

        public BinarySearchTree(List<T> values) {
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
            return Convert.ToInt32(node.left is not null) + Convert.ToInt32(node.right is not null);
        }

        private Node<T>? getMin(Node<T> node) {
            if (node.left is null) {
                return null;
            }

            while (node.left is not null) {
                 node = node.left;
            }

            return node;
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
                if (value.CompareTo(before.value) < 0) {
                    before.left = newNode;
                } else {
                    before.right = newNode;
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

            while (after.value.CompareTo(value) != 0) {
                before = after;

                if (value.CompareTo(after.value) < 0) {
                    after = after.left;
                } else if (value.CompareTo(after.value) > 0) {
                    after = after.right;
                }
            }

            if (this.numberOfChildren(after) == 0) {
                if (value.CompareTo(before.value) < 0) {
                    before.left = null;
                } else if (value.CompareTo(before.value) > 0) {
                    before.right = null;
                }
                // after = null;
            }

            if (this.numberOfChildren(after) == 1) {
                if (value.CompareTo(before.value) < 0) {
                    if (after.right is not null) {
                        before.left = after.right;
                    } else {
                        before.left = after.left;
                    }
                    after.right = null;
                } else if (value.CompareTo(before.value) > 0) {
                    if (after.right is not null) {
                        before.right = after.right;
                    } else {
                        before.right = after.left;
                    }
                }

                after.right = null;
                after.left = null;
            }

            if (this.numberOfChildren(after) == 2) {
                Node<T>? minNode = getMin(after.right);
                if (value.CompareTo(before.value) < 0) {
                    if (minNode is null) {
                        before.left = after.right;
                        before.left.left = after.left;
                    } else {
                        Node<T> newNode = new Node<T>(minNode.value);
                        remove(minNode.value);
                        newNode.left = after.left;
                        newNode.right = after.right;
                        before.left = newNode;
                    }
                } else {
                    if (minNode is null) {
                        before.right = after.right;
                        before.right.left = after.left;
                    } else {
                        Node<T>? newNode = new Node<T>(minNode.value);
                        remove(minNode.value);
                        newNode.left = after.left;
                        newNode.right = after.right;
                        before.right = newNode;
                    }
                }

                after.right = null;
                after.left = null;


            }


            return true;
        }

        public void detour(Node<T>? node) {
            if (node == null) return;
            this.detour(node.left);
            Console.WriteLine(node + ": left child for " + node.left + " right child " + node.right);
            this.detour(node.right);
        }

    }
}
