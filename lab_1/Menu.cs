namespace lab_1 {

    public enum MenuChoices {
        Exit,
        Console,
        Files,
        Random,
    }

    public enum BinaryTreeInterface {
        Back,
        Add,
        Delete,
        Print,
        Save
    };

    class Menu {
        public void Greeting() {
            Console.WriteLine("This is the first laboratory task of the first variation. " +
                                     Environment.NewLine +
                                     "The author is Levon Abramyan, Group 404, Course 2nd");

            Console.WriteLine("The problem is:");
            Console.WriteLine("Implement binary search tree and demonstrate the characteristic feature.");
            Console.WriteLine("Implement the ability to add elements, to remove elements and to visualize the tree.");
            Console.WriteLine();
        }


        public void PrintMenu() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to read data from console.");
            Console.WriteLine("Enter 2 to read data from file.");
            Console.WriteLine("Enter 3 to set random number." );
            Console.WriteLine("Enter 0 to exit.");
        }


        public void PrintMenuForTreeInterface() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to add data");
            Console.WriteLine("Enter 2 to delete data");
            Console.WriteLine("Enter 3 to print tree");
            Console.WriteLine("Enter 4 to save tree");
            Console.WriteLine("Enter 0 to back.");
        }

        public void BinaryTreeInterface(ref BinarySearchTree<int>? bst) {
            bool isRestart = true;
            int value = 0;
            do {
                PrintMenuForTreeInterface();
                BinaryTreeInterface bti = (BinaryTreeInterface) Input.GetNumber();
                FileOutput fo = new FileOutput();
                switch (bti) {
                    case lab_1.BinaryTreeInterface.Back:
                        Console.WriteLine("The data will be lost!");
                        fo.SaveData(bst);
                        isRestart = false;
                        break;
                    case lab_1.BinaryTreeInterface.Add: {
                        Console.WriteLine("Enter number to add to the tree");
                        value = Input.GetNumber();
                        bool isAdded = bst != null && bst.Insert(value);
                        Console.WriteLine(isAdded ? $"{value} has been added to the tree" : $"{value} already is in the tree");
                        break;
                    }
                    case lab_1.BinaryTreeInterface.Delete:
                        Console.WriteLine("Enter number to delete from the tree");
                        value = Input.GetNumber();
                        bool isDeleted = bst != null && bst.Remove(value);
                        Console.WriteLine(isDeleted ? $"{value} has been deleted from the tree" : $"{value} isn't in the tree");
                        break;
                    case lab_1.BinaryTreeInterface.Print:
                        //bst?.Print();
                        Console.WriteLine();
                        bst?.VisualizeTree();
                        break;
                    case lab_1.BinaryTreeInterface.Save:
                        fo.SaveData(bst, true);
                        break;
                    default:
                        Console.WriteLine("Please, enter a number between" +
                                                 $"{(int) lab_1.BinaryTreeInterface.Back} and {(int) lab_1.BinaryTreeInterface.Save}");
                        break;
                }
            } while (isRestart);
           
            
        }


        public void InterfaceMenu() {
            bool isRestart = true;
            BinarySearchTree<int>? bst = null;
            FileOutput fo = new FileOutput();
            do {
                Input input = new Input();
                PrintMenu();
                MenuChoices choice = (MenuChoices) Input.GetNumber();
                switch (choice) {
                    case MenuChoices.Exit:
                        Console.WriteLine("Your choice is EXIT");
                        Console.WriteLine("The program will be closed");
                        isRestart = false;
                        break;
                    case MenuChoices.Console:
                        Console.WriteLine("Your choice is CONSOLE");
                        Console.WriteLine("Enter the space-separated binary tree search's numbers in the next row");
                        List<int> numbers = Input.GetArray(Console.ReadLine());
                        bst = new BinarySearchTree<int>(numbers);
                        Console.WriteLine(bst.GetHeight(bst.Root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        break;

                    case MenuChoices.Files:
                        Console.WriteLine("Your choice is FILES");
                        FileInput fileInput = new FileInput();
                        bool isRead = fileInput.Read(ref bst);
                        if (isRead) {
                            Console.WriteLine(bst != null && bst.GetHeight(bst.Root) == 0
                                ? "Warning! The tree is empty!"
                                : "The tree is filled!");
                        }
                        break;

                    case MenuChoices.Random:
                        Console.WriteLine("Your choice is RANDOM");
                        Console.WriteLine("Enter the maximum size of the tree");
                        int size = Input.GetNumber(1, BinarySearchTree<int>.MaxRandomSize);
                        bst = BinarySearchTree<int>.CreateRandomIntTree(size);
                        Console.WriteLine(bst != null && bst.GetHeight(bst.Root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        break;
                    default:
                        Console.WriteLine($"Please, enter a number between {(int)MenuChoices.Exit} and {(int)MenuChoices.Random}");
                        continue;
                }

                if (choice != MenuChoices.Files && choice != MenuChoices.Exit) {
                    fo.SaveData(bst);
                }

                if (choice != MenuChoices.Exit) {
                    BinaryTreeInterface(ref bst);
                }
                
            } while (isRestart);
        }
    }
}

