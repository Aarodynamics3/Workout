using System;

namespace Workout {
    class WorkoutMain {
        static void Main(string[] args) {
            String response;
            bool endLoop = false;

            //TODO write to a file instead of printing out to console

            while (!endLoop) {
                Console.Write("Add a new workout? (y/n) ");
                response = Console.ReadLine();
                response = response.ToLower();

                if (response.Equals("y")) {
                    int week, day;

                    Console.Write("Week: ");
                    week = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Day: ");
                    day = Convert.ToInt32(Console.ReadLine());

                    /*
                     * TODO: Read in all of the previous workouts and ask the user
                     * if they want to use the same exercises as the previous day
                     * For example: if the user is inputting week 2 day 5, ask if they
                     * are using the same exercises as week 1 day 5.
                     * 
                     * TODO also create a preview to go along w/ this prompt
                     * Example: (DL PD MR FP HC DBC)
                     */

                    Workout _workout = new Workout(week, day);

                    Console.WriteLine(_workout.toDelimitedString());
                } else if (response.Equals("n")) {
                    endLoop = true;
                }
            }
        }
    }
}
