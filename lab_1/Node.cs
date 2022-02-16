using System;

namespace lab_1 {
    class Node<T> {
        private T _value;
        private Node<T>? _left;
        private Node<T>? _right;


        public Node(T value) {
            this._value = value;
        }

        public T value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public Node<T>? left {
            get {
                return this._left;
            }

            set {
                this._left = value;
            }
        }

        public Node<T>? right {
            get {
                return this._right;
            }

            set {
                this._right = value;
            }
        }


        public override string? ToString() {
            return this.value?.ToString();
        }

      
    }
}
