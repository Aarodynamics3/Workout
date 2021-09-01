package io.workoutapi.workout;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import org.springframework.stereotype.Service;

@Service
public class WorkoutService {
	private List<Workout> workouts = new ArrayList<>(Arrays.asList(
			new Workout("ahanrahan_1_1", 1, 1),
			new Workout("ahanrahan_1_2", 1, 2)
			));
	
	public List<Workout> getAllWorkouts() {
		return workouts;
	}
	
	public Workout getWorkout(String id) {
		return workouts.stream().filter(w -> w.getId().equals(id)).findFirst().get();
	}

	public void addWorkout(Workout workout) {
		workouts.add(workout);
	}

	public void updateWorkout(Workout workout, String id) {
		for (int i = 0; i < workouts.size(); i++) {
			Workout w = workouts.get(i);
			if (w.getId().equals(id)) {
				workouts.set(i, workout);
				return;
			}
		}
	}

	public void deleteWorkout(String id) {
		workouts.removeIf(w -> w.getId().equals(id));
	}
}
