using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Workout {
    class WorkoutMain {
        static void Main(string[] args) {
            String response;
            List<Workout> workouts = new();
            bool endLoop = false;

            // Directory path of the application executable.
            String startupPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String filePath = $"{startupPath}\\WorkoutList.txt";

            // If file does not exist, create it. Else, read it in and create a list of workouts for future reference.
            if (!File.Exists(filePath)) {
                File.Create(filePath);
            } else {
                using (StreamReader sr = File.OpenText(filePath)) {
                    string s = "";
                    while (!string.IsNullOrEmpty(s = sr.ReadLine())) {
                        workouts.Add(new Workout(s));
                    }
                }
            }

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

                    workouts.Sort();

                    //TODO Remove eventually.
                    Workout.printWorkouts(workouts);

                    /*
                     * Read in all of the previous workouts and ask the user
                     * if they want to use the same exercises as the previous day
                     */
                    var previousWorkout = workouts.FirstOrDefault(workout => workout.getWeek() == week - 1 && workout.getDay() == day);
                    bool usePrevious = false;
                    List<String> exercises = new();
                    

                    // If the length is 1, prompt the user if they would like to use the same exercises as last day.
                    if (previousWorkout != null) {
                        Console.WriteLine("Would you like to use the same exercises as the last workout? (y/n)");

                        foreach (Exercise ex in previousWorkout.getExercises()) {
                            var name = ex.getName();
                            exercises.Add(name);
                            var preview = String.Concat(name.Where(c => char.IsUpper(c)));
                            Console.Write($"{preview} ");
                        }
                        Console.WriteLine();

                        usePrevious = Console.ReadLine().ToLower().Equals("y");

                    // Else, there are no examples to reference.
                    } else {
                        Console.WriteLine("No previous records to reference.");
                    }

                    Workout _workout = new Workout(week, day, exercises, usePrevious);
                    String _workoutString = _workout.toDelimitedString();

                    Console.WriteLine(_workoutString);
                    File.AppendAllText(filePath, _workoutString + "\n");
                } else if (response.Equals("n")) {
                    endLoop = true;
                }
            }
        }
    }
}
