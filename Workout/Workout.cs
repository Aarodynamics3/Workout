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

        private void constructWorkout() {
            bool doneInputting = false;
            String name, reps;
            double weight;
            Exercise temp;

            // While not done inputting, prompt for name, reps, and weight.
            while (!doneInputting) {
                Console.Write("Name: ");
                name = Console.ReadLine();

                Console.Write("Reps: ");
                reps = Console.ReadLine();

                Console.Write("Weight: ");
                weight = Convert.ToDouble(Console.ReadLine());

                temp = new Exercise(name, reps, weight);

                // Ask if adding another exercise.
            }
        }

        public String toDelimitedString() {
            return null;
        }
    }
}
