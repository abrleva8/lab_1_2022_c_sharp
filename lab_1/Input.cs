namespace lab_1 {
    class Input {
        public static int GetNumber() {
            int num = 0;
            while (true) {

                if (int.TryParse(Console.ReadLine(), out num)) {
                    break;
                }

                Console.WriteLine("Invalid number. Try again.");
            }

            return num;
        }

        public static int GetNumber(int a, int b) {
            int num = GetNumber();
            while (num < a || num > b) {
                Console.WriteLine($"Please enter number between {a} and {b}");
                num = GetNumber();
            }

            return num;
        }


        public static List<Int32> GetArray(string? str) {
            string[]? subs = str?.Split(' ');
            List<Int32> numbers = new List<int>();
            if (subs == null) return numbers;
            foreach (string sub in subs) {
                if (int.TryParse(sub, out int number)) {
                    numbers.Add(number);
                }
            }

            return numbers;
        }
    }
}
