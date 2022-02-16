using System;
using System.Security.Cryptography.X509Certificates;

namespace lab_1 {
    class Input {
        public int getNumber() {
            int num = 0;
            while (true) {

                if (int.TryParse(Console.ReadLine(), out num)) {
                    break;
                }

                Console.WriteLine("Invalid number. Try again.");
            }

            return num;
        }


        public List<Int32> getArray(string? str) {
            string[] subs = str.Split(' ');
            List<Int32> numbers = new List<int>(); 
            foreach (string sub in subs) {
                if (int.TryParse(sub, out int number)) {
                    numbers.Add(number);
                }
            }

            return numbers;
        }
    }
}
