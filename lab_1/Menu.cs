using System;

namespace lab_1 {

    public enum MenuChoices {
        EXIT,
        CONSOLE,
        FILES,
        RANDOM,
    }

    public enum BinaryTreeInterface {
        BACK,
        ADD,
        DELETE,
        PRINT,
        SAVE
    };

    class Menu {
        public void greeting() {
            System.Console.WriteLine("This is the first laboratory task of the first variation. " +
                                     System.Environment.NewLine +
                                     "The author is Levon Abramyan, Group 404, Course 2nd");

            System.Console.WriteLine("The problem is:");
            System.Console.WriteLine("Implement binary search tree and demonstrate the characteristic feature.");
            System.Console.WriteLine("Implement the ability to add elements, to remove elements and to visualize the tree." + System.Environment.NewLine);
        }


        public void printMenu() {
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 1 to read data from console.");
            System.Console.WriteLine("Enter 2 to read data from file.");
            System.Console.WriteLine("Enter 3 to set random number." );
            System.Console.WriteLine("Enter 0 to exit.");
        }


        public void printMenuForTreeInterface() {
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 1 to add data");
            System.Console.WriteLine("Enter 2 to delete data");
            System.Console.WriteLine("Enter 3 to print tree");
            System.Console.WriteLine("Enter 4 to save tree");
            System.Console.WriteLine("Enter 0 to back.");
        }

        public void binaryTreeInterface(ref BinarySearchTree<int>? bst) {
            bool isRestart = true;
            int d = 0;
            do {
                printMenuForTreeInterface();
                BinaryTreeInterface bti = (BinaryTreeInterface)
                    Input.getNumber((int) BinaryTreeInterface.BACK, (int) BinaryTreeInterface.SAVE);
                FileOutput fo = new FileOutput();
                switch (bti) {
                    case BinaryTreeInterface.BACK:
                        System.Console.WriteLine("The data will be lost!");
                        fo.saveData(bst);
                        isRestart = false;
                        break;
                    case BinaryTreeInterface.ADD: {
                        System.Console.WriteLine("Enter number to add to the tree");
                        d = Input.getNumber();
                        bool isAdded = bst != null && bst.insert(d);
                        System.Console.WriteLine(isAdded ? $"{d} has been added to the tree" : $"{d} already is in the tree");
                        break;
                    }
                    case BinaryTreeInterface.DELETE:
                        System.Console.WriteLine("Enter number to delete from the tree");
                        d = Input.getNumber();
                        bool isDeleted = bst != null && bst.remove(d);
                        System.Console.WriteLine(isDeleted ? $"{d} has been deleted from the tree" : $"{d} isn't in the tree");
                        break;
                    case BinaryTreeInterface.PRINT:
                        bst?.print();
                        System.Console.WriteLine();
                        bst?.visualizeTree(bst);
                        break;
                    case BinaryTreeInterface.SAVE:
                        fo.saveData(bst);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(bti), bti, null);
                }
            } while (isRestart);
           
            
        }


        public void interfaceMenu() {
            bool isRestart = true;
            BinarySearchTree<int>? bst = null;
            FileOutput fo = new FileOutput();
            do {
                Input input = new Input();
                printMenu();
                MenuChoices choice = (MenuChoices) Input.getNumber();
                switch (choice) {
                    case MenuChoices.EXIT:
                        System.Console.WriteLine("Your choice is EXIT");
                        System.Console.WriteLine("The program will be closed");
                        isRestart = false;
                        break;
                    case MenuChoices.CONSOLE:
                        System.Console.WriteLine("Your choice is CONSOLE");
                        System.Console.WriteLine("Enter the space-separated binary tree search's numbers in the next row");
                        List<int> numbers = input.getArray(System.Console.ReadLine());
                        bst = new BinarySearchTree<int>(numbers);
                        System.Console.WriteLine(bst.getHeight(bst.root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        break;

                    case MenuChoices.FILES:
                        System.Console.WriteLine("Your choice is FILES");
                        FileInput fileInput = new FileInput();
                        bool isRead = fileInput.read(ref bst);
                        if (isRead) {
                            System.Console.WriteLine(bst != null && bst.getHeight(bst.root) == 0
                                ? "Warning! The tree is empty!"
                                : "The tree is filled!");
                        }
                        break;

                    case MenuChoices.RANDOM:
                        System.Console.WriteLine("Your choice is RANDOM");
                        System.Console.WriteLine("Enter the maximum size of the tree");
                        int size = Input.getNumber(1, Int32.MaxValue);
                        bst = BinarySearchTree<int>.createRandomIntTree(size);
                        System.Console.WriteLine(bst != null && bst.getHeight(bst.root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        break;
                    default:
                        System.Console.WriteLine($"Please, enter a number between {(int)MenuChoices.EXIT} and {(int)MenuChoices.RANDOM}");
                        continue;
                }

                if (choice != MenuChoices.FILES && choice != MenuChoices.EXIT) {
                    fo.saveData(bst);
                }

                if (choice != MenuChoices.EXIT) {
                    binaryTreeInterface(ref bst);
                }
                
            } while (isRestart);
        }
    }
}

