using System;

namespace lab_1 {
    class Program {



        private void run() {
            Menu menu = new Menu();
            menu.greeting();



            BinarySearchTree bst = new BinarySearchTree();
            bst.insert(4);
            bst.insert(6);
            bst.insert(1);
            bst.insert(3);
            bst.insert(2);
            bst.insert(1);
            bst.insert(8);

            bst.detour(bst.root);

            Console.WriteLine(bst.find(1));
            Console.WriteLine(bst.find(2));
            Console.WriteLine(bst.find(3));
            Console.WriteLine(bst.find(4));
            Console.WriteLine(bst.find(5));
            Console.WriteLine(bst.find(6));
            Console.WriteLine(bst.find(7));
            Console.WriteLine(bst.find(8));
            Console.WriteLine(bst.find(9));


            Console.ReadKey();
        }

        public static void Main(string[] args) {
            new Program().run();
        }
    }
}