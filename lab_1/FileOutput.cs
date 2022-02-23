namespace lab_1 {
    class FileOutput {

        void TryOverwriteFile(ref string? fileName) {
            bool isOverwrite = false;

            while (File.Exists(fileName) && !isOverwrite) {
                Console.WriteLine("The file with same name exists. " +
                                         "Are you sure to want overwrite the file? Enter please y/n.");
                isOverwrite = ConsoleInput.IsChoiceYes();
                if (!isOverwrite) {
                    Console.WriteLine("Please enter the filename:");
                    fileName = Console.ReadLine();
                }
            }

        }


        public void SaveData<T>(BinarySearchTree<T>? bst, bool isOut = false) where T : IComparable {
            Console.WriteLine("Do you want to save data to a file? Input please y/n.");
            bool isYes = ConsoleInput.IsChoiceYes();

            if (isYes) {
                bool isSuccess = SaveDataToFile(bst, isOut);

                while (!isSuccess) {
                    Console.WriteLine("The data didn't save! Try again!");
                    isSuccess = SaveDataToFile(bst, isOut);
                }

                Console.WriteLine("The data saved successfully!");
            }
        }


        bool SaveDataToFile<T>(BinarySearchTree<T>? bst, bool isOut = false) where T : IComparable {
            Console.WriteLine("Please, enter the filename:");
            string? fileName = Console.ReadLine();
            TryOverwriteFile(ref fileName);
            FileStream? fileStream = null;
            try {
                if (fileName != null) fileStream = new FileStream(fileName, FileMode.Create);
            } catch (Exception) {
                Console.WriteLine("Sorry, there is a problem with the file.");
                return false;
            }

            if (fileStream == null) return true;
            using StreamWriter writer = new StreamWriter(fileStream);
            WriteDateToFile(writer, bst, isOut);

            return true;
        }

        private void WriteDateToFile<T>(TextWriter writer, BinarySearchTree<T>? bst, bool isOut = false) where T : IComparable {
            if (bst == null) return;
            if (isOut) {
                TreeDrawer<T> treeDrawer = new TreeDrawer<T>(bst);
                char[][] drawedTree = treeDrawer.GetDrawedTree();
                foreach (var row in drawedTree) {
                    writer.WriteLine(row);
                }
            } else {
                List<T>? detourData = bst?.RightDetour(bst.Root);
                if (detourData == null) return;
                foreach (T data in detourData) {
                    writer.Write(data + " ");
                }
            }
        }
    }
}
