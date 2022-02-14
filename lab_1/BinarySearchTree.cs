using System;

namespace lab_1 {

    class BinarySearchTree {
        public Node root;

        public BinarySearchTree() {
            root = null;
        }

        public int numberOfChildren(Node node) {
            return Convert.ToInt32(node.left is not null) + Convert.ToInt32(node.right is not null);
        }

        public Node getMin(Node node) {
            if (node.left is null) {
                return null;
            }

            while (node.left is not null) {
                 node = node.left;
            }

            return node;
        }

        public bool insert(int value) {
            Node before = null, after = this.root;

            while (after != null) {
                before = after;

                if (value < after.value) {
                    after = after.left;
                } else if (value > after.value) {
                    after = after.right;
                } else {
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.value = value;

            if (this.root == null) {
                this.root = newNode;
            } else {
                if (value < before.value) {
                    before.left = newNode;
                } else {
                    before.right = newNode;
                }
            }

            return true;
        }

        public bool find(int value) {
            Node node = this.root;
            while (node != null) {

                if (value < node.value) {
                    node = node.left;
                } else if (value > node.value) {
                    node = node.right;
                } else {
                    return true;
                }
            }

            return false;
        }

        public bool remove(int value) {
            
            if (!find(value)) {
                return false;
            }

            Node before = null, after = this.root;

            while (after.value != value) {
                before = after;

                if (value < after.value) {
                    after = after.left;
                } else if (value > after.value) {
                    after = after.right;
                }
            }

            if (this.numberOfChildren(after) == 0) {
                if(value < before.value) {
                    before.left = null;
                } else if (value > before.value) {
                    before.right = null;
                }
                // after = null;
            }

            if (this.numberOfChildren(after) == 1) {
                if (value < before.value) {
                    if (after.right is not null) {
                        before.left = after.right;
                    } else {
                        before.left = after.left;
                    }
                    after.right = null;
                } else if (value > before.value) {
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
                Node minNode = getMin(after.right);
                if (value < before.value) {
                    if (minNode is null) {
                        before.left = after.right;
                        before.left.left = after.left;
                    } else {
                        Node newNode = new Node();
                        newNode.value = minNode.value;
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
                        Node newNode = new Node();
                        newNode.value = minNode.value;
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

        public void detour(Node node) {
            if (node != null) {
                this.detour(node.left);
                Console.WriteLine(node + ": left child for " + node.left + " right child " + node.right);
                this.detour(node.right);
            }
        }
    }
}
