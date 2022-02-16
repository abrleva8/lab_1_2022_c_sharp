using System;

namespace lab_1 {

    public enum MenuChoises {
        EXIT,
        CONSOLE,
        FILES,
        RANDOM,
        TEST
    }

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


        public void interfaceMenu() {
            bool is_restart = true;
            do {
                Input input = new Input();
                printMenu();
                MenuChoises choice = (MenuChoises) input.getNumber();
                switch (choice) {
                    case MenuChoises.EXIT:
                        System.Console.WriteLine("Your choice is EXIT");
                        is_restart = false;
                        //continue;
                        break;
                    case MenuChoises.CONSOLE:
                        System.Console.WriteLine("Your choice is CONSOLE");
                        System.Console.WriteLine("Enter the binary tree search's numbers");
                        List<Int32> numbers = input.getArray(System.Console.ReadLine());
                        BinarySearchTree<Int32> bst = new BinarySearchTree<int>(numbers);
                        bst.detour(bst.root);
                        continue;
                        break;
                }
            } while (is_restart);
        }
    }
}

