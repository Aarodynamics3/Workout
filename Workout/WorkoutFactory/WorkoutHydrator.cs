using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Workout {
    class WorkoutHydrator {
        private String filePath;
        private List<Workout> workouts;
        private static bool usePrevious;
        private static List<String> exerciseNames;

        public WorkoutHydrator(List<Workout> input, String file) {
            workouts = input;
            filePath = file;
        }

        public void hydrateNewWorkout() {
            int week, day;

            Console.Write("Week: ");
            week = Convert.ToInt32(Console.ReadLine());

            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());

            workouts.Sort((a,b) => b.CompareTo(a));

            // Read in all of the previous workouts and ask the user if they want to use the same exercises as the previous day.
            var previousWorkout = workouts.FirstOrDefault(workout => workout.getWeek() < week && workout.getDay() == day);
            usePrevious = false;
            exerciseNames = new();

            // If the length is 1, prompt the user if they would like to use the same exercises as last day.
            if (previousWorkout != null) {
                Console.WriteLine("Would you like to use the same exercises as the last workout? (y/n)");

                foreach (Exercise ex in previousWorkout.getExercises()) {
                    var name = ex.getName();
                    exerciseNames.Add(name);
                    var preview = String.Concat(name.Where(c => char.IsUpper(c)));
                    Console.Write($"{preview} ");
                }
                Console.WriteLine();

                usePrevious = Console.ReadLine().ToLower().Equals("y");

                // Else, there are no examples to reference.
            } else {
                Console.WriteLine("No previous records to reference.");
            }

            Workout _workout = new Workout(week, day);
            String _workoutString = _workout.toDelimitedString();

            Console.WriteLine(_workoutString);
            File.AppendAllTextAsync(filePath, _workoutString + "\n");
        }

        public static List<Exercise> constructExercises() {
            bool doneInputting = false;
            String name, reps;
            double weight;
            Exercise temp;
            int count = 0;
            List<Exercise> exercises = new();

            // While not done inputting, prompt for name, reps, and weight.
            while (!doneInputting) {
                Console.Write("Name: ");
                if (usePrevious) {
                    name = exerciseNames[count];
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

            return exercises;
        }
    }
}
