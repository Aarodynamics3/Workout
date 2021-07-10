using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Workout {
    class WorkoutMain {
        static void Main(string[] args) {
            String response;
            ArrayList workouts = new();
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

            foreach (Workout wks in workouts) {
                Console.WriteLine(wks.toDelimitedString());
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

                    /*
                     * TODO: Read in all of the previous workouts and ask the user
                     * if they want to use the same exercises as the previous day
                     * For example: if the user is inputting week 2 day 5, ask if they
                     * are using the same exercises as week 1 day 5.
                     * 
                     * TODO also create a preview to go along w/ this prompt
                     * Example: (DL PD MR FP HC DBC)
                     */
                    var previousWorkout = (from Workout wk in workouts where 
                                           wk.getWeek() == week - 1 && wk.getDay() == day select wk).ToArray();
                    bool usePrevious = false;
                    ArrayList exercises = new();

                    // If the length is 1, prompt the user if they would like to use the same exercises as last day.
                    if (previousWorkout.Length == 1) {
                        Console.WriteLine("Would you like to use the same exercises as the last workout? (y/n)");

                        foreach (Exercise ex in previousWorkout[0].getExercises()) {
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

                    Workout _workout = new Workout(week, day);
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
