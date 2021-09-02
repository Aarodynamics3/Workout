package io.workoutapi.workout;

import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class WorkoutService {
	
	@Autowired
	private WorkoutRepository workoutRepository;
	
	public List<Workout> getAllWorkouts() {
		List<Workout> workouts = new ArrayList<Workout>();
		workoutRepository.findAll().forEach(workouts::add);
		return workouts;
	}
	
	public Workout getWorkout(String id) {
		return workoutRepository.findById(id).get();
	}

	public void addWorkout(Workout workout) {
		workoutRepository.save(workout);
	}

	public void updateWorkout(Workout workout, String id) {
		workoutRepository.save(workout);
	}

	public void deleteWorkout(String id) {
		workoutRepository.deleteById(id);
	}
}
