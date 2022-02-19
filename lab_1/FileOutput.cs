namespace lab_1 {
    class FileOutput {

        void tryOverwriteFile(ref string fileName) {
            bool isOverwrite = false;

            while (File.Exists(fileName) && !isOverwrite) {
                System.Console.WriteLine("The file with same name is exist. " +
                                         "Are you sure to want overwrite the file? Enter please y/n.");
                isOverwrite = ConsoleInput.isChoiceYes();
                if (!isOverwrite) {
                    System.Console.WriteLine("Please enter the filename:");
                    fileName = System.Console.ReadLine();
                }
            }

        }


        public void saveData<T>(BinarySearchTree<T> bst, bool isOut = false) where T : IComparable {
            System.Console.WriteLine("Do you want to save data to file? Input please y/n.");
            bool isYes = ConsoleInput.isChoiceYes();

            if (isYes) {
                bool isSuccess = saveDataToFile(bst);

                while (!isSuccess) {
                    System.Console.WriteLine("The data didn't save! Try again!");
                    isSuccess = saveDataToFile(bst);
                }

                System.Console.WriteLine("The data saved successfully!");
            }
        }


        bool saveDataToFile<T>(BinarySearchTree<T> bst, bool isOut = false) where T : IComparable {
            System.Console.WriteLine("Please, enter the filename:");
            string fileName = System.Console.ReadLine();
            tryOverwriteFile(ref fileName);
            FileStream? fileStream = null;
            try {
                fileStream = new FileStream(fileName, FileMode.OpenOrCreate);

            } catch (Exception) {
                System.Console.WriteLine("Sorry, there is a problem with file.");
                return false;
            }

            using StreamWriter writer = new StreamWriter(fileStream);
            writeDateToFile(writer, bst);
            return true;
        }

        private void writeDateToFile<T>(StreamWriter writer, BinarySearchTree<T> bst, bool isOut = false) where T : IComparable {
            List<T> detourData = bst.rightDetour(bst.root);
            if (isOut) {
                //bst.print();
            } else {
                foreach (T data in detourData) {
                    writer.Write(data + " ");
                }
            }
        }
    }
}
