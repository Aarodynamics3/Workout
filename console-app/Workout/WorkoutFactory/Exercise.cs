using System;

namespace Workout {
    class Exercise {
        private String name, reps;

		/* Weight represents different things for different exercises.
		 * If the exercise uses a barbell, then weight represents
		 * the weight on one side in lbs. If on a machine, then it represents
		 * the weight setting for the machine. 
		 */
		private double weight;

		public Exercise(String name, String reps, double weight) {
			this.name = name;
			this.reps = reps;
			this.weight = weight;
        }

		public String toDelimitedString() {
			return $"{name}|{reps}|{weight}";
        }

		public String getName() {
			return this.name;
        }
	}
}
