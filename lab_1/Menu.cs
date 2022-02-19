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

        public void binaryTreeInterface(ref BinarySearchTree<Int32> bst) {
            bool isRestart = true;
            int d = 0;
            do {
                printMenuForTreeInterface();
                BinaryTreeInterface bti = (BinaryTreeInterface)
                    Input.getNumber((int) BinaryTreeInterface.BACK, (int) BinaryTreeInterface.SAVE);
                switch (bti) {
                    case BinaryTreeInterface.BACK:
                        isRestart = false;
                        break;
                    case BinaryTreeInterface.ADD: {
                        System.Console.WriteLine("Enter number to add to the tree");
                        d = Input.getNumber();
                        bst.insert(d);
                        break;
                    }
                    case BinaryTreeInterface.DELETE:
                        System.Console.WriteLine("Enter number to delete from the tree");
                        d = Input.getNumber();
                        bst.remove(d);
                        break;
                    case BinaryTreeInterface.PRINT:
                        bst.print();
                        break;
                    case BinaryTreeInterface.SAVE:
                        FileOutput fo = new FileOutput(); 
                        fo.saveData(bst);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(bti), bti, null);
                }
            } while (isRestart);
           
            
        }


        public void interfaceMenu() {
            bool isRestart = true;
            BinarySearchTree<int> bst = null;
            FileOutput fo = new FileOutput();
            do {
                Input input = new Input();
                printMenu();
                // поменять на максимум и минимум чтобы избежать лишней зависимости
                MenuChoices choice = (MenuChoices) Input.getNumber((int) MenuChoices.EXIT, (int) MenuChoices.RANDOM);
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
                        fo.saveData(bst);
                        binaryTreeInterface(ref bst);
                        continue;

                    case MenuChoices.FILES:
                        System.Console.WriteLine("Your choice is FILES");
                        FileInput fileInput = new FileInput();
                        fileInput.read(ref bst);
                        System.Console.WriteLine(bst.getHeight(bst.root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        binaryTreeInterface(ref bst);
                        break;

                    case MenuChoices.RANDOM:
                        System.Console.WriteLine("Your choice is RANDOM");
                        bst = BinarySearchTree<int>.createRandomIntTree(10, 1, 10);
                        System.Console.WriteLine(bst.getHeight(bst.root) == 0
                            ? "Warning! The tree is empty!"
                            : "The tree is filled!");
                        fo.saveData(bst);
                        binaryTreeInterface(ref bst);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (isRestart);
        }
    }
}

