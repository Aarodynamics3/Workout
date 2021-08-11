using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Workout {
    class WorkoutMain {
        static void Main(string[] args) {
            List<Workout> workouts = new();

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

            wh.promptForWorkouts();
        }
    }
}
