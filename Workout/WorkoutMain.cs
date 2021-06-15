using System;

namespace Workout {
    class WorkoutMain {
        static void Main(string[] args) {
            String response;

            Console.Write("Add a new workout? (y/n) ");
            response = Console.ReadLine();
            response = response.ToLower();

            if (response.Equals("y")) {
                int week, day;

                Console.Write("Week: ");
                week = Convert.ToInt32(Console.ReadLine());

                Console.Write("Day: ");
                day = Convert.ToInt32(Console.ReadLine());

                Workout _workout = new Workout(week, day);

                Console.WriteLine(_workout.toDelimitedString());
            } else if (response.Equals("n")) {
                Console.WriteLine("No.");
            }
        }
    }
}
