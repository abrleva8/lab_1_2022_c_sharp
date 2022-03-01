namespace lab_1 {
    class FileInput : Input {

        public bool Read(ref BinarySearchTree<int>? bst){
            Console.WriteLine("Enter the filepath please:");
            string? filePath = Console.ReadLine();
            List<int> numbers = new List<int>();
            if (File.Exists(filePath)) {
                string[] data = File.ReadAllLines(filePath);
                foreach (string row in data) {
                    try {
                        List<int> tmp = GetArray(row);
                        numbers.AddRange(tmp);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
                bst = new BinarySearchTree<int>(numbers);
                return true;
            }

            Console.WriteLine("The file can't be opened");
            return false;

        }
    }
}