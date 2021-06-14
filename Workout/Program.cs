using System;

namespace Workout {
    class Program {
        static void Main(string[] args) {
            String response;

            Console.Write("Add a new workout? (y/n) ");
            response = Console.ReadLine();
            response = response.ToLower();

            if (response.Equals("y")) {
                
            } else if (response.Equals("n")) {

            }
        }
    }
}
