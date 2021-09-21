package io.workoutapi.exercise;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import io.workoutapi.workout.Workout;

@RestController
public class ExerciseController {

	@Autowired
	private ExerciseService exerciseService;
	
	@RequestMapping("/workouts/{workoutid}/exercises")
	public List<Exercise> getAllExercises(@PathVariable String workoutid) {
		return exerciseService.getAllExercises(workoutid);
	}
	
	@RequestMapping("/workouts/{workoutId}/exercises/{exerciseId}")
	public Exercise getExercise(@PathVariable String exerciseId) {
		return exerciseService.getExercise(exerciseId);
	}
	
	@PostMapping(value = "/workouts/{workoutId}/exercises")
	public void addExercise(@RequestBody Exercise exercise, @PathVariable String workoutId) {
		exercise.setWorkout(new Workout(workoutId, -1, -1));
		exerciseService.addExercise(exercise);
	}
	
	@PutMapping(value = "/workouts/{workoutId}/execises/{exerciseId}")
	public void updateExercise(@RequestBody Exercise exercise, @PathVariable String workoutId) {
		exercise.setWorkout(new Workout(workoutId, -1, -1));
		exerciseService.updateExercise(exercise);
	}
	
	@DeleteMapping(value = "/workouts/{workoutId}/execises/{exerciseId}")
	public void deleteExercise(@PathVariable String exerciseId) {
		exerciseService.deleteExercise(exerciseId);
	}
}
