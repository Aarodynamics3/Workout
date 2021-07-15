using System;
using System.Collections.Generic;

namespace Workout {
    class Workout:IComparable<Workout> {
        private int week, day;
        private List<Exercise> exercises;

        public Workout(int week, int day) {
            this.week = week;
            this.day = day;

            // Calls to the hydrator which prompts the user to create exercises for the workout.
            exercises = WorkoutHydrator.constructExercises();
        }

        // Creates a workout from a delimited string.
        public Workout(String input) {
            String[] list = input.Split("|");

            week = Convert.ToInt32(list[0]);
            day = Convert.ToInt32(list[1]);
            exercises = new();
            
            for (int i = 0; i < (list.Length - 2) / 3; i++) {
                exercises.Add(
                    new Exercise(list[(i * 3) + 2], list[(i * 3) + 3], Convert.ToDouble(list[(i * 3) + 4]))
                );
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

        public int CompareTo(Workout other) {
            if (this.week == other.getWeek()) {
                return this.day - other.getDay();
            }
            return this.week - other.getWeek();
        }
    }
}
