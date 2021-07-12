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

            WorkoutHydrator wh = new(workouts, filePath);

            while (!endLoop) {
                Console.Write("Add a new workout? (y/n) ");
                response = Console.ReadLine();
                response = response.ToLower();

                if (response.Equals("y")) {
                    wh.hydrateNewWorkout();
                } else {
                    endLoop = true;
                }
            }
        }
    }
}
