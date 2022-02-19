namespace lab_1 {
    class ConsoleInput : Input {
        public static bool isChoiceYes() {
            string? save = System.Console.ReadLine();
            while (save.CompareTo("y") != 0 && save.CompareTo("n") != 0) {
                System.Console.WriteLine("Wrong input. Try again.");
                save = System.Console.ReadLine();
            }
            return save.CompareTo("y") == 0;
        }
    }
}
