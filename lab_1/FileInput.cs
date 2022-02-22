namespace lab_1 {
    class FileInput : Input {

        public bool Read(ref BinarySearchTree<int>? bst){
            Console.WriteLine("Enter the filepath please:");
            string? filePath = Console.ReadLine();
            if (File.Exists(filePath)) {
                string data = File.ReadAllLines(filePath)[0];
                List<int> numbers = GetArray(data);
                bst = new BinarySearchTree<int>(numbers);
                return true;
            }

            Console.WriteLine("The file can't be opened");
            return false;

        }
    }
}