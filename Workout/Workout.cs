using System;
using System.Collections.Generic;

namespace Workout {
    class Workout:IComparable<Workout> {
        private int week, day;
        private List<Exercise> exercises;

        public Workout(int week, int day, List<String> exerciseNames, bool usePrevious) {
            this.week = week;
            this.day = day;
            this.exercises = new();

            constructWorkout(exerciseNames, usePrevious);
        }

        // Creates a workout from a delimited string.
        public Workout(String input) {
            String[] list = input.Split("|");

            this.week = Convert.ToInt32(list[0]);
            this.day = Convert.ToInt32(list[1]);
            this.exercises = new();
            
            for (int i = 0; i < (list.Length - 2) / 3; i++) {
                exercises.Add(
                    new Exercise(list[(i * 3) + 2], list[(i * 3) + 3], Convert.ToDouble(list[(i * 3) + 4]))
                );
            }
        }

        private void constructWorkout(List<String> exerciseNames, bool usePrevious) {
            bool doneInputting = false;
            String name, reps;
            double weight;
            Exercise temp;
            int count = 0;
            
            // While not done inputting, prompt for name, reps, and weight.
            while (!doneInputting) {
                Console.Write("Name: ");
                if (usePrevious) {
                    name = (String) exerciseNames[count];
                    Console.Write($"{name}\n");
                    doneInputting = ++count >= exerciseNames.Count;
                } else {
                    name = Console.ReadLine().ToTitleCase();
                }

                Console.Write("Reps: ");
                reps = Console.ReadLine().Replace(" ", "");

                Console.Write("Weight: ");
                weight = Convert.ToDouble(Console.ReadLine());

                temp = new Exercise(name, reps, weight);

                exercises.Add(temp);

                // If not adding another exercise, exit loop.
                if (!usePrevious) {
                    Console.Write("Add another exercise? (y/n) ");
                    doneInputting = Console.ReadLine().ToLower().Equals("n");
                }
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

        public int getWeek() {
            return this.week;
        }

        public int getDay() {
            return this.day;
        }

        public List<Exercise> getExercises() {
            return this.exercises;
        }

        public static void printWorkouts(List<Workout> workouts) {
            foreach (Workout wks in workouts) {
                Console.WriteLine(wks.toDelimitedString());
            }
        }

        public int CompareTo(Workout other) {
            if (this.week == other.getWeek()) {
                return this.day - other.getDay();
            }
            return this.week - other.getWeek();
        }
    }
}
