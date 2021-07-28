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

        public void promptForWorkouts() {
            bool endLoop = false;
            String response;

            while (!endLoop) {
                Console.Write("Add a new workout? (y/n) ");
                response = Console.ReadLine().ToLower().Trim();

                if (response.Equals("y")) {
                    hydrateNewWorkout();
                } else {
                    endLoop = true;
                }
            }
        }

        public void hydrateNewWorkout() {
            int week, day;

            do {
                Console.Write("Week: ");
            } while (!int.TryParse(Console.ReadLine(), out week));

            do {
                Console.Write("Day: ");
            } while (!int.TryParse(Console.ReadLine(), out day));

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
                if (usePrevious) {
                    name = exerciseNames[count];
                    Console.Write($"Name:\n{name}\n");
                    doneInputting = ++count >= exerciseNames.Count;
                } else {
                    do {
                        Console.Write("Name: ");
                        name = Console.ReadLine().ToTitleCase().Trim();
                    } while (String.IsNullOrEmpty(name));
                }

                do {
                    Console.Write("Reps: ");
                    reps = Console.ReadLine().Trim().Replace(" ", "");
                } while (String.IsNullOrEmpty(reps));

                do {
                    Console.Write("Weight: ");
                } while (!double.TryParse(Console.ReadLine(), out weight));

                temp = new Exercise(name, reps, weight);

                exercises.Add(temp);

                // If not adding another exercise, exit loop.
                if (!usePrevious) {
                    Console.Write("Add another exercise? (y/n) ");
                    String inp = Console.ReadLine().ToLower();
                    doneInputting = inp.Equals("n");
                }
            }

            return exercises;
        }
    }
}
