package io.workoutapi.workout;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class WorkoutController {

	@Autowired
	private WorkoutService workoutService;
	
	@RequestMapping("/workouts")
	public List<Workout> getAllWorkouts() {
		return workoutService.getAllWorkouts();
	}
	
	@RequestMapping("/workouts/{id}")
	public Workout getWorkout(@PathVariable String id) {
		return workoutService.getWorkout(id);
	}
	
	@PostMapping(value = "/workouts")
	public void addWorkout(@RequestBody Workout workout) {
		workoutService.addWorkout(workout);
	}
	
	@PutMapping(value = "/workouts/{id}")
	public void updateWorkout(@RequestBody Workout workout, @PathVariable String id) {
		workoutService.updateWorkout(workout, id);
	}
	
	@DeleteMapping(value = "/workouts/{id}")
	public void deleteWorkout(@PathVariable String id) {
		workoutService.deleteWorkout(id);
	}
}
