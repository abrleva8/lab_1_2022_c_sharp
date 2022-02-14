using System;

namespace lab_1 {
    class Node {
        public int value;
        public Node left;
        public Node right;

        public override string ToString() {
            return this.value.ToString();
        }
    }
}
