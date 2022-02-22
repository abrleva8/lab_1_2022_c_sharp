namespace lab_1 {
    class Program {

        private void Run() {
            Menu menu = new Menu();
            menu.Greeting();
            menu.InterfaceMenu();
            Console.ReadKey();
        }

        public static void Main() {
            new Program().Run();
        }
    }
}