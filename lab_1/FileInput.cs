namespace lab_1 {
    class FileInput : Input {

        public bool read(ref BinarySearchTree<int>? bst){
            System.Console.WriteLine("Enter the filepath please:");
            string? filePath = System.Console.ReadLine();
            if (File.Exists(filePath)) {
                string data = File.ReadAllLines(filePath)[0];
                List<int> numbers = getArray(data);
                bst = new BinarySearchTree<int>(numbers);
                return true;
            }

            System.Console.WriteLine("The file can't be opened");
            return false;

        }
    }
}