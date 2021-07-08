using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Workout {
    class Workout {
        private int week, day;
        private ArrayList exercises;

        public Workout(int week, int day) {
            this.week = week;
            this.day = day;
            exercises = new ArrayList();

            constructWorkout();
        }

        // Creates a workout from a delimited string.
        public Workout(String input) {
            String[] list = input.Split("|");

            this.week = Convert.ToInt32(list[0]);
            this.day = Convert.ToInt32(list[1]);
            exercises = new ArrayList();
            
            for (int i = 0; i < (list.Length - 2) / 3; i++) {
                exercises.Add(
                    new Exercise(list[(i * 3) + 2], list[(i * 3) + 3], Convert.ToDouble(list[(i * 3) + 4]))
                );
            }
        }

        private void constructWorkout() {
            bool doneInputting = false;
            String name, reps;
            double weight;
            Exercise temp;

            // While not done inputting, prompt for name, reps, and weight.
            while (!doneInputting) {
                Console.Write("Name: ");
                name = Console.ReadLine().ToTitleCase();

                Console.Write("Reps: ");
                reps = Console.ReadLine();

                Console.Write("Weight: ");
                weight = Convert.ToDouble(Console.ReadLine());

                temp = new Exercise(name, reps, weight);

                // Ask if adding another exercise.
                Console.Write("Add another exercise? (y/n) ");
                String response = Console.ReadLine();
                response = response.ToLower();

                exercises.Add(temp);

                // If not adding another exercise, exit loop.
                if (response.Equals("n")) { doneInputting = true; }
            }
        }

        public String toDelimitedString() {
            String ret = $"{week}|{day}";

            // Add each exercise to the delimited string.
            foreach (Exercise ex in exercises) {
                ret += $"|{ex.toDelimitedString()}";
            }

            return ret;
        }
    }
}
