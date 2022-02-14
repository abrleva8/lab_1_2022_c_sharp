using System;

namespace lab_1 {

    class BinarySearchTree {
        public Node root;

        public BinarySearchTree() {
            root = null;
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

        public void detour(Node node) {
            if (node != null) {
                this.detour(node.left);
                Console.WriteLine(node + " ");
                this.detour(node.right);
            }
        }
    }
}
