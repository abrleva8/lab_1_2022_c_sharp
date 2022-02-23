namespace lab_1 {
    public class Node<T> {
        private T _value;
        private Node<T>? _left;
        private Node<T>? _right;

        public Node(T value) {
            this._value = value;
        }

        public T Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }

        public Node<T>? Left {
            get {
                return this._left;
            }

            set {
                this._left = value;
            }
        }

        public Node<T>? Right {
            get {
                return this._right;
            }

            set {
                this._right = value;
            }
        }


        public override string? ToString() {
            return this.Value?.ToString();
        }
    }
}
