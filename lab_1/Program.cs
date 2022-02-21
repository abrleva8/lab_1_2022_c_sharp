using System;

namespace lab_1 {
    class Program {

        private void run() {
            Menu menu = new Menu();
            menu.greeting();
            menu.interfaceMenu();
            Console.ReadKey();
        }

        public static void Main() {
            new Program().run();
        }
    }
}