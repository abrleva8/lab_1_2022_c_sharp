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
    };

    class Menu {
        public void greeting() {
            System.Console.WriteLine("This is the first laboratory task of the first variation. " +
                                     System.Environment.NewLine +
                                     "The author is Levon Abramyan, Group 404, Course 2nd");

            System.Console.WriteLine("The problem is:");
            System.Console.WriteLine("Implement binary search tree and demonstrate the characteristic feature.");
            System.Console.WriteLine("Implement the ability to add elements, to remove elements and to visualize the tree.");
        }


        public void printMenu() {
            System.Console.WriteLine("Enter 1 to read data from console.");
            System.Console.WriteLine("Enter 2 to read data from file.");
            System.Console.WriteLine("Enter 3 to set random number." );
            System.Console.WriteLine("Enter 0 to exit.");
        }


        public void printMenuForTreeInterface() {
            System.Console.WriteLine("Enter 1 to add data");
            System.Console.WriteLine("Enter 2 to delete data");
            System.Console.WriteLine("Enter 3 to print tree");
            System.Console.WriteLine("Enter 0 to back.");
        }

        public void binaryTreeInterface(BinaryTreeInterface bti, ref BinarySearchTree<Int32> bst) {
            int d;
            switch (bti) {
                case BinaryTreeInterface.BACK:
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(bti), bti, null);
            }
        }


        public void interfaceMenu() {
            bool is_restart = true;
            do {
                Input input = new Input();
                printMenu();
                // поменять на максимум и минимум чтобы избежать лишней зависимости
                MenuChoices choice = (MenuChoices) Input.getNumber((int) MenuChoices.EXIT, (int) MenuChoices.RANDOM);
                switch (choice) {
                    case MenuChoices.EXIT:
                        System.Console.WriteLine("Your choice is EXIT");
                        is_restart = false;
                        break;
                    case MenuChoices.CONSOLE:
                        System.Console.WriteLine("Your choice is CONSOLE");
                        System.Console.WriteLine("Enter the binary tree search's numbers");
                        List<Int32> numbers = input.getArray(System.Console.ReadLine());
                        BinarySearchTree<Int32> bst = new BinarySearchTree<int>(numbers);
                        printMenuForTreeInterface();
                        // поменять на максимум и минимум чтобы избежать лишней зависимости
                        BinaryTreeInterface d = (BinaryTreeInterface)
                            Input.getNumber((int) BinaryTreeInterface.BACK, (int) BinaryTreeInterface.PRINT);
                        binaryTreeInterface(d, ref bst);
                        // bst.print();
                        continue;
                        break;
                }
            } while (is_restart);
        }
    }
}

