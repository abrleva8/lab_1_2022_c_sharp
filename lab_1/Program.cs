using System;

namespace lab_1 {
    class Program {

        private void run() {
            Menu menu = new Menu();
            Input input = new Input();
            menu.greeting();
            menu.interfaceMenu();

            // double d = input.getNumber();
            // System.Console.WriteLine(d);


            // BinarySearchTree<Int32> bst = new BinarySearchTree<Int32>();
            // // int[] numbers = {8, 3, 1, 6, 10, 9, 14, 13, 4, 7};
            // int[] numbers = {8, 3, 1, 6, 7, 10, 9, 14, 4};
            // foreach (int num in numbers) {
            //     bst.insert(num);
            // }
            //
            // // bst.detour(bst.root);
            //
            // // Console.WriteLine(bst.find(1));
            // // Console.WriteLine(bst.find(2));
            // // Console.WriteLine(bst.find(3));
            // // Console.WriteLine(bst.find(4));
            // // Console.WriteLine(bst.find(5));
            // // Console.WriteLine(bst.find(6));
            // // Console.WriteLine(bst.find(7));
            // // Console.WriteLine(bst.find(8));
            // // Console.WriteLine(bst.find(9));
            //
            // bst.remove(3);
            // bst.detour(bst.root);
            // Console.WriteLine(bst.find(3));
            //
            // //
            // // bst.remove(6);
            // // bst.detour(bst.root);
            // // Console.WriteLine(bst.find(6));
            //
            //
            //
            // // bst.remove(10);
            // // bst.detour(bst.root);
            // // Console.WriteLine(bst.find(10));


            Console.ReadKey();
        }

        public static void Main(string[] args) {
            new Program().run();
        }
    }
}